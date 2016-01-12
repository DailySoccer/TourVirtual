using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class CanvasRootController : MonoBehaviour {

	static public CanvasRootController Instance {
		get {
			GameObject canvasRootObj = GameObject.FindGameObjectWithTag("CanvasRoot");
			return canvasRootObj != null ? canvasRootObj.GetComponent<CanvasRootController>() : null;
		}
	}

	public GameObject fadeCanvas;
	public List<GameObject> canvasLayers = new List<GameObject>();
	private string _currentScreen;
	private RoomManager _roomManager;

	// Use this for initialization
	void Awake() {
		fadeCanvas.SetActive(false);
		HideCanvasLayers();

		_roomManager = RoomManager.Instance;
		_roomManager.OnSceneChange += OnLevelChange;
		_roomManager.OnSceneReady += OnLevelReady;
	}

	void Start() {
		canvasLayers.FirstOrDefault(c => c.name.ToLower() == "start canvas").SetActive(true);
	}

	private void HideCanvasLayers() {
		foreach(GameObject go in canvasLayers) {
			go.SetActive(false);
		}
	}

	public IEnumerator FadeOut (int waitSeconds) {
		//Debug.LogWarning("FadeOut BEGIN");

		// fadeCanvas.GetComponentInChildren<CanvasGroup>().alpha = 0;
		fadeCanvas.SetActive(true);

		Animator animator = fadeCanvas.GetComponentInChildren<Animator>();
		animator.speed = (waitSeconds > 0) ? 1.0f / (float)waitSeconds : 0;

		UIScreen screen = fadeCanvas.GetComponentInChildren<UIScreen>();
		screen.IsOpen = true;

		while (!screen.InOpenState) {
			yield return null;
		}

		yield return new WaitForSeconds(waitSeconds);
		//Debug.LogWarning("FadeOut END");
	}

	public IEnumerator FadeIn (int waitSeconds) {
		//Debug.LogWarning("FadeIn BEGIN");

		// fadeCanvas.GetComponentInChildren<CanvasGroup>().alpha = 1;
		fadeCanvas.SetActive(true);

		Animator animator = fadeCanvas.GetComponentInChildren<Animator>();
		animator.speed = (waitSeconds > 0) ? 1.0f / (float)waitSeconds : 0;

		UIScreen screen = fadeCanvas.GetComponentInChildren<UIScreen>();
		screen.IsOpen = false;

		while (!screen.InCloseState) {
			yield return null;
		}

		// yield return new WaitForSeconds(waitSeconds);

		fadeCanvas.SetActive(false);
		//Debug.LogWarning("FadeIn END");
	}

	void OnLevelChange() {
		HideCanvasLayers();
	}

	void OnLevelReady() {

		Debug.Log("Security cargo else level: " + _roomManager.Room);

		//GameObject canvas;
		switch(_roomManager.Room.Gui) {
		case RoomDefinition.GUI_AVATAR: // Avatar selector Scene
			//canvas =(GameObject) (from element in canvasLayers where element.name.ToLower() == "avatar canvas" select element);
			canvasLayers.FirstOrDefault(c => c.name.ToLower() == "avatar canvas").SetActive(true);
			/*canvas.SetActive(false);
			canvasLayers[0].SetActive(true);*/
			Debug.Log("Canvas Activado: Avatar selector Scene");
			break;
		case RoomDefinition.GUI_GAME: // Game Scene
			//canvas = (GameObject)(from element in canvasLayers where element.name.ToLower() == "agame canvas" select element);
			canvasLayers.FirstOrDefault(c => c.name.ToLower() == "game canvas").SetActive(true);
			/*canvas.SetActive(false);
			canvasLayers[1].SetActive(true);*/
			Debug.Log("Canvas Activado: Game selector Scene");
			break;
		}

		Debug.Log("Security cargo else level: " + Application.loadedLevelName);
	}
}
