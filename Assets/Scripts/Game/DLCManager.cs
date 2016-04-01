﻿using UnityEngine;
using System.Collections.Generic;
using SmartLocalization;

public class AssetDefinition {
	public string Id;
    public int Version;

	public AssetDefinition(string id, int version) {
		Id = id;
		Version = version;
        // Debug.Log (string.Format("AssetDefinition: Id: {0} Version: {1}", Id, Version));
    }
	
	static public AssetDefinition LoadFromJSON(Dictionary<string, object> jsonMap) {
		AssetDefinition assetDefinition = new AssetDefinition(
			jsonMap[KEY_ID] as string,
			System.Convert.ToInt32(jsonMap[KEY_VERSION])
            );
		return assetDefinition;
	}
	
	const string KEY_ID = "id";
    const string KEY_VERSION = "version";
}

public class DLCManager : MonoBehaviour {
	static public DLCManager Instance {
		get {
			GameObject mainManagerObj = GameObject.FindGameObjectWithTag("MainManager");
			if (mainManagerObj == null)
				return null;

			DLCManager dlcManager = mainManagerObj.GetComponent<DLCManager>();
			return dlcManager.enabled ? dlcManager : null;
		}
	}
	
	public TextAsset Assets;
	string AssetsUrl;
	public Dictionary<string, AssetDefinition> AssetDefinitions = new Dictionary<string, AssetDefinition>();
	public Dictionary<string, AssetBundle> AssetResources = new Dictionary<string, AssetBundle>();

	string BaseUrl {
		get {
#if UNITY_ANDROID
			return AssetsUrl + "/Android/";
#elif UNITY_IOS
			return AssetsUrl + "/iOS/";
#else
			return AssetsUrl + "/Windows/";
#endif
		}
	}

	void Awake () {
#if UNITY_EDITOR
//        AssetsUrl = "file://" + Application.dataPath  + "/WebPlayerTemplates/AssetBundles";
        //        AssetsUrl = "https://12351.wpc.azureedge.net/8012351/rmdevtourcdn.blob.core.windows.net/virtualtour-assets";
        AssetsUrl = "https://rmdevcdntour.blob.core.windows.net/virtualtour-assets";
#else
#if PRE
            AssetsUrl = "https://az879424.vo.msecnd.net/virtualtour-assets";
#else
#if PRO
                AssetsUrl = "https://az878819.vo.msecnd.net/virtualtour-assets";
#else
                AssetsUrl = "https://rmdevcdntour.blob.core.windows.net/virtualtour-assets";
#endif
#endif
#endif


    }

    void Start () {
	}
	
	void Update () {
        if (current != null){
            if (LoadingBar.Instance.isHide) LoadingBar.Instance.Show();
            LoadingBar.Instance.SetValue(current.progress, currentName);
        }
    }

	public void ClearResources() {
		foreach(string key in AssetResources.Keys) {
			AssetBundle bundle = AssetResources[key];
			bundle.Unload(true);
		}
		AssetResources.Clear();
	}

    public System.Collections.IEnumerator LoadVersion()
    {
        using (WWW www = new WWW(BaseUrl + "assetbundles.json"))
        {
            yield return www;
            if (string.IsNullOrEmpty(www.error))
            {
                Dictionary<string, object> jsonMap = BestHTTP.JSON.Json.Decode(www.text) as Dictionary<string, object>;
                List<object> assets = jsonMap[KEY_ASSETS] as List<object>;
                foreach (Dictionary<string, object> asset in assets)
                {
                    AssetDefinition assetDefinition = AssetDefinition.LoadFromJSON(asset);
                    if (!assetDefinition.Id.Contains("content"))
                    {
#if LITE_VERSION
                        if (assetDefinition.Id == "avatars")
#endif
                            AssetDefinitions.Add(assetDefinition.Id, assetDefinition);
                    }
                }
            }
            else {
                ModalTextOnly.ShowText(LanguageManager.Instance.GetTextValue("TVB.Error.NetError"),()=> { Application.Quit(); });
            }
        }
        //

    }

    WWW current;
    string currentName;

    public System.Collections.IEnumerator LoadResource(string keyResource, System.Action<AssetBundle> callback = null) {
        if (!AssetDefinitions.ContainsKey(keyResource)) {
			yield break;
		}

		if (AssetResources.ContainsKey(keyResource)) {
			if (callback != null) callback(AssetResources[keyResource]);
            yield break;
		}

        // Wait for the Caching system to be ready
        while (!Caching.ready)
			yield return null;

		AssetDefinition definition = AssetDefinitions[keyResource];

		// Ignoramos las versiones 0...
		if (definition.Version > 0)
        {
            currentName = definition.Id;
            // Load the AssetBundle file from Cache if it exists with the same version or download and store it in the cache
            using (current = WWW.LoadFromCacheOrDownload(BaseUrl + definition.Id, definition.Version)) {
				yield return current;
                if (string.IsNullOrEmpty(current.error)) {
					AssetBundle bundle = current.assetBundle;
					bundle.LoadAllAssets();
					AssetResources[keyResource] = bundle;
                    if (callback != null) callback(bundle);
				}
				else {
                    ModalTextOnly.ShowText(LanguageManager.Instance.GetTextValue("TVB.Error.NetError"), () => { Application.Quit(); });
                    // throw new Exception("WWW download had an error:" + www.error);
                }
			} // memory is freed from the web stream (www.Dispose() gets called implicitly)
            current = null;
        }
        LoadingBar.Instance.Hide();
    }


    public System.Collections.IEnumerator CacheResources() {
        // Wait for the Caching system to be ready
        while (!Caching.ready)
			yield return null;

		foreach(string key in AssetDefinitions.Keys) {
			AssetDefinition definition = AssetDefinitions[key];
            if (definition.Id != "scene/vestidor" && definition.Id != "avatars") continue;

            // Ignoramos las versiones 0...
            if (definition.Version > 0){
                currentName = definition.Id;
                // Load the AssetBundle file from Cache if it exists with the same version or download and store it in the cache
                LoadingBar.Instance.Show();
                using (current = WWW.LoadFromCacheOrDownload ( BaseUrl + definition.Id, definition.Version)) {
					yield return current;
                    if (string.IsNullOrEmpty(current.error)) {
						AssetBundle bundle = current.assetBundle;
						bundle.Unload(true);
                    }
					else {
                        ModalTextOnly.ShowText(LanguageManager.Instance.GetTextValue("TVB.Error.NetError"), () => { Application.Quit(); });
                        // throw new Exception("WWW download had an error:" + www.error);
                    }
				} // memory is freed from the web stream (www.Dispose() gets called implicitly)
                current = null;
            }
        }
        LoadingBar.Instance.Hide();
        current = null;

    }
	
	const string KEY_ASSETS = "assets";
}
