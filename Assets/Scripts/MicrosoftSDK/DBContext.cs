using UnityEngine;
using System.Collections;

#if UNITY_ANDROID

public class DBContext {
	public static void InitDb() {
		// DBContext.initDb(ctx);
		JavaClass.CallStatic("initDb", ActivityContext.CurrentActivity);
	}

	private static AndroidJavaClass JavaClass {
		get {
			if (_class == null) {
				_class = new AndroidJavaClass("com.microsoft.mdp.sdk.persistence.DBContext");
				if (_class != null) {
					Debug.Log ("MicrosoftSDK::DBContext class");
				}
			}
			return _class;
		}
	}
	private static AndroidJavaClass _class;
}

#endif
