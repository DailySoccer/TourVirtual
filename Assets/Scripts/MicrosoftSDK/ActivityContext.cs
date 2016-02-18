using UnityEngine;
using System.Collections;

#if UNITY_ANDROID

public class ActivityContext {
	public static AndroidJavaObject CurrentActivity {
		get {
			if (_currentActivity == null) {
				_currentActivity = JavaClass.GetStatic<AndroidJavaObject>("currentActivity");
                if (_currentActivity != null)
                {
                    Debug.Log("MicrosoftSDK::currentActivity");
                }
                else {
                    Debug.LogError("ERROR MicrosoftSDK::currentActivity");
                }
			}
			return _currentActivity;
		}
	}

	private static AndroidJavaClass JavaClass {
		get {
			if (_class == null) {
				_class = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
				if (_class != null) {
					Debug.Log ("MicrosoftSDK::ActivityContext class");
				}
                else
                {
                    Debug.LogError("ERROR MicrosoftSDK::ActivityContext class");
                }
			}
			return _class;
		}
	}
	private static AndroidJavaClass _class;
	private static AndroidJavaObject _currentActivity;
}

#endif
