using UnityEngine;
using System.Collections;

public class UserAPI : AzureAPI {

	public delegate void UserLogin();
	public event UserLogin OnUserLogin;

	static public UserAPI Instance {
		get {
			GameObject azureServices = GameObject.FindGameObjectWithTag("AzureServices");
			return azureServices != null ? azureServices.GetComponent<UserAPI>() : null;
		}
	}
	
	public bool IsOk {
		get {
			return !string.IsNullOrEmpty(UserName);
		}
	}

	public string IdUser;
	public string UserName;
	public string ContactEmail;

	new void Start () {
		base.Start ();

		GetComponent<Authentication>().OnAccessToken += HandleOnAccessToken;
	}

	void Update () {
	}

	public IEnumerator GetUserProfile() {
		Debug.Log ("GET USER PROFILE...");

		HTTP.Request request = RequestGet(URL_USER_PROFILE);
		yield return StartCoroutine(RequestSend(request));
		
		object json = JSON.JsonDecode(request.response.Text);
		LoadFromJSON(json);
	}

	private void LoadFromJSON(object json) {
		if (json is Hashtable) {
			Hashtable jsonMap = json as Hashtable;

			if (jsonMap.ContainsKey(KEY_ID_USER)) {
				IdUser = jsonMap[KEY_ID_USER] as string;
			}

			if (jsonMap.ContainsKey(KEY_CONTACT_EMAIL)) {
				ContactEmail = jsonMap[KEY_CONTACT_EMAIL] as string;

				UserName = ContactEmail.Split('@')[0];
			}

			if (OnUserLogin != null) {
				OnUserLogin();
			}
		}
	}

	void HandleOnAccessToken ()	{
		StartCoroutine(GetUserProfile());
	}
		

	private static string URL_USER_PROFILE = "api/v1/fan/me";
	private static string KEY_CONTACT_EMAIL = "ContactEmail";
	private static string KEY_ID_USER = "IdUser";
}
