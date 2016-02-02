using UnityEngine;
using System.Collections;

public class UserAPI : AzureAPI {

	public delegate void UserLogin();
	public event UserLogin OnUserLogin;

	static public UserAPI Instance { get; private set; }	
	public bool IsOk { get { return !string.IsNullOrEmpty(UserName); } }

	public string IdUser;
	public string UserName;
	public string ContactEmail;

    void Awake() { Instance = this; }

	new void Start () {
		base.Start ();
		GetComponent<Authentication>().OnAccessToken += HandleOnAccessToken;
	}

	public IEnumerator GetUserProfile() {
		HTTP.Request request = RequestGet("api/v1/fan/me");
		yield return StartCoroutine(RequestSend(request));
		object json = JSON.JsonDecode(request.response.Text);
        if (json is Hashtable) {
            Hashtable jsonMap = json as Hashtable;
            if (jsonMap.ContainsKey("IdUser"))          IdUser = jsonMap["IdUser"] as string;
            if (jsonMap.ContainsKey("Alias"))           UserName = jsonMap["Alias"] as string;
            if (jsonMap.ContainsKey("ContactEmail"))    ContactEmail = jsonMap["ContactEmail"] as string;
        }
	}


    public IEnumerator GetAvatarProfile()
    {
        HTTP.Request request = RequestGet("api/v1/fan/me/ProfileAvatar");
        yield return StartCoroutine( RequestSend(request) );
        object json = JSON.JsonDecode(request.response.Text);
        if (json is Hashtable) {
            Debug.LogError("GetAvatarProfile OK");
            Hashtable jsonMap = json as Hashtable;
            //            if (jsonMap.ContainsKey("IdUser")) IdUser = jsonMap["IdUser"] as string;
            //            if (jsonMap.ContainsKey("PictureUrl")) IdUser = jsonMap["PictureUrl"] as string;

            if (jsonMap.ContainsKey("PhysicalProperties")) {
                ArrayList PhysicalProperties = jsonMap["PhysicalProperties"] as ArrayList;
                foreach(Hashtable entry in PhysicalProperties) {
                    if (entry.ContainsKey("Type")) IdUser = jsonMap["Type"] as string;
                    if (entry.ContainsKey("Version")) IdUser = jsonMap["Version"] as string;
                    if (entry.ContainsKey("Data")) IdUser = jsonMap["Data"] as string;

                }
            }
            if (jsonMap.ContainsKey("Accesories")) {
                ArrayList Accesories = jsonMap["Accesories"] as ArrayList;
                foreach (Hashtable entry in Accesories) {
                    if (entry.ContainsKey("IdVirtualGood")) IdUser = jsonMap["IdVirtualGood"] as string;
                    if (entry.ContainsKey("Type")) IdUser = jsonMap["Type"] as string;
                    if (entry.ContainsKey("Version")) IdUser = jsonMap["Version"] as string;
                    if (entry.ContainsKey("Data")) IdUser = jsonMap["Data"] as string;
                }
            }
        }
        else {
        // Crear AvatarProfile por defecto.
            Debug.LogError("GetAvatarProfile ERROR");
        }
    }


    void HandleOnAccessToken ()	{
        StartCoroutine( RequestInfo() );
	}

    IEnumerator RequestInfo() {
        yield return StartCoroutine(GetUserProfile());
        yield return StartCoroutine(GetAvatarProfile());
        if (OnUserLogin != null) OnUserLogin();
    }
}
