using UnityEngine;
using System.Collections;

#if UNITY_ANDROID

public class DigitalPlatformClient {

	public static string PREPRODUCTION {
		get {
			return JavaClass.GetStatic<string>("PREPRODUCTION");
		}
	}

	public static string DEVELOPMENT {
		get {
			return JavaClass.GetStatic<string>("DEVELOPMENT");
		}
	}

	public static DigitalPlatformClient Instance {
		get {
			if (_instance == null) {
				_instance = new DigitalPlatformClient();
			}
			return _instance;
		}
	}

	public string AccessToken {
		get {
			return AuthHandler.AccessToken;
		}
	}

	public AuthHandler AuthHandler {
		get {
			return _authHandler;
		}

		set {
			_authHandler = value;

			// context.setAuthHandler(new AuthHandler(ctx));
			_object.Call("setAuthHandler", _authHandler.JavaObject);
		}
	}

	public DigitalPlatformClient() {
		_object = JavaClass.CallStatic<AndroidJavaObject>("getInstance");
	}

	public DigitalPlatformClient(AuthHandler authHandler) {
		_object = JavaClass.CallStatic<AndroidJavaObject>("getInstance");
		
		AndroidJavaObject authHandlerObject = JavaClass.Call<AndroidJavaObject>("getAuthHandler");
		_authHandler = new AuthHandler(authHandlerObject);
	}

	public static void Init(string env, string clientId) {
		// DigitalPlatformClient.init(Context ctx, String env, String clientId)
		JavaClass.CallStatic("init", ActivityContext.CurrentActivity, env, clientId);

		_instance = new DigitalPlatformClient();
	}

	public IEnumerator InitialAccess() {
		AuthHandler.InitialAccess();
		while(string.IsNullOrEmpty(AuthHandler.AccessToken)) {
			yield return null;
		}
	}

	public IEnumerator SignUp() {
		AuthHandler.SignUp();
		while(string.IsNullOrEmpty(AuthHandler.AccessToken)) {
			yield return null;
		}
	}
	
	public IEnumerator SignIn() {
		AuthHandler.SignIn();
		// AuthHandler.AcquireTokenWithSignIn();
		while(string.IsNullOrEmpty(AuthHandler.AccessToken)) {
			yield return null;
		}
	}

	public IEnumerator GetToken() {
		AuthHandler.GetToken();
		while(string.IsNullOrEmpty(AuthHandler.AccessToken)) {
			yield return null;
		}
	}

	private static AndroidJavaClass JavaClass {
		get {
			if (_class == null) {
				_class = new AndroidJavaClass("com.microsoft.mdp.sdk.DigitalPlatformClient");
				if (_class != null) {
					Debug.Log ("MicrosoftSDK::DigitalPlatformClient class");
				}
			}
			return _class;
		}
	}
	private static AndroidJavaClass _class;

	private static DigitalPlatformClient _instance;
	private AndroidJavaObject _object;
	private AuthHandler _authHandler;
}

#endif
