using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Photon;

public class PlayerManager : Photon.PunBehaviour {

	static public PlayerManager Instance {
		get {
			GameObject playerManagerObj = GameObject.FindGameObjectWithTag("PlayerManager");
			return playerManagerObj != null ? playerManagerObj.GetComponent<PlayerManager>() : null;
		}
	}

	public int SelectedModel = -1;

    public GameObject prefabMale;
    public GameObject prefabFemale;
    public Material baseMaterial;
    public Texture2D textureNumbers;
    public float textureSize = 512;

    ArrayList headsList;
    ArrayList clothsList;
    ArrayList packsList;


    void Start () {
	}

	void Update () {
	}

	public override void OnLeftRoom() {
	}

	public override void OnJoinedRoom() {
		// PhotonNetwork.Instantiate( "Player Character", Vector3.zero, Quaternion.identity, 0 );
		SpawnPlayer();
	}

	void SpawnPlayer() {
		int viewIdOld = _viewId;

		// Manually allocate PhotonViewID
		_viewId = PhotonNetwork.AllocateViewID();

		/*
		if (viewIdOld != -1 && _viewId != viewIdOld) {
			Debug.Log ("PhotonNetwork.UnAllocateViewID: " + viewIdOld);
			PhotonNetwork.UnAllocateViewID(viewIdOld);
		}
		*/

		Transform playerTransform;
		if (Player.Instance != null) {
			playerTransform = Player.Instance.Avatar.transform;
		}
		else {
			playerTransform = transform;
		}
		photonView.RPC("SpawnOnNetwork", PhotonTargets.AllBuffered, playerTransform.position, playerTransform.rotation, _viewId, PhotonNetwork.player, SelectedModel);
	}

	[PunRPC]
	void SpawnOnNetwork(Vector3 pos, Quaternion rot, int id, PhotonPlayer np, int selectedModel) {
		GameObject thePlayer = null;

		if (np.isLocal && Player.Instance != null) {
			Debug.Log("Instantiate Player");

			thePlayer = Player.Instance.Avatar ?? Player.Instance.gameObject;
			thePlayer.GetComponentsInChildren<Animator>(true)[0].applyRootMotion = true;
			thePlayer.layer = LayerMask.NameToLayer( "Player" );
		}
		else {
			Debug.Log("SpawnOnNetwork: SelectedModel: " + SelectedModel);
            /*
			GameObject prefab = Library.GetRecipe(selectedModel) ?? playerPrefab;
			thePlayer = Instantiate(prefab, pos, rot) as GameObject;

			// Apagamos el componente de desplazamiento
			if (thePlayer.GetComponent<Locomotion>() != null) {
				thePlayer.GetComponent<Locomotion>().enabled = false;
			}

			thePlayer.tag = "AvatarNet";
			thePlayer.layer = LayerMask.NameToLayer( "Net" );
            */
		}

		// Set the PhotonView
		PhotonView[] nViews = thePlayer.GetComponentsInChildren<PhotonView>(true);
		nViews[0].viewID = id;
	}

    public IEnumerator CacheClothes()
    {
        yield return StartCoroutine(DLCManager.Instance.LoadResource("avatars", (bundle) =>
        {
            Hashtable json = JSON.JsonDecode(bundle.LoadAsset<TextAsset>("cloths").text) as Hashtable;
            headsList = json["heads"] as ArrayList;
            clothsList = json["cloths"] as ArrayList;
            packsList = json["packs"] as ArrayList;
        }));
    }

    public delegate void callback(GameObject instance);
    public IEnumerator CreateAvatar(string cabeza, string pelo, string torso, string piernas, string pies, callback callback)
    {
        Hashtable headDesc = GetDescriptor(headsList, cabeza);
        Hashtable bodyDesc = GetDescriptor(clothsList, torso);
        Hashtable legsDesc = GetDescriptor(clothsList, piernas);
        Hashtable feetDesc = GetDescriptor(clothsList, pies);
        Hashtable hairDesc = GetDescriptor(headsList, pelo);

        GameObject lastInstance = Instantiate(prefabMale);


        lastInstance.layer = LayerMask.NameToLayer("Player");
        lastInstance.transform.position = Vector3.zero;
        lastInstance.GetComponent<Rigidbody>().isKinematic = true;
        lastInstance.GetComponent<SynchNet>().enabled = false;

        yield return StartCoroutine(DLCManager.Instance.LoadResource("avatars", (bundle) =>
        {
            Material mat = Instantiate(baseMaterial);

            Assign(bundle.LoadAsset<GameObject>(headDesc["mesh"] as string), lastInstance.transform.FindChild("Cabeza"), mat);
            Assign(bundle.LoadAsset<GameObject>(bodyDesc["mesh"] as string), lastInstance.transform.FindChild("Torso"), mat);
            Assign(bundle.LoadAsset<GameObject>(legsDesc["mesh"] as string), lastInstance.transform.FindChild("Piernas"), mat);
            Assign(bundle.LoadAsset<GameObject>(feetDesc["mesh"] as string), lastInstance.transform.FindChild("Pies"), mat);

            RenderTexture rt = RenderTexture.GetTemporary((int)textureSize, (int)textureSize);

            RenderTexture.active = rt;
            GL.PushMatrix();                                //Saves both projection and modelview matrices to the matrix stack.
            GL.LoadPixelMatrix(0, textureSize, textureSize, 0);

            Graphics.DrawTexture(new Rect(0, 0, textureSize * 0.5f, textureSize * 0.5f), bundle.LoadAsset<Texture2D>(headDesc["texture"] as string));
            Graphics.DrawTexture(new Rect(textureSize * 0.5f, 0, textureSize * 0.5f, textureSize * 0.5f), bundle.LoadAsset<Texture2D>(bodyDesc["texture"] as string));
            Graphics.DrawTexture(new Rect(0, textureSize * 0.5f, textureSize * 0.5f, textureSize * 0.5f), bundle.LoadAsset<Texture2D>(legsDesc["texture"] as string));
            Graphics.DrawTexture(new Rect(textureSize * 0.5f, textureSize * 0.5f, textureSize * 0.25f, textureSize * 0.25f), bundle.LoadAsset<Texture2D>(feetDesc["texture"] as string));
            Graphics.DrawTexture(new Rect(textureSize * 0.75f, textureSize * 0.5f, textureSize * 0.25f, textureSize * 0.25f), bundle.LoadAsset<Texture2D>(hairDesc["texture"] as string));

            Texture2D dst = new Texture2D((int)textureSize, (int)textureSize);
            dst.ReadPixels(new Rect(0, 0, textureSize, textureSize), 0, 0);
            dst.Apply();

            RenderTexture.active = null;

            RenderTexture.ReleaseTemporary(rt);

            mat.mainTexture = dst;
            GL.PopMatrix();

            lastInstance.SetActive(true);

            RenderTexture.active = null; // Restore

            if (callback != null) callback(lastInstance);
        }));
    }

    Hashtable GetDescriptor(ArrayList list, string id) {
        foreach (Hashtable ele in list)
            if (ele["id"] as string == id)
                return ele as Hashtable;
        return null;
    }


    void Assign(GameObject prefab, Transform target, Material mat)
    {
        var smrOrg = prefab.GetComponent<SkinnedMeshRenderer>();
        var smrDst = target.GetComponent<SkinnedMeshRenderer>();

        Transform[] bones = smrOrg.bones;
        for (int i = 0; i < bones.Length; ++i)
            bones[i] = SearchHierarchyForBone(target.parent, bones[i].name);
        smrDst.bones = bones;

        smrDst.sharedMesh = smrOrg.sharedMesh;
        Material[] mats = smrDst.sharedMaterials;
        for (int i = 0; i < mats.Length; ++i)
            mats[i] = mat;
        smrDst.sharedMaterials = mats;
    }

    Transform SearchHierarchyForBone(Transform current, string name)
    {
        if (current.name == name)
            return current;
        for (int i = 0; i < current.childCount; ++i)
        {
            Transform found = SearchHierarchyForBone(current.GetChild(i), name);
            if (found != null)
                return found;
        }
        return null;
    }



    void DebugInfo() {
		Debug.Log ("countOfPlayers: " + PhotonNetwork.countOfPlayers);
		Debug.Log ("countOfPlayersInRooms: " + PhotonNetwork.countOfPlayersInRooms);
		Debug.Log ("countOfPlayersOnMaster: " + PhotonNetwork.countOfPlayersOnMaster);
		Debug.Log ("countOfRooms: " + PhotonNetwork.countOfRooms);
	}

	int _viewId = -1;
}
