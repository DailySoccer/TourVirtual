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

	public string SelectedModel = string.Empty;

    public GameObject prefabMale;
    public GameObject prefabFemale;
    public Material baseMaterial;
    public Material baseCompliment;
    public Texture2D textureNumbers;
    public float textureSize = 512;

    public Hashtable Hairs;
    public Hashtable Heads;
    public Hashtable Bodies;
    public Hashtable Legs;
    public Hashtable Feet;
    public Hashtable Compliments;
    public Hashtable Selector;

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
	void SpawnOnNetwork(Vector3 pos, Quaternion rot, int id, PhotonPlayer np, string selectedModel) {
		GameObject thePlayer = null;

		if (np.isLocal && Player.Instance != null) {
			Debug.Log("Instantiate Player");
			thePlayer = Player.Instance.Avatar ?? Player.Instance.gameObject;
			//thePlayer.GetComponentsInChildren<Animator>(true)[0].applyRootMotion = true;
			thePlayer.layer = LayerMask.NameToLayer( "Player" );
		}
		else {
            Debug.Log("SpawnOnNetwork: SelectedModel: " + selectedModel);
            StartCoroutine(PlayerManager.Instance.CreateAvatar(selectedModel, (instance) =>{
                thePlayer = instance;
                if (thePlayer.GetComponent<Locomotion>() != null)
                    thePlayer.GetComponent<Locomotion>().enabled = false;
                thePlayer.tag = "AvatarNet";
                thePlayer.layer = LayerMask.NameToLayer("Net");

                var csc = thePlayer.GetComponent<ContentSelectorCaster>();
                if(csc!=null) csc.enabled = false;
            }));
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
        if(nViews.Length>1)        
    		nViews[0].viewID = id;
	}

    public IEnumerator CacheClothes()
    {
        yield return StartCoroutine(DLCManager.Instance.LoadResource("avatars", (bundle) => {
            Hashtable json = JSON.JsonDecode(bundle.LoadAsset<TextAsset>("cloths").text) as Hashtable;
            Heads   = json["Heads"] as Hashtable;
            Hairs   = json["Hairs"] as Hashtable;
            Bodies  = json["Bodies"] as Hashtable;
            Legs    = json["Legs"] as Hashtable;
            Feet = json["Feet"] as Hashtable;
            Compliments = json["Compliments"] as Hashtable;
            Selector = json["Selector"] as Hashtable;
            packsList = json["packs"] as ArrayList;
        }));
    }

    public delegate void callback(GameObject instance);
    public IEnumerator CreateAvatar(string model, callback callback=null) {
        string[] section = model.Split('#');

        Debug.LogError(">>>> model " + model);

        Hashtable hairDesc = GetDescriptor(Hairs[section[0]] as ArrayList, section[1]);
        Hashtable headDesc = GetDescriptor(Heads[section[0]] as ArrayList, section[2]);
        Hashtable bodyDesc = GetDescriptor(Bodies[section[0]] as ArrayList, !string.IsNullOrEmpty(section[3])?section[3]: ((PlayerManager.Instance.Bodies[UserAPI.AvatarDesciptor.Gender] as ArrayList)[0] as Hashtable)["id"] as string);
        Hashtable legsDesc = GetDescriptor(Legs[section[0]] as ArrayList, !string.IsNullOrEmpty(section[4]) ? section[4] : ((PlayerManager.Instance.Legs[UserAPI.AvatarDesciptor.Gender] as ArrayList)[0] as Hashtable)["id"] as string);
        Hashtable feetDesc = GetDescriptor(Feet[section[0]] as ArrayList, !string.IsNullOrEmpty(section[5]) ? section[5] : ((PlayerManager.Instance.Feet[UserAPI.AvatarDesciptor.Gender] as ArrayList)[0] as Hashtable)["id"] as string);

        Hashtable compimentsDesc = string.IsNullOrEmpty(section[6])?null:GetDescriptor(Compliments[section[0]] as ArrayList, section[6]);

        GameObject lastInstance = Instantiate(section[0]=="Man"?prefabMale:prefabFemale);
        lastInstance.transform.position = Vector3.zero;

        yield return StartCoroutine(DLCManager.Instance.LoadResource("avatars", (bundle) => {
            Material mat = Instantiate(baseMaterial);
            if (hairDesc["mesh"]!=null) Assign(bundle.LoadAsset<GameObject>(hairDesc["mesh"] as string), lastInstance.transform.FindChild("Pelo"), mat);
            Assign(bundle.LoadAsset<GameObject>(headDesc["mesh"] as string), lastInstance.transform.FindChild("Cabeza"), mat);
            Assign(bundle.LoadAsset<GameObject>(bodyDesc["mesh"] as string), lastInstance.transform.FindChild("Torso"), mat);
            Assign(bundle.LoadAsset<GameObject>(legsDesc["mesh"] as string), lastInstance.transform.FindChild("Piernas"), mat);
            Assign(bundle.LoadAsset<GameObject>(feetDesc["mesh"] as string), lastInstance.transform.FindChild("Pies"), mat);
            // Material para el complemento.
            if (compimentsDesc != null) {
                Material matCmp = Instantiate(baseCompliment);
                matCmp.mainTexture = bundle.LoadAsset<Texture2D>(compimentsDesc["texture"] as string);
                Assign(bundle.LoadAsset<GameObject>(compimentsDesc["mesh"] as string), lastInstance.transform.FindChild("Complemento"), matCmp);
            }

            RenderTexture rt = RenderTexture.GetTemporary((int)textureSize, (int)textureSize);
            RenderTexture.active = rt;
            GL.PushMatrix();                                //Saves both projection and modelview matrices to the matrix stack.
            GL.LoadPixelMatrix(0, textureSize, textureSize, 0);

            ArrayList hairTextures = hairDesc["textures"] as ArrayList;
            Graphics.DrawTexture(new Rect(0, 0, textureSize * 0.5f, textureSize * 0.5f), bundle.LoadAsset<Texture2D>(headDesc["texture"] as string));
            Graphics.DrawTexture(new Rect(textureSize * 0.5f, 0, textureSize * 0.5f, textureSize * 0.5f), bundle.LoadAsset<Texture2D>(bodyDesc["texture"] as string));
            Graphics.DrawTexture(new Rect(0, textureSize * 0.5f, textureSize * 0.5f, textureSize * 0.5f), bundle.LoadAsset<Texture2D>(legsDesc["texture"] as string));
            Graphics.DrawTexture(new Rect(textureSize * 0.5f, textureSize * 0.5f, textureSize * 0.25f, textureSize * 0.25f), bundle.LoadAsset<Texture2D>(feetDesc["texture"] as string));
            if (hairTextures!=null) {
                Graphics.DrawTexture(new Rect(textureSize * 0.75f, textureSize * 0.5f, textureSize * 0.25f, textureSize * 0.25f), bundle.LoadAsset<Texture2D>(hairTextures[0] as string));
                if (hairTextures.Count > 1)
                    Graphics.DrawTexture(new Rect(textureSize * 0.5f, textureSize * 0.75f, textureSize * 0.25f, textureSize * 0.25f), bundle.LoadAsset<Texture2D>(hairTextures[1] as string));
            }

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

    public byte[] RenderModel(GameObject avatar, int w=320, int h=620) {
        RenderTexture rt = RenderTexture.GetTemporary(w, h, 16, RenderTextureFormat.ARGB32);
        int oldLayer = avatar.layer;

        SetLayerRecursively(avatar, 31);
        var camera = new GameObject("TmpCamera", typeof(Camera)).GetComponent<Camera>();
        camera.cullingMask = (1 << 31);
        camera.transform.position = new Vector3(0, 0.9f, 2);
        camera.transform.rotation = Quaternion.Euler(0, 180, 0);
        camera.targetTexture = rt;
        camera.clearFlags = CameraClearFlags.SolidColor;
        camera.backgroundColor = new Color(0, 0, 0, 0);
        camera.Render();

        RenderTexture.active = rt;
        Texture2D tex = new Texture2D(w, h, TextureFormat.ARGB32, false);

        // Read screen contents into the texture
        tex.ReadPixels(new Rect(0, 0, w, h), 0, 0);
        tex.Apply();
        byte[] bytes = tex.EncodeToPNG();
        Destroy(tex);

        RenderTexture.active = null;
        RenderTexture.ReleaseTemporary(rt);
        Destroy(camera);
        SetLayerRecursively(avatar, oldLayer);

        return bytes;

    }

    void SetLayerRecursively(GameObject obj, int newLayer)
    {
        obj.layer = newLayer;
        foreach (Transform child in obj.transform)
            SetLayerRecursively(child.gameObject, newLayer);
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

        smrDst.sharedMesh = Instantiate(smrOrg.sharedMesh);
        Material[] mats = new Material[2];// smrDst.sharedMaterials;
        for (int i = 0; i < mats.Length; ++i)
            mats[i] = mat;
        smrDst.sharedMaterials = mats;
    }


    Transform SearchHierarchyForBone(Transform current, string name) {
        if (current.name == name)
            return current;
        for (int i = 0; i < current.childCount; ++i) {
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
