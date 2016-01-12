using UnityEngine;
using System.Collections;

public class TestChatCanvasController : MonoBehaviour {

	public GameObject popUpContent;

	void Awake() {
		popUpContent.SetActive(false);
	}

	void Start() {
		RoomManager.Instance.OnSceneReady += StartChat;
	}

	void StartChat() {
		Debug.Log(" ======> OnSceneReady");
		popUpContent.SetActive(true);
		Debug.Log(" ======> GUIPopUpScreen -> Active");
		popUpContent.GetComponent<GUIPopUpScreen>().IsOpen = true;

	}

	void OnEnable(){


	}

}
