using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIGameScreen : GUIScreen {

	public Text RoomTitle;
	
	public override void Awake () {
		base.Awake ();
		RoomManager.Instance.OnSceneReady += HandleOnSceneChange;
	}
	
	public override void Start () {
		base.Start ();
		_viewContentButton = GameObject.Find("View Content Button").transform.FindChild("View Button").gameObject;
		_shopContentButton = GameObject.Find("View Content Button").transform.FindChild("Buy Button").gameObject;
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
	
	public override void OpenWindow() {
		GameObject titleObj = GameObject.Find ("Top Center Menu").gameObject;
		if (titleObj != null) {
			titleObj.GetComponent<Animator>().SetBool("IsOpen", false);
		}
	}
	
	public override void CloseWindow() {
		GameObject titleObj = GameObject.Find ("Top Center Menu").gameObject;
		if (titleObj != null) {
			titleObj.GetComponent<Animator>().SetBool("IsOpen", true);
		}
	}
	
	public override void Update () {
		base.Update ();
		
		bool activateView = NeedViewButton;

		if (_viewContentButton != null &&
		    _viewContentButton.activeSelf != activateView) {

			_viewContentButton.SetActive(activateView);
			
			if (activateView) {
				_viewContentButton.transform.localPosition = Vector3.zero;
				_viewContentTween = Go.from (
					_viewContentButton.transform, 2, new GoTweenConfig()
					.position(_viewContentButton.transform.position + new Vector3(300,0,0))
					.setEaseType(GoEaseType.ElasticOut)
					);
			}
		}

		bool activateShop = NeedShopButton;
		if (_shopContentButton != null &&
		    _shopContentButton.activeSelf != activateShop) {
			
			_shopContentButton.SetActive(activateShop);
			
			if (activateShop) {
				_shopContentButton.transform.localPosition = Vector3.zero;
				_shopContentTween = Go.from (
					_shopContentButton.transform, 2, new GoTweenConfig()
					.position(_shopContentButton.transform.position + new Vector3(300,0,0))
					.setEaseType(GoEaseType.ElasticOut)
					);
			}
		}
	}
	
	bool NeedViewButton {
		get {
			return 	ContentManager.Instance.ContentNear != null || 
					ContentCubeMap.ContentSelected != null		||
					ContentModels.ContentSelected != null 		||
					ContentVideo.ContentSelected != null		||
					(ContentInfo.ContentSelected != null && !ContentInfo.ContentSelected.Money);
		}
	}

	bool NeedShopButton {
		get {
			return 	ContentInfo.ContentSelected != null && ContentInfo.ContentSelected.Money;
		}
	}

	GameObject _viewContentButton;
	GameObject _shopContentButton;
	protected AbstractGoTween _viewContentTween;
	protected AbstractGoTween _shopContentTween;
}
