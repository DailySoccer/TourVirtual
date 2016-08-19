using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class CanvasRootController : MonoBehaviour {

	static public CanvasRootController Instance { get; private set; }

	public Camera UIScreensCamera;

	public GameObject SecondPlaneCanvas;
	public GameObject LoadingCanvas;

	public List<GameObject> canvasLayers = new List<GameObject>();


	private string _currentScreen;
	private RoomManager _roomManager;

	// Use this for initialization
	void Awake() {
        Instance = this;

        LoadingCanvas.SetActive(false);
		HideCanvasLayers();

		_roomManager = RoomManager.Instance;
		_roomManager.OnSceneChange += OnLevelChange;
		_roomManager.OnSceneReady += OnLevelReady;
	}

	void Start() {
//		canvasLayers.FirstOrDefault(c => c.name.ToLower() == "start canvas").SetActive(true);
        LoadingCanvas.SetActive(true);
		LoadingCanvas.GetComponentInChildren<UIScreen> ().IsOpen = true;
    }


    private void HideCanvasLayers() {
		foreach(GameObject go in canvasLayers) {
            if(go!=null)
                go.SetActive(false);
		}
		if(SecondPlaneCanvas!=null) SecondPlaneCanvas.SetActive(false);
	}

	public IEnumerator FadeOut (int waitSeconds) {
		LoadingCanvas.SetActive(true);

		Animator animator = LoadingCanvas.GetComponentInChildren<Animator>();
		animator.speed = (waitSeconds > 0) ? 1.0f / (float)waitSeconds : 0;

		UIScreen screen = LoadingCanvas.GetComponentInChildren<UIScreen>();
		screen.IsOpen = true;

		while (!screen.InOpenState) {
			yield return null;
		}

		yield return new WaitForSeconds(waitSeconds);
	}

	public IEnumerator FadeIn (int waitSeconds) {
		LoadingCanvas.SetActive(true);

		Animator animator = LoadingCanvas.GetComponentInChildren<Animator>();
		animator.speed = (waitSeconds > 0) ? 1.0f / (float)waitSeconds : 0;

		UIScreen screen = LoadingCanvas.GetComponentInChildren<UIScreen>();
		screen.IsOpen = false;

		while (!screen.InCloseState) {
			yield return null;
		}

		LoadingCanvas.SetActive(false);
	}

	void OnLevelChange() {
		HideAllSecondPlaneScreens();
		HideCanvasLayers();
	}

	void HideAllSecondPlaneScreens() {
        if(SecondPlaneCanvas!=null)
		    foreach(Transform t in SecondPlaneCanvas.transform) {
			    t.gameObject.SetActive(false);
		    }
	}


	void OnLevelReady() {
		//GameObject canvas;
		//VR edit ('if' statement)
		if (!MainManager.Instance.IsVrModeEnabled)
		{
			switch (_roomManager.Room.Gui)
			{
				case RoomDefinition.GUI_GAME: // Game Scene
														//canvas = (GameObject)(from element in canvasLayers where element.name.ToLower() == "agame canvas" select element);
					GameObject goCanvasGame = canvasLayers.FirstOrDefault(c => c.name.ToLower() == "game canvas");
					goCanvasGame.SetActive(true);
					break;

				case RoomDefinition.GUI_MINIGAMES: // Game Scene
					GameObject goCanvasMiniGame = canvasLayers.FirstOrDefault(c => c.name.ToLower() == "minigames canvas");
					goCanvasMiniGame.SetActive(true);
					break;
			}
		}
		//VR edit END
	}
}
