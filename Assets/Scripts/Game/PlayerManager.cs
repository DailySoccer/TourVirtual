﻿using UnityEngine;
using System.Collections.Generic;
using Photon;

public class PlayerManager : Photon.PunBehaviour {

	static public PlayerManager Instance {
        get; private set;
	}

	public string SelectedModel = string.Empty;
	public string DataModel = string.Empty;

    public GameObject prefabMale;
    public GameObject prefabFemale;
    public Material baseMaterial;
    public Material baseCompliment;
    public Texture2D textureNumbers;
    public float textureSize = 512;

    public Dictionary<string, object> Hairs;
    public Dictionary<string, object> Heads;
    public Dictionary<string, object> Bodies;
    public Dictionary<string, object> Legs;
    public Dictionary<string, object> Feet;
    public Dictionary<string, object> Packs;
    public Dictionary<string, object> Compliments;
    public Dictionary<string, object> Selector;

	public GameObject PlayerRemoteHUDCanvas;

	GameObject PlayerHUD;

    void Awake()
    {
        Instance = this;
    }

	public override void OnLeftRoom() {
	}

	public override void OnJoinedRoom() {
		// PhotonNetwork.Instantiate( "Player Character", Vector3.zero, Quaternion.identity, 0 );
		SpawnPlayer();
	}

	void SpawnPlayer() {
#if !LITE_VERSION
		int viewIdOld = _viewId;
		// Manually allocate PhotonViewID
		_viewId = PhotonNetwork.AllocateViewID();
		if (viewIdOld != -1 && _viewId != viewIdOld) {
			PhotonNetwork.UnAllocateViewID(viewIdOld);
		}

		Transform playerTransform;
		if (Player.Instance != null) {
			playerTransform = Player.Instance.Avatar.transform;
		}
		else {
			playerTransform = transform;
		}
		photonView.RPC("SpawnOnNetwork", PhotonTargets.AllBuffered, playerTransform.position, playerTransform.rotation, _viewId, PhotonNetwork.player, SelectedModel, DataModel);
#endif
	}
#if !LITE_VERSION
	[PunRPC]
	void SpawnOnNetwork(Vector3 pos, Quaternion rot, int id, PhotonPlayer np, string selectedModel, string DataModel) {
        if (np.isLocal && Player.Instance != null) {
            StartCoroutine(PlayerManager.Instance.CreateAvatar(PlayerManager.Instance.SelectedModel, (instance) => {
                instance.layer = LayerMask.NameToLayer("Player");
                instance.GetComponent<SynchNet>().isLocal = true;
                instance.GetComponent<PhotonView>().viewID = id;
                if (Player.Instance != null) Player.Instance.Avatar = instance;
                if (RoomManager.entrada != null)
                {
                    instance.transform.position = RoomManager.entrada.position;
                    instance.transform.rotation = RoomManager.entrada.rotation;
                }

            }));
        }
        else {
            StartCoroutine(PlayerManager.Instance.CreateAvatar(selectedModel, (instance) =>{
                instance.tag = "AvatarNet";
                instance.layer = LayerMask.NameToLayer("Net");
                instance.GetComponent<SynchNet>().isLocal = false;
                instance.GetComponent<PhotonView>().viewID = id;

                instance.GetComponent<Locomotion>().enabled = false;
                instance.GetComponent<ContentSelectorCaster>().enabled = false;

                //Código para insertar el HUD de los players remotos
                PlayerHUD =  Instantiate(PlayerRemoteHUDCanvas);
				PlayerHUD.GetComponent<RemotePlayerHUD>().SetDataModel( DataModel ,selectedModel.Split('#')[2] );
				PlayerHUD.transform.SetParent(instance.transform);
				PlayerHUD.transform.localScale = Vector3.one * 0.005f;
				PlayerHUD.transform.position = new Vector3(0.0f, 2.2f, PlayerHUD.transform.position.z);

            }));
		}
		// Set the PhotonView
	}
#endif
    public System.Collections.IEnumerator CacheClothes() {
        yield return StartCoroutine(DLCManager.Instance.LoadResource("avatars", (bundle) => {
            Dictionary<string,object> json = BestHTTP.JSON.Json.Decode(bundle.LoadAsset<TextAsset>("cloths").text) as Dictionary<string, object>;
            if (json.ContainsKey("Heads")) Heads = json["Heads"] as Dictionary<string, object>;
            if (json.ContainsKey("Hairs")) Hairs = json["Hairs"] as Dictionary<string, object>;
            if (json.ContainsKey("Bodies")) Bodies = json["Bodies"] as Dictionary<string, object>;
            if (json.ContainsKey("Legs")) Legs = json["Legs"] as Dictionary<string, object>;
            if (json.ContainsKey("Feet")) Feet = json["Feet"] as Dictionary<string, object>;
			if (json.ContainsKey("Packs")) Packs   = json["Packs"] as Dictionary<string, object>;
            if (json.ContainsKey("Compliments")) Compliments = json["Compliments"] as Dictionary<string, object>;
            if (json.ContainsKey("Selector")) Selector = json["Selector"] as Dictionary<string, object>;
        }));

		//Debug.LogError("Cachado!!!! "  + Heads.ToString() );
    }

    public Dictionary<string, object> GetPackDescriptor(string GUID)
    {
        return GetDescriptor( Packs[UserAPI.AvatarDesciptor.Gender] as List<object>, GUID);
    }
    public delegate void callback(GameObject instance);
    public System.Collections.IEnumerator CreateAvatar(string model, callback callback=null, GameObject oldInstance=null) {
#if UNITY_EDITOR
        if (string.IsNullOrEmpty(model)) model = "Man#988dee0b-e8a2-4771-85ee-e537389b3330#HCabeza03#02e9b0a5-29d9-4b5c-9894-25b72b0209eb#c63925be-c3f5-46d5-97da-617a1489d599#2e1c35ed-ff06-486e-a088-e2b8d5135e3f#";
#endif 
        string[] section = model.Split('#');

        float anmTime = 0;
        if (oldInstance != null) {
            anmTime = oldInstance.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime;
            Destroy(oldInstance);
        }

        GameObject lastInstance = Instantiate(section[0]=="Man"?prefabMale:prefabFemale);
        lastInstance.transform.position = Vector3.zero;

        yield return StartCoroutine(DLCManager.Instance.LoadResource("avatars", (bundle) => {
            StartCoroutine(RenderAvatar(lastInstance, section, bundle, anmTime, callback));
        }));
    }

    System.Collections.IEnumerator RenderAvatar(GameObject lastInstance, string[] section, AssetBundle bundle, float anmTime, callback callback) {
        yield return null;
        
        string bodyID = !string.IsNullOrEmpty(section[3]) ? section[3] : ((Bodies[section[0]] as List<object>)[0] as Dictionary<string, object>)["id"] as string;
        string legsID = !string.IsNullOrEmpty(section[4]) ? section[4] : ((Legs[section[0]] as List<object>)[0] as Dictionary<string, object>)["id"] as string;
        string feetID = !string.IsNullOrEmpty(section[5]) ? section[5] : ((Feet[section[0]] as List<object>)[0] as Dictionary<string, object>)["id"] as string;

        Dictionary<string, object> hairDesc = GetDescriptor(Hairs[section[0]] as List<object>, section[1]);
        Dictionary<string, object> headDesc = GetDescriptor(Heads[section[0]] as List<object>, section[2]);
        Dictionary<string, object> compimentsDesc = string.IsNullOrEmpty(section[6]) ? null : GetDescriptor(Compliments[section[0]] as List<object>, section[6]);
        Dictionary<string, object> bodyDesc = GetDescriptor(Bodies[section[0]] as List<object>, bodyID);
        Dictionary<string, object> legsDesc = GetDescriptor(Legs[section[0]] as List<object>, legsID);
        Dictionary<string, object> feetDesc = GetDescriptor(Feet[section[0]] as List<object>, feetID);

        PlayerMaterialMemory pmm = lastInstance.AddComponent<PlayerMaterialMemory>();
        Material mat = Instantiate(baseMaterial);
//        yield return null;
        pmm.matMaterial = mat;
        if (hairDesc["mesh"] != null) Assign(bundle.LoadAsset<GameObject>(hairDesc["mesh"] as string), lastInstance.transform.FindChild("Pelo"), mat);
        Assign(bundle.LoadAsset<GameObject>(headDesc["mesh"] as string), lastInstance.transform.FindChild("Cabeza"), mat);
        yield return null;
        Assign(bundle.LoadAsset<GameObject>(bodyDesc["mesh"] as string), lastInstance.transform.FindChild("Torso"), mat);
        yield return null;
        Assign(bundle.LoadAsset<GameObject>(legsDesc["mesh"] as string), lastInstance.transform.FindChild("Piernas"), mat);
        yield return null;
        Assign(bundle.LoadAsset<GameObject>(feetDesc["mesh"] as string), lastInstance.transform.FindChild("Pies"), mat);
        yield return null;
        // Material para el complemento.
        if (compimentsDesc != null) {
            Material matCmp = Instantiate(baseCompliment);
            pmm.matCompliment = matCmp;
            matCmp.mainTexture = bundle.LoadAsset<Texture2D>(compimentsDesc["texture"] as string);
            Assign(bundle.LoadAsset<GameObject>(compimentsDesc["mesh"] as string), lastInstance.transform.FindChild("Complemento"), matCmp);
        }
        yield return null;
        RenderTexture rt = RenderTexture.GetTemporary((int)textureSize, (int)textureSize);
        yield return null;
        RenderTexture.active = rt;
        GL.PushMatrix();                                //Saves both projection and modelview matrices to the matrix stack.
        GL.LoadPixelMatrix(0, textureSize, textureSize, 0);
        List<object> hairTextures = hairDesc["textures"] as List<object>;
        Texture txt = bundle.LoadAsset<Texture2D>(headDesc["texture"] as string);
        if (txt != null)
        {
            Graphics.DrawTexture(new Rect(0, 0, textureSize * 0.5f, textureSize * 0.5f), txt);
        }
        GL.PopMatrix();
        RenderTexture.active = null;
        yield return null;

        RenderTexture.active = rt;
        GL.PushMatrix();                                //Saves both projection and modelview matrices to the matrix stack.
        GL.LoadPixelMatrix(0, textureSize, textureSize, 0);
        txt = bundle.LoadAsset<Texture2D>(bodyDesc["texture"] as string);
        if (txt != null)
        {
            Graphics.DrawTexture(new Rect(textureSize * 0.5f, 0, textureSize * 0.5f, textureSize * 0.5f), txt);
        }
        GL.PopMatrix();
        RenderTexture.active = null;
        yield return null;

        RenderTexture.active = rt;
        GL.PushMatrix();                                //Saves both projection and modelview matrices to the matrix stack.
        GL.LoadPixelMatrix(0, textureSize, textureSize, 0);
        txt = bundle.LoadAsset<Texture2D>(legsDesc["texture"] as string);
        if (txt != null)
        {
            Graphics.DrawTexture(new Rect(0, textureSize * 0.5f, textureSize * 0.5f, textureSize * 0.5f), txt);
        }
        GL.PopMatrix();
        RenderTexture.active = null;
        yield return null;

        RenderTexture.active = rt;
        GL.PushMatrix();                                //Saves both projection and modelview matrices to the matrix stack.
        GL.LoadPixelMatrix(0, textureSize, textureSize, 0);

        txt = bundle.LoadAsset<Texture2D>(feetDesc["texture"] as string);
        if (txt != null)
        {
            Graphics.DrawTexture(new Rect(textureSize * 0.5f, textureSize * 0.5f, textureSize * 0.25f, textureSize * 0.25f), txt);
        }

        GL.PopMatrix();
        RenderTexture.active = null;
        yield return null;

        RenderTexture.active = rt;
        GL.PushMatrix();                                //Saves both projection and modelview matrices to the matrix stack.
        GL.LoadPixelMatrix(0, textureSize, textureSize, 0);
        if (hairTextures != null)
        {
            txt = bundle.LoadAsset<Texture2D>(hairTextures[0] as string);
            if (txt != null)
            {
                Graphics.DrawTexture(new Rect(textureSize * 0.75f, textureSize * 0.5f, textureSize * 0.25f, textureSize * 0.25f), txt);
            }
            if (hairTextures.Count > 1)
            {
                txt = bundle.LoadAsset<Texture2D>(hairTextures[1] as string);
                if (txt != null)
                {
                    Graphics.DrawTexture(new Rect(textureSize * 0.5f, textureSize * 0.75f, textureSize * 0.25f, textureSize * 0.25f), txt);
                }
            }
        }
        float initTime = Time.realtimeSinceStartup;

        GL.PopMatrix();
        RenderTexture.active = null;
        yield return null;

        RenderTexture.active = rt;
        GL.PushMatrix();                                //Saves both projection and modelview matrices to the matrix stack.
        GL.LoadPixelMatrix(0, textureSize, textureSize, 0);

        Texture2D dst = new Texture2D((int)textureSize, (int)textureSize);
        dst.name = "PlayerTextureCompose";
        int hlf = (int)(textureSize * 0.5f);
        dst.ReadPixels(new Rect(  0,   0, hlf, hlf),   0, 0);
        GL.PopMatrix();
        RenderTexture.active = null;
        yield return null;

        RenderTexture.active = rt;
        GL.PushMatrix();                                //Saves both projection and modelview matrices to the matrix stack.
        GL.LoadPixelMatrix(0, textureSize, textureSize, 0);

        dst.ReadPixels(new Rect(hlf,   0, hlf, hlf), hlf, 0);
        GL.PopMatrix();
        RenderTexture.active = null;
        yield return null;

        RenderTexture.active = rt;
        GL.PushMatrix();                                //Saves both projection and modelview matrices to the matrix stack.
        GL.LoadPixelMatrix(0, textureSize, textureSize, 0);
        dst.ReadPixels(new Rect(  0, hlf, hlf, hlf),   0, hlf);
        GL.PopMatrix();
        RenderTexture.active = null;
        yield return null;

        RenderTexture.active = rt;
        GL.PushMatrix();                                //Saves both projection and modelview matrices to the matrix stack.
        GL.LoadPixelMatrix(0, textureSize, textureSize, 0);
        dst.ReadPixels(new Rect(hlf, hlf, hlf, hlf), hlf, hlf);
        GL.PopMatrix();
        RenderTexture.active = null;
        yield return null;
        dst.Apply();

        RenderTexture.active = null;
        RenderTexture.ReleaseTemporary(rt);
        mat.mainTexture = dst;
        RenderTexture.active = null; // Restore
        yield return null;
        lastInstance.GetComponent<Animator>().Play("Idle", 0, anmTime);
        lastInstance.SetActive(true);
        if (callback != null) callback(lastInstance);
    }

    public Vector3 offset = new Vector3(13f, 1.7f, -70f);

    public byte[] RenderModel(GameObject avatar, int w=320, int h=620) {
        RenderTexture rt = RenderTexture.GetTemporary(w, h, 16, RenderTextureFormat.ARGB32);
        int oldLayer = avatar.layer;
        var oldPosition = avatar.transform.position;
        var oldEscale = avatar.transform.localScale;

        avatar.transform.position = new Vector3(0,-0.91f,-1.77f);
        avatar.transform.localScale = Vector3.one;

        MyTools.SetLayerRecursively(avatar, 31);
        var camera = new GameObject("TmpCamera", typeof(Camera)).GetComponent<Camera>();
        camera.cullingMask = (1 << 31);
        camera.transform.position = Vector3.zero;
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

        avatar.transform.position = oldPosition;
        avatar.transform.localScale = oldEscale;
        MyTools.SetLayerRecursively(avatar, oldLayer);

        return bytes;
    }


    Dictionary<string,object> GetDescriptor(List<object> list, string id) {
        foreach (Dictionary<string, object> ele in list)
            if (ele["id"] as string == id)
                return ele as Dictionary<string, object>;
        return null;
    }

    void Assign(GameObject prefab, Transform target, Material mat) {
        float initTime = Time.realtimeSinceStartup;

        var smrOrg = prefab.GetComponent<SkinnedMeshRenderer>();
        var smrDst = target.GetComponent<SkinnedMeshRenderer>();

        Transform[] bones = smrOrg.bones;
        for (int i = 0; i < bones.Length; ++i)
            bones[i] = SearchHierarchyForBone(target.parent, bones[i].name);
        smrDst.bones = bones;
        smrDst.sharedMesh = Instantiate(smrOrg.sharedMesh);

        Material[] mats = new Material[2];
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
