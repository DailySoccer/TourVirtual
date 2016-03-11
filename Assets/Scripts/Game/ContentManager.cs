#if !LITE_VERSION

using UnityEngine;
using System.Collections.Generic;

public class ContentManager: MonoBehaviour
{
	public GameObject Model3DView;

	static public ContentManager Instance {
		get {
			GameObject mainManagerObj = GameObject.FindGameObjectWithTag("MainManager");
			return mainManagerObj != null ? mainManagerObj.GetComponent<ContentManager>() : null;
		}
	}

	public ContentList ContentNear = null;

	public Camera ModelViewCamera {
		get {
			return transform.FindChild("ModelView").GetComponent<Camera>();
		}
	}

	public Dictionary<string, List<CompactContent>> CompactContents = new Dictionary<string, List<CompactContent>>();

	void Start () {
//		base.Start ();
		if (RoomManager.Instance != null) {
			RoomManager.Instance.OnSceneReady += HandleOnSceneReady;
		}
	}

	void HandleOnSceneReady () {
		if (MainManager.Instance.InternetConnection) {
			StartCoroutine(PreloadContents());
		}
	}

    System.Collections.IEnumerator PreloadContents() {
		ContentList[] contentLists = GameObject.FindObjectsOfType<ContentList>();
		foreach(ContentList contentList in contentLists) {
			yield return StartCoroutine(contentList.LoadContents());
		}
	}
	
	void Update () {
	}

	public System.Collections.IEnumerator GetContentItem(string contentId) {
        yield return Authentication.AzureServices.AwaitableRequestGet(string.Format("api/v1/content/{0}", contentId), (res) => {
            Debug.LogError("GetContentItem " + res);
        });
	}

	public List<CompactContent> GetCompactContentsByKey(string contentKey) {
		string contentType = RoomManager.Instance.Room.Content(contentKey);
		return GetCompactContentsByType(contentType);
	}

	public List<CompactContent> GetCompactContentsByType(string contentType) {
		string key = GetContentTypeWithLanguage(Authentication.AzureServices.MainLanguage, contentType);
		return CompactContents.ContainsKey(key) ? CompactContents[key] : new List<CompactContent>();
	}

	public System.Collections.IEnumerator LoadContentsByKey(string contentKey) {
		if (Authentication.Instance.IsOk) {
			string contentType = RoomManager.Instance.Room.Content(contentKey);
			string key = GetContentTypeWithLanguage(Authentication.AzureServices.MainLanguage, contentType);
			if (!CompactContents.ContainsKey(key)) {
				yield return StartCoroutine(LoadContents(contentType));
			}
		}
	}

	public System.Collections.IEnumerator LoadContentsByType(string contentType) {
		if (Authentication.Instance.IsOk) {
			string key = GetContentTypeWithLanguage(Authentication.AzureServices.MainLanguage, contentType);
			if (!CompactContents.ContainsKey(key)) {
				yield return StartCoroutine(LoadContents(contentType));
			}
		}
	}

	public GameObject GetModel3DInstance(GameObject modelPrefab) {
		int instanceId = modelPrefab.GetInstanceID();
		if (!_model3DInstances.ContainsKey(instanceId)) {
			GameObject go = GameObject.Instantiate(modelPrefab);
			go.AddComponent<DontDestroyOnLoad>();
			_model3DInstances.Add (instanceId, go);
		}
		return _model3DInstances[instanceId];
	}

	public System.Collections.IEnumerator GetTexture2DInstance(string imageUrl, System.Action<Texture2D> callback) {
		if (_texture2DInstances.ContainsKey(imageUrl)) {
			Debug.Log ("Texture2D Cached: " + imageUrl);
			callback(_texture2DInstances[imageUrl]);
			yield break;
		}

		// Start a download of the given URL
		var www = new WWW(imageUrl);
		
		// wait until the download is done
		yield return www;

		_texture2DInstances[imageUrl] = www.texture;
		Debug.Log ("Texture2D Loaded: " + imageUrl);

		callback(www.texture);
	}

	private System.Collections.IEnumerator LoadContents(string contentType) {
        int page = 0;
		int pageCount = 1;

		string language = Authentication.AzureServices.MainLanguage;
		List<CompactContent> contents = new List<CompactContent>();
		while (page < pageCount) {
			page++;
			Debug.Log ("GetListContentType: Page: " + page);
            yield return Authentication.AzureServices.AwaitableRequestGet(string.Format(URL_LIST_CONTENT_BY_TYPE, contentType, language, page), (res) => {
                Dictionary<string,object> jsonMap = BestHTTP.JSON.Json.Decode(res) as Dictionary<string, object>;
                List<object> results = jsonMap[KEY_RESULTS] as List<object>;
                foreach (object result in results) {
                    CompactContent compactContent = CompactContent.LoadFromJSON(result);
                    contents.Add(compactContent);
                    // StartCoroutine(GetContentItem(compactContent.IdContent));
                }
                page = (int)(double)jsonMap[KEY_CURRENT_PAGE];
                pageCount = (int)(double)jsonMap[KEY_PAGE_COUNT];
            });
		}

		string key = GetContentTypeWithLanguage(language, contentType);
		CompactContents.Add (key, contents);
		Debug.Log ("LoadContents: " + key);
	}

	private string GetContentTypeWithLanguage(string language, string contentType) {
		return string.Format ("{0}-{1}", language, contentType);
	}

	Dictionary<int, GameObject> _model3DInstances = new Dictionary<int, GameObject>();
	Dictionary<string, Texture2D> _texture2DInstances = new Dictionary<string, Texture2D>();

	private static string URL_GET_CONTENT_ITEM = "api/v1/content/{0}";
	private static string URL_LIST_CONTENT_BY_TYPE = "api/v1/content/{0}?language={1}&ct={2}";
	private static string KEY_RESULTS = "Results";
	private static string KEY_CURRENT_PAGE = "CurrentPage";
	private static string KEY_PAGE_COUNT = "PageCount";
}

#endif