#if !LITE_VERSION

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIContentScreen : UIScreen {

	public GameCanvasManager GameCanvasManager;

	public Button NextButton;
	public Button PrevButton;
	public Contenidos Contentenidos;

	public override void Awake () {
		base.Awake ();
		_background = GetComponent<Image>();
	}

	public override void Update () {
		base.Update ();

		if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Open")) {
			if (!_loading) {
				_loading = true;
				OpenContent ();
			}
		}
		else {
			if (_loading) {
				_loading = false;
				CloseContent ();
			}
		}
	}
	/*
	public void HideScreen(UIScreen uiScreen) {
		if (GameCanvasManager != null) {
			GameCanvasManager.HideScreenWithAnim(uiScreen);
		}
	}
	*/
	void OpenContent() {
        Camera.main.enabled = false;
		NextButton.gameObject.SetActive(false);
		PrevButton.gameObject.SetActive(false);

        if (ContentManager.Instance.ContentNear != null) {
            Debug.LogError("!!! "+ ContentManager.Instance.ContentNear.ContentKey);
//            StartCoroutine( Contentenidos.ShowContents() );
		}
		UpdateButtons ();
	}

	void CloseContent() {
        Camera.main.enabled = true;
        if (ContentManager.Instance.ContentNear != null) {
//			StartCoroutine(Contentenidos.HideContents());
		}
	}

	public void BuyContent() {
	}

	public void PrevContent() {
		if (Contentenidos.gameObject.activeSelf) {
//            Contentenidos.Prev();
		}


		UpdateButtons();
	}

	public void NextContent() {
		if (Contentenidos.gameObject.activeSelf) {
//            Contentenidos.Next();
		}

		UpdateButtons();
	}
	
	void UpdateButtons() {
		if (Contentenidos.gameObject.activeSelf) {
//			PrevButton.gameObject.SetActive(!Contentenidos.Empty && !Contentenidos.IsFirst);
//			NextButton.gameObject.SetActive(!Contentenidos.Empty && !Contentenidos.IsLast);
		}
	}

	private bool _loading = false;
	private Image _background;
}

#endif