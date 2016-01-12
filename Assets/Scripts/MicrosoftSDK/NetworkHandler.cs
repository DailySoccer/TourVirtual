using UnityEngine;
using System.Collections;

#if UNITY_ANDROID

public class NetworkHandler {
	public static NetworkHandler Instance {
		get {
			if (_instance == null) {
				_instance = new NetworkHandler();
			}
			return _instance;
		}
	}

	public NetworkHandler() {
		// NetworkHandler.getInstance(ctx);
		_object = JavaClass.CallStatic<AndroidJavaObject>("getInstance", ActivityContext.CurrentActivity);
	}

	private static AndroidJavaClass JavaClass {
		get {
			if (_class == null) {
				_class = new AndroidJavaClass("com.microsoft.mdp.sdk.network.NetworkHandler");
				if (_class != null) {
					Debug.Log ("MicrosoftSDK::NetworkHandler class");
				}
			}
			return _class;
		}
	}
	private static AndroidJavaClass _class;
	private static NetworkHandler _instance;
	private AndroidJavaObject _object;
}

#endif
