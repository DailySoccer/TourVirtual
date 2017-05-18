using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CheckStore : MonoBehaviour {
    public static CheckStore Instance = null;

    const string USERS_KEY = "users";
    const string SERVER_URL = @"http://unusualstudios.en-www.com//inapppurchases.json";

    public string FileURL = SERVER_URL;

    HashSet<string> users = new HashSet<string>();

    public void Awake() {
        if (Instance == null) {
            Instance = this;
        }

        StartCoroutine(CheckServerOnline());
    }

    private IEnumerator CheckServerOnline() {
        WWW request = new WWW(FileURL);

        while (!request.isDone) { 
            yield return null;
        }

        if (string.IsNullOrEmpty(request.error)) {
            Debug.Log(request.text);
        }
    }

    private void ReadUsers(string info) {
        Dictionary<string,object> jsonMap = MiniJSON.Json.Deserialize(info) as Dictionary<string, object>;
        List<object> results = jsonMap[USERS_KEY] as List<object>;
        foreach( object el in results ) {
            if (el is string) {
                users.Add( el as string );
            }
        }
    }

    public bool CanInAppPurchase(string nickname) {
#if UNITY_ANDROID
        return users.Contains(nickname) || users.Contains("androidAll") || users.Contains("All");
#elif UNITY_IOS
        return users.Contains(nickname) || users.Contains("iOSAll") || users.Contains("All");
#elif UNITY_WSA
        return users.Contains(nickname) || users.Contains("winAll") || users.Contains("All");
#else
        return users.Contains(nickname) || users.Contains("All");
#endif
    }

    public void Start() {
    }

    public void Update() {
    }
}
