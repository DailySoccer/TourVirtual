using UnityEngine;
using System.Collections;

#if UNITY_ANDROID

public class AuthHandler {
	public static string AccessToken;

	public static AuthHandler Instance {
		get {
			return new AuthHandler();
		}
	}

	public AndroidJavaObject JavaObject {
		get {
			return _object;
		}
	}

	public AuthHandler() {
		// new AuthHandler(Context ctx)
		_object = new AndroidJavaObject("com.microsoft.mdp.sdk.auth.AuthHandler", ActivityContext.CurrentActivity);
		if (_object != null) {
			Debug.Log ("MicrosoftSDK::AuthHandler new");
		}

		_authContext = _object.Get<AndroidJavaObject>("authContext");
	}

	public AuthHandler(AndroidJavaObject authHandler) {
		_object = authHandler;
		_authContext = _object.Get<AndroidJavaObject>("authContext");
	}

	public void InitialAccess() {
		AndroidJavaClass authenticationClass = new AndroidJavaClass("com.unusualwonder.tourvirtualBernabeu.RegistryActivity");
		_object.Call ("initialAccess", ActivityContext.CurrentActivity, authenticationClass, new AuthListenerCallback());
	}

	public void SignUp() {
		// login(final Activity activity, final AuthListener listener, boolean isRegister)
		_object.Call ("login", ActivityContext.CurrentActivity, new AuthListenerCallback(), true);
	}

	public void SignIn() {
		// login(final Activity activity, final AuthListener listener, boolean isRegister)
		_object.Call ("login", ActivityContext.CurrentActivity, new AuthListenerCallback(), false);
	}

	public void GetToken() {
		// void getToken(final AuthListener listener)
		_object.Call ("getToken", new AuthListenerCallback());
	}

	public string GetSilentBearerSyncNoUI() {
		// String getSilentBearerSyncNoUI(Context ctx) throws DigitalPlatformClientException
		return _object.Call<string> ("getSilentBearerSyncNoUI", ActivityContext.CurrentActivity);
	}

	public void AcquireTokenWithSignIn() {
		_callback = new AuthenticationCallback();

		// _authContext.Call("acquireToken", _activityContext, webApiResourceId, clientId, redirectUri, "", extraParameters, new AuthenticationCallback());
		_authContext.Call("acquireToken", 
		                  ActivityContext.CurrentActivity, 
		                  ApplicationContext.Instance.ADAL_RESOURCE_ID, 
		                  ApplicationContext.Instance.ADAL_CLIENT_ID, 
		                  ApplicationContext.Instance.ADAL_REDIRECT_URL, 
		                  ApplicationContext.Instance.ADAL_USER_HINT, 
		                  ApplicationContext.Instance.ADAL_EXTRA_QUERY_SIGNIN, 
		                  _callback);
	}

	public class AuthListenerCallback : AndroidJavaProxy
	{
		public AuthListenerCallback() : base("com.microsoft.mdp.sdk.auth.AuthListener") {}

		public void onResponse(string paramString) {
			AccessToken = paramString;
			Debug.Log("---------> onSuccess: " + paramString);
		}

		public void onResponse(AndroidJavaObject paramString) {
			// AccessToken = paramString;
			Debug.Log("---------> onSuccess: " + paramString.ToString());
		}

		public void onError(AndroidJavaObject exc) {
			Debug.Log("---------> onError: " + exc.Call<string>("getMessage"));
		}
	}

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

	private static AndroidJavaClass JavaClass {
		get {
			if (_class == null) {
				_class = new AndroidJavaClass("com.microsoft.mdp.sdk.auth.AuthHandler");
				if (_class != null) {
					Debug.Log ("MicrosoftSDK::AuthHandler class");
				}
			}
			return _class;
		}
	}
	private static AndroidJavaClass _class;

	private AndroidJavaObject _object;
	private AndroidJavaObject _authContext;

	AuthenticationCallback _callback;
}

#endif
