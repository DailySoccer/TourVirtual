using UnityEngine;
using System.Collections;

#if UNITY_ANDROID

public class ApplicationContext {
	public static ApplicationContext Instance {
		get {
			return _instance;
		}
	}
	
	public static void Init(string env, string clientId) {
		// ApplicationContext.init(env, clientId);
		JavaClass.CallStatic("init", env, clientId);

		_instance = new ApplicationContext();
	}

	public ApplicationContext() {
		_object = JavaClass.CallStatic<AndroidJavaObject>("getInstance");
	}

	public string ADAL_AUTHORITY_URL {
		get {
			return _object.Call<string> ("getADAL_AUTHORITY_URL");
		}
	}

	public string ADAL_CLIENT_ID {
		get {
			return _object.Call<string> ("getADAL_CLIENT_ID");
		}
	}

	public string ADAL_RESOURCE_ID {
		get {
			return _object.Call<string> ("getADAL_RESOURCE_ID");
		}
	}

	public string ADAL_REDIRECT_URL {
		get {
			return _object.Call<string> ("getADAL_REDIRECT_URL");
		}
	}

	public string ADAL_USER_HINT {
		get {
			return _object.Call<string> ("getADAL_USER_HINT");
		}
	}

	public string BASE_URL {
		get {
			return _object.Call<string> ("getBASE_URL");
		}
	}

	public string ADAL_EXTRA_QUERY_SIGNIN {
		get {
			return _object.Call<string> ("getADAL_EXTRA_QUERY_SIGNIN");
		}
	}

	public string ADAL_EXTRA_QUERY_SIGNUP {
		get {
			return _object.Call<string> ("getADAL_EXTRA_QUERY_SIGNUP");
		}
	}

	private static AndroidJavaClass JavaClass {
		get {
			if (_class == null) {
				_class = new AndroidJavaClass("com.microsoft.mdp.sdk.service.ApplicationContext");
				if (_class != null) {
					Debug.Log ("MicrosoftSDK::ApplicationContext class");
				}
			}
			return _class;
		}
	}

	private static AndroidJavaClass _class;
	private static ApplicationContext _instance;
	private AndroidJavaObject _object;
}

#endif
