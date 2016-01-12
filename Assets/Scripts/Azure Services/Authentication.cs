// #define USE_ADAL
#define MICROSOFT_SDK

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Authentication : MonoBehaviour {

	public delegate void AccessTokenEvent();
	public event AccessTokenEvent OnAccessToken;

	static public Authentication Instance {
		get {
			GameObject authenticationObj = GameObject.FindGameObjectWithTag("AzureServices");
			return authenticationObj != null ? authenticationObj.GetComponent<Authentication>() : null;
		}
	}

	public static string WebApiBaseAddress {
		get {
			return "https://rex-dev-euwe-web-api.azurewebsites.net/";
		}
	}

	public bool IsOk {
		get {
			return !string.IsNullOrEmpty(AccessToken);
		}
	}

	public string URLWithCode {
		set {
			_code = extractCodeFromURL(value);
			Debug.Log ("---> Code: " + _code);
		}
	}
	
	public string AccessToken;
	public string RefreshToken;

	void Start () {
		MainManager.Instance.OnInternetConnection += HandleOnInternetConnection;
	}

	void HandleOnInternetConnection () {
		if (!string.IsNullOrEmpty(AccessToken)) {
			return;
		}

		Debug.Log ("Authentication...");

		#if UNITY_ANDROID

		if (Application.platform == RuntimePlatform.Android) {
			#if MICROSOFT_SDK

			/*
			 * Problemas con isDebugBuild y la comparación de cadenas
			// DigitalPlatformClient.init(Context ctx, String env, String clientId)
			DigitalPlatformClient.Init(DigitalPlatformClient.DEVELOPMENT, clientId);
			*/

			// context = new DigitalPlatformClient();
			DigitalPlatformClient digitalPlatformClient = DigitalPlatformClient.Instance;

			// ApplicationContext.init(env, clientId);
			ApplicationContext.Init(DigitalPlatformClient.DEVELOPMENT, clientId);

			// DBContext.initDb(ctx);
			DBContext.InitDb();

			// NetworkHandler.getInstance(ctx);
			NetworkHandler networkHandler = NetworkHandler.Instance;

			// context.setAuthHandler(new AuthHandler(ctx));
			digitalPlatformClient.AuthHandler = AuthHandler.Instance;

			StartCoroutine(WaitAccessToken());

			return;

			#endif
		}

		#if USE_ADAL
		using (var actClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {
			_activityContext = actClass.GetStatic<AndroidJavaObject>("currentActivity");
			
			if (_activityContext != null) {
				Debug.Log ("activityContext...");
			}
		}
		
		AndroidJavaClass authContextClass = new AndroidJavaClass("com.microsoft.aad.adal.AuthenticationContext");
		if (authContextClass != null) {
			Debug.Log ("Version: " + authContextClass.CallStatic<string>("getVersionName"));
		}
		
		// JAVA: public AuthenticationContext(Context appContext, String authority, boolean validateAuthority)
		_authContext = new AndroidJavaObject("com.microsoft.aad.adal.AuthenticationContext", _activityContext, authority, false);
		if (_authContext != null) {
			Debug.Log ("authenticationContext...");
		}

		#else
		_webView = GetComponent<UniWebView>();
		if (_webView != null) {
			_webView.OnLoadComplete += HandleOnLoadComplete;
			_webView.OnLoadBegin += HandleOnLoadBegin;
			_webView.OnReceivedMessage += HandleOnReceivedMessage;
		}
		#endif
		
		#endif

		// Si tenemos un RefreshToken, intentamos usarlo para obtener el AccessToken
		if (!string.IsNullOrEmpty(RefreshToken)) {
			StartCoroutine(GetAccessTokenFromRefreshToken());
		}
		else {
			OnSignUp();
		}
	}

#if UNITY_ANDROID
	private void HandleOnLoadComplete (UniWebView webView, bool success, string errorMessage) {
		Debug.Log ("OnLoadComplete");
		// _webView.Show ();
	}

	private void HandleOnLoadBegin (UniWebView webView, string loadingUrl) {
		Debug.Log ("Authentication: OnLoadBegin: " + loadingUrl);

		if (loadingUrl.Contains("http://localhost/?code=")) {
			string[] parameters = loadingUrl.Split ('?');
			string[] values = parameters[1].Split('=');

			_code = WWW.UnEscapeURL(values[1]);
			Debug.Log ("---> Code: " + _code);

			_webView.Hide ();
		}
	}

	private void HandleOnReceivedMessage(UniWebView webView, UniWebViewMessage message) {
		Debug.Log("Authentication Message: " + message.rawMessage);
	}
#endif

	void Update () {
	}

	/*
	void OnGUI() {
#if USE_ADAL
		if (_authContext == null)
			return;
#endif

		if (string.IsNullOrEmpty(AccessToken) && string.IsNullOrEmpty(RefreshToken)) {
			if (GUI.Button(new Rect(0, Screen.height - 150, 150, 80),"Register")) {
				OnSignUp();
			}

			if (GUI.Button(new Rect(150, Screen.height - 150, 150, 80),"Login")) {
				OnSignIn();
			}

#if UNITY_ANDROID
			if (_code != null && GUI.Button(new Rect(300, Screen.height - 150, 150, 80),"Token")) {
				StartCoroutine(GetAccessToken());
			}
#else
			if (GUI.Button(new Rect(320, Screen.height - 150, 150, 25),"Token")) {
				_code = extractCodeFromURL(_urlCode);
				StartCoroutine(GetAccessToken());
			}

			GUI.Label(new Rect(320, Screen.height - 125, 300, 25), "URL Response: http://localhost/?code=XXX");
			_urlCode = GUI.TextField(new Rect(320, Screen.height - 100, 300, 25), _urlCode);
#endif
		}
	}
	*/

#if UNITY_ANDROID
	public class AuthenticationCallback : AndroidJavaProxy
	{
		public AuthenticationCallback() : base("com.microsoft.aad.adal.AuthenticationCallback") {}

		public void onSuccess(AndroidJavaObject result) {
			Debug.Log("---------> onSuccess: " + result.ToString());
		}
		
		public void onError(AndroidJavaObject exc) {
			Debug.Log("---------> onError: " + exc.ToString());

			string message = exc.Get<string>("Message");
			Debug.Log("---------> onError ++: " + message);
		}

		public int hashCode() {
			return GetHashCode();
		}
	}

#endif

	public void JavaAccessToken(string accessToken) { 
		AccessToken = accessToken;
		Debug.Log ("AccessToken: " + AccessToken);
		
		if (OnAccessToken != null) {
			OnAccessToken();
		}
	}

	private string extractCodeFromURL(string url) {
		string code = "";

		if (url.Contains("http://localhost/?code=")) {
			string[] parameters = url.Split ('?');
			string[] values = parameters[1].Split('=');
			code = WWW.UnEscapeURL(values[1]);
			Debug.Log ("---> Code: " + code);
		}

		return code;
	}

	public void OnSignUp() {
		// https://login.windows.net/common/oauth2/authorize?response_type=id_token&client_id=4ae4904e-e989-4755-8c74-f805d37cc8bd&scope=openid&nonce=7362CAEA-9CA5-4B43-9BA3-34D7C303EBA7&response_mode=form_post
		string parameters = string.Format("?response_type=code&client_id={0}&redirect_uri={1}&resource={2}", clientId, redirectUri, webApiResourceId);
	 	//string extraParameters = "p=B2C_1_SignUp&nonce=defaultNonce&scope=openid&response_mode=form_post";
		string extraParameters = "p=B2C_1_SignUp&nonce=defaultNonce&scope=openid";
		string url = string.Format("{0}/oauth2/authorize{1}&{2}", authority, parameters, extraParameters);
		Debug.Log ("REGISTER: " + url);

#if UNITY_ANDROID

#if USE_ADAL
		// JAVA: public void acquireToken(Activity activity, String resource, String clientId, String redirectUri, String loginHint, String extraQueryParameters, AuthenticationCallback<AuthenticationResult> callback) 
		_authContext.Call("acquireToken", _activityContext, webApiResourceId, clientId, redirectUri, "", extraParameters, new AuthenticationCallback());
#else
		_webView.Load(url);
		_webView.Show();
#endif

#else // NOT ANDROID
		Application.OpenURL(url);
#endif
	}
	
	public void OnSignIn() {
		string parameters = string.Format("?response_type=code&client_id={0}&redirect_uri={1}&resource={2}", clientId, redirectUri, webApiResourceId);
		//string extraParameters = "p=B2C_1_SignIn&nonce=defaultNonce&scope=openid&response_mode=form_post";
		string extraParameters = "p=B2C_1_SignIn&nonce=defaultNonce&scope=openid";
		string url = string.Format("{0}/oauth2/authorize{1}&{2}", authority, parameters, extraParameters);
		Debug.Log ("LOGIN: " + url);

#if UNITY_ANDROID

#if USE_ADAL
		// JAVA: public void acquireToken(Activity activity, String resource, String clientId, String redirectUri, String loginHint, String extraQueryParameters, AuthenticationCallback<AuthenticationResult> callback) 
		_authContext.Call("acquireToken", _activityContext, webApiResourceId, clientId, redirectUri, "", extraParameters, new AuthenticationCallback());
#else
		_webView.Load(url);
		_webView.Show();
#endif

#else // NOT ANDROID
		Application.OpenURL(url);
#endif
	}

	private IEnumerator WaitAccessToken() {
		#if UNITY_ANDROID
		
		if (Application.platform == RuntimePlatform.Android) {
			#if MICROSOFT_SDK

			Debug.Log ("WaitAccessToken...");

			yield return StartCoroutine(DigitalPlatformClient.Instance.InitialAccess());
			// yield return StartCoroutine(DigitalPlatformClient.Instance.SignUp());
			// yield return StartCoroutine(DigitalPlatformClient.Instance.SignIn());
			// yield return StartCoroutine(DigitalPlatformClient.Instance.GetToken());

			AccessToken = DigitalPlatformClient.Instance.AccessToken;
			Debug.Log ("AccessToken: " + AccessToken);
			
			if (OnAccessToken != null) {
				OnAccessToken();
			}

			#endif
		}
		
		#endif

		yield return null;
	}
	
	public void OnToken() {
		StartCoroutine(GetAccessToken());
	}

	private IEnumerator GetAccessToken() {
		// https://login.windows.net/common/oauth2/token

		Debug.Log ("GetAccessToken... " + _code);
		WWWForm form = new WWWForm();
		form.AddField ("resource", webApiResourceId);
		form.AddField ("client_id", clientId);
		form.AddField ("code", _code);
		form.AddField ("grant_type", "authorization_code");
		form.AddField ("redirect_uri", redirectUri);
		string url = string.Format("{0}/oauth2/token?p={1}&nonce=defaultNonce&scope=openid", authority, "B2C_1_SignIn");
		Debug.Log ("ACCES TOKEN: URL: " + url);

		/*
		HTTP.Request request = new HTTP.Request( "post", url, form );
		request.Send();

		while( !request.isDone ) {
			yield return null;
		}

		ProcessTokenResponse(request.response);
		*/

		WWW www = new WWW(url, form);
		yield return www;
		if (string.IsNullOrEmpty(www.error)) {
			ProcessTokenResponse(www.text);
		}
	}

	private IEnumerator GetAccessTokenFromRefreshToken() {
		//string parameters = string.Format("?grant_type=refresh_token&client_id={0}&refresh_token={1}&resource={2}", clientId, RefreshToken, webApiResourceId);
		Debug.Log ("GetAccessTokenFromRefreshToken... " + _code);

		WWWForm form = new WWWForm();
		form.AddField ("resource", webApiResourceId);
		form.AddField ("refresh_token", RefreshToken);
		form.AddField ("grant_type", "refresh_token");
		string url = string.Format("{0}/oauth2/token?p={1}&nonce=defaultNonce&scope=openid", authority, "B2C_1_SignIn");
		Debug.Log ("REFRESH TOKEN: URL: " + url);

		/*
		HTTP.Request request = new HTTP.Request( "post", url, form );
		request.Send();
		
		while( !request.isDone ) {
			yield return null;
		}

		ProcessTokenResponse(request.response);
		*/

		WWW www = new WWW(url, form);
		yield return www;
		if (string.IsNullOrEmpty(www.error)) {
			ProcessTokenResponse(www.text);
		}
	}


	private void ProcessTokenResponse(string text) {
		Debug.Log ("Response: " + text);
		
		object json = JSON.JsonDecode(text);
		
		if (json is Hashtable) {
			Hashtable jsonMap = json as Hashtable;
			if (jsonMap.ContainsKey(KEY_ACCESS_TOKEN)) {
				AccessToken = jsonMap[KEY_ACCESS_TOKEN] as string;
				Debug.Log ("AccessToken: " + AccessToken);

				if (OnAccessToken != null) {
					OnAccessToken();
				}
			}
			if (jsonMap.ContainsKey(KEY_REFRESH_TOKEN)) {
				RefreshToken = jsonMap[KEY_REFRESH_TOKEN] as string;
				Debug.Log ("RefreshToken: " + RefreshToken);
			}
		}
	}


#if UNITY_ANDROID
	UniWebView _webView;
	AndroidJavaObject _activityContext;
	AndroidJavaObject _authContext;
#else
	private string _urlCode = "";
#endif

	private string _code;

	private static string aadInstance = "https://login.microsoftonline.com/{0}";
	private static string tenant = "rmadb2cdev.onmicrosoft.com";
	private static string clientId = "2ab3fdfb-228f-451d-81b2-bdc4e0cc3115";
	
	private static string redirectUri = "http://localhost/";
	private static string authority = string.Format(aadInstance, tenant);
	private static string webApiResourceId = "https://rmaddev.onmicrosoft.com/webapi";
	
	private static string KEY_ACCESS_TOKEN = "access_token";
	private static string KEY_REFRESH_TOKEN = "refresh_token";
}
