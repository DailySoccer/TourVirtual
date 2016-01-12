using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MenuManager : MonoBehaviour {
	public GameObject AuthenticationUI;
	public GameObject ContentListUI;
	public GameObject ContentItem;
	public UserUI UserUI;

	public enum EContentType {
		None,
		News,
		Videos,
		FootBallNews,
		BasketNews,
		FootBallVideos,
		BasketVideos,	
		GamesWindows,
		GamesWP,
		GamesIOS,	
		GamesAndroid,
		Resource
	}

	public EContentType ContentType;

	void Start () {
		GameObject azureServices = GameObject.FindGameObjectWithTag("AzureServices");
		_authentication = azureServices.GetComponent<Authentication>();
		_user = azureServices.GetComponent<UserAPI>();
		_contents = GetComponent<ContentList>();

		_authentication.OnAccessToken += HandleAccessToken;
		_user.OnUserLogin += HandleOnUserLogin;

		if (string.IsNullOrEmpty(_authentication.RefreshToken)) {
			AuthenticationUI.SetActive(true);
		}
	}

	void Update () {
	}

	void HandleOnUserLogin () {
		if (_user.IsOk) {
			UserUI.gameObject.SetActive(true);
			UserUI.Name.text = _user.UserName;
		}
	}
	
	public void HandleAccessToken () {
		AuthenticationUI.SetActive(!_authentication.IsOk);
		StartCoroutine(LoadContents());
	}

	IEnumerator LoadContents() {
		yield return StartCoroutine(_contents.LoadContents(ContentType.ToString()));

		ContentListUI.SetActive(true);
		GameObject header = ContentListUI.transform.FindChild("Header").gameObject;
		GameObject headerText = header.transform.FindChild ("Text").gameObject;
		headerText.GetComponent<Text>().text = ContentType.ToString();
		
		GameObject scroll = ContentListUI.transform.FindChild("Scroll View").gameObject;
		Transform contentPanel = scroll.transform.FindChild("Content Panel");
		
		foreach(CompactContent item in _contents.CompactContents) {
			if (!_compactContents.ContainsKey(item.IdContent)) {
				GameObject newContent = Instantiate(ContentItem) as GameObject;
				ContentItem contentItem = newContent.GetComponent<ContentItem>();
				contentItem.Set (item);
				newContent.transform.SetParent(contentPanel);
				_compactContents.Add (item.IdContent, true);
			}
		}
	}

	Hashtable _compactContents = new Hashtable();

	Authentication _authentication;
	UserAPI _user;
	ContentList _contents;
}
