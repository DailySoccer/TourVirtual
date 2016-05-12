using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIGameScreen : GUIScreen {

	public Text RoomTitle;
    public Transform ButtonContainer;
	public GameObject CommunityManagerMessage;
	
	public override void Awake () {
		base.Awake ();
		RoomManager.Instance.OnSceneReady += HandleOnSceneChange;
		ChatManager.Instance.OnMessagesChange += Messages_OnChangeHandle;
		CommunityManagerMessage.SetActive (false);
	}
	
	public override void Start () {
		base.Start ();
		_viewContentButton = ButtonContainer.FindChild("View Button").gameObject;
		_viewContentButtonController = _viewContentButton.GetComponent<ContentButtonController> ();

        //_shopContentButton = ButtonContainer.transform.FindChild("Buy Button").gameObject;
		//_shopContentButtonController = _shopContentButton.GetComponent<ContentButtonController> ();

        _playContentButton = ButtonContainer.transform.FindChild("Play Button").gameObject;
		_playContentButtonController = _playContentButton.GetComponent<ContentButtonController> ();

        UpdateRoomTitle();
	}

	void HandleOnSceneChange () {
		UpdateRoomTitle();
	}

	void UpdateRoomTitle() {
		if (RoomManager.Instance.Room != null) {
			RoomTitle.text = RoomManager.Instance.Room.Name;
		}
	}
	
	void OnEnable() {
	}
	
	void UpdateTitle() {
		GameObject titleObj = GameObject.Find ("Level Name");
		if (titleObj != null) {
			titleObj.GetComponent<Animator>().SetBool("IsOpen", true);
		}
	}
	
	public override void CloseWindow() {
		GameObject titleObj = GameObject.Find ("Level Name");
		if (titleObj != null) {
			if (titleObj.GetComponent<Animator>().GetBool("IsOpen"))
				titleObj.GetComponent<Animator>().SetBool("IsOpen", false);
		}
	}

    public override void Update()
    {
        base.Update();

        bool activateView = NeedViewButton;

        if (_viewContentButton != null && _viewContentButton.activeSelf != activateView) {

            _viewContentButton.SetActive(activateView);

            if (activateView) {
                _viewContentButton.transform.localPosition = Vector3.zero;

				if (_viewContentButtonController.InCloseState)
					_viewContentButtonController.IsOpen = true;

            }
			else {
				if (_viewContentButtonController.InOpenState)
					_viewContentButtonController.IsOpen = false;
			}
        }

        bool activatePlay = NeedPlayButton;
        if (_playContentButton != null &&
            _playContentButton.activeSelf != activatePlay)
        {
            _playContentButton.SetActive(activatePlay);

            if (activatePlay)
            {
                _playContentButton.transform.localPosition = Vector3.zero;
				if (_playContentButtonController.InCloseState)
					_playContentButtonController.IsOpen = true;
            }
			else {
				if (_playContentButtonController.InOpenState)
					_playContentButtonController.IsOpen = false;
			}
        }
    }
	
	bool NeedViewButton {
		get {
            return ContentManager.Instance.ContentNear && !ContentManager.Instance.ContentNear.ContentKey.Contains("JUEGO");
		}
	}

    bool NeedShopButton {
        get {
            return ContentInfo.ContentSelected != null && ContentInfo.ContentSelected.Money;
        }
    }

    bool NeedPlayButton {
        get {
            return ContentManager.Instance.ContentNear && ContentManager.Instance.ContentNear.ContentKey.Contains("JUEGO") && !HiddenObjects.HiddenObjects.Instance.enabled;
        }
    }

	void Messages_OnChangeHandle(string channelName) {
		if (channelName == ChatManager.CHANNEL_COMMUNITYMANAGER) {
			int msgCount = ChatManager.Instance.GetMessagesFromChannel(channelName).Count;
			string msg = ChatManager.Instance.GetMessagesFromChannel(channelName)[msgCount -1].Text; 
			CommunityManagerMessage.SetActive (true);
			CommunityManagerMessage.GetComponent<CommunityNotificationController>().SetMessage(msg);
		}
	}

    GameObject _viewContentButton;
	ContentButtonController _viewContentButtonController;

    GameObject _playContentButton;
	ContentButtonController _playContentButtonController;
}
