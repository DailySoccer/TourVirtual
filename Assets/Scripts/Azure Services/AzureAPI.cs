using UnityEngine;
using System.Collections;

public class AzureAPI : MonoBehaviour {

	public bool AuthorizationValid { get { return Authentication.Instance != null && Authentication.Instance.IsOk; } }
	protected string AccessToken { get { return Authentication.Instance != null ? Authentication.Instance.AccessToken : "<AccessToken Invalid>"; } }

	protected string MainLanguage {
		get {
			string language = DEFAULT_LANGUAGE;
			if (MainManager.Instance != null) {
				switch (MainManager.Instance.CurrentLanguage) {
				case "es": language = SPANISH_LANGUAGE; break;
				case "en": language = ENGLISH_LANGUAGE; break;
				}
			}
			return language;
		}
	}
	
	protected void Start () {
	}

	protected void AddAuthorization(HTTP.Request request) {
		string scheme = "Bearer";
		string authorization = string.Format ("{0} {1}", scheme, AccessToken);
		request.AddHeader("Authorization", authorization);
		Debug.Log ("Authorization: " + authorization);
	}

    protected HTTP.Request RequestGet(string url){
        HTTP.Request request = new HTTP.Request("get", string.Format("{0}{1}", Authentication.WebApiBaseAddress, url));
        AddAuthorization(request);
        return request;
    }

    protected HTTP.Request RequestPost(string url, WWWForm form) {
        HTTP.Request request = new HTTP.Request("post", string.Format("{0}{1}", Authentication.WebApiBaseAddress, url), form);
        AddAuthorization(request);
        return request;
    }

    protected HTTP.Request RequestPost(string url, byte[] form) {
        HTTP.Request request = new HTTP.Request("post", string.Format("{0}{1}", Authentication.WebApiBaseAddress, url), form);
        AddAuthorization(request);
        return request;
    }

    protected HTTP.Request RequestPut(string url, WWWForm form) {
        HTTP.Request request = new HTTP.Request("put", string.Format("{0}{1}", Authentication.WebApiBaseAddress, url), form);
        AddAuthorization(request);
        return request;
    }

    protected HTTP.Request RequestPut(string url, byte[] form) {
        HTTP.Request request = new HTTP.Request("put", string.Format("{0}{1}", Authentication.WebApiBaseAddress, url), form);
        AddAuthorization(request);
        return request;
    }

    protected IEnumerator RequestSend(HTTP.Request request) {
		request.Send();
		
		while( !request.isDone ) {
			yield return null;
		}

		Debug.Log ("AzureAPI: " + request.response.Text);
	}

	private const string SPANISH_LANGUAGE = "es-es";
	private const string ENGLISH_LANGUAGE = "en-us";
	private const string DEFAULT_LANGUAGE = SPANISH_LANGUAGE;
}
