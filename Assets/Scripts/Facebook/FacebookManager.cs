using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Facebook.Unity;

public class FacebookManager : MonoBehaviour {

	#region Public members
	//public Image LedLogin;
	//public Image LedShare;
	#endregion

	#region Public methods
		/// <summary>
		/// Prompt facebook log in pop up
		/// </summary>
	public void PromptLogIn()
	{
		if (!FB.IsLoggedIn)
		{
			_processedLogIn = false;
			FB.LogInWithReadPermissions(perms, AuthCallback);
		}
		_updateLedLogIn = true;
	}
	/// <summary>
	/// Prompt facebook share link pop up
	/// </summary>
	public void ShareToFacebook()
	{
		if (!_processingThread)
		{
			_processingThread = true;
			StartCoroutine(CheckLogInShare());
		}
	}
	#endregion

	#region MonoBehaviour methods
	void Awake()
	{
		_updateLedLogIn = true;
		_processedLogIn = true;
		_processingThread = false;
		if (!FB.IsInitialized)
		{
			FB.Init(InitCallback, OnHideUnity);
		}
		else
		{
			FB.ActivateApp();
		}
	}
	// Use this for initialization
	void Start()
	{

	}
	// Update is called once per frame
	void Update()
	{
		if (_updateLedLogIn)
		{
			_updateLedLogIn = false;
			//TODO erase this
			PromptLogIn();
			//LedLogin.color = FB.IsLoggedIn ? Color.green : Color.red;
		}
	}
	#endregion

	#region Private methods
	private void InitCallback()
	{
		if (FB.IsInitialized)
		{
			FB.ActivateApp();
		}
		else
		{
			Debug.Log("<color=orange>Failed to Initialize the Facebook SDK</color>");
		}
	}
	private void OnHideUnity(bool isGameShown)
	{
		if (!isGameShown)
		{
			Time.timeScale = 0;
		}
		else
		{
			Time.timeScale = 1;
		}
	}
	private void AuthCallback(ILoginResult result)
	{
		if (FB.IsLoggedIn)
		{
			AccessToken aToken = Facebook.Unity.AccessToken.CurrentAccessToken;
			Debug.Log("<color=orange>" + aToken.UserId + "</color>");
			foreach (string perm in aToken.Permissions)
			{
				Debug.Log("<color=orange>" + perm + "</color>");
			}
		}
		else
		{
			Debug.Log("<color=orange>User cancelled login</color>");
		}
		_updateLedLogIn = true;
		_processedLogIn = true;
	}
	private void ShareCallback(IShareResult result)
	{
		if (result.Cancelled || !string.IsNullOrEmpty(result.Error))
		{
			Debug.Log("<color=orange>ShareLink Error: " + result.Error + "</color>");
			//LedShare.color = Color.red;
		}
		else if (!string.IsNullOrEmpty(result.PostId))
		{
			Debug.Log("<color=orange>" + result.PostId + "</color>");
			//LedShare.color = Color.green;
		}
		else
		{
			Debug.Log("<color=orange>ShareLink success!</color>");
			//LedShare.color = Color.green;
		}
	}
	private IEnumerator CheckLogInShare()
	{
		if (!FB.IsLoggedIn)
		{
			PromptLogIn();
			while (!_processedLogIn)
			{
				yield return new WaitForSeconds(0.1f);
			}
		}
		if (FB.IsLoggedIn)
		{
			FB.ShareLink(new System.Uri("https://www.unusualwonder.com/"), callback: ShareCallback);
		}
		_processingThread = false;
	}
	#endregion

	#region Private members
	private List<string> perms = new List<string>() { "public_profile", "email", "user_friends" };
	private bool _updateLedLogIn;
	private bool _processedLogIn;
	private bool _processingThread;
	#endregion
}
