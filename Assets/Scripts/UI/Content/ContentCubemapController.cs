using UnityEngine;
using System.Collections;

public class ContentCubemapController : MonoBehaviour {

	void Start () {
	}
	
	void Update () {
	}

	public ContentCubeMap CurrentContent {
		get {
			return ContentCubeMap.ContentSelected;
		}
	}
	
	public IEnumerator ShowContents() {
		gameObject.SetActive(true);
		CurrentContent.GetInstance().SetActive(true);
		
		CubeMapCamera.Instance.Activate();
		
		/*
		_cameraMain = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		_cameraMain.enabled = false;
		*/
		
		MainManager.Instance.GameInputEnabled = false;
		
		yield return null;
	}
	
	public IEnumerator HideContents() {
		gameObject.SetActive(false);
		CurrentContent.GetInstance().SetActive(false);
		
		//_cameraMain.enabled = true;
		
		CubeMapCamera.Instance.Deactivate();
		
		MainManager.Instance.GameInputEnabled = true;
		
		yield return null;
	}

	Camera _cameraMain;
}
