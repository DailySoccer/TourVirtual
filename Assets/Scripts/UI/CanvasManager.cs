using UnityEngine;
using System.Collections;

public class CanvasManager : MonoBehaviour {

	public UIScreen currentGUIScreen;
	public GUIPopUpScreen currentGUIPopUpScreen;

	private UIScreen _newScreen;
	
	public void ShowScreenWithAnim(UIScreen guiScreen) {

		_newScreen = guiScreen;
		//currentGUIScreen = guiScreen;
		
		Debug.Log("====================================== SHOW!!");
		StartCoroutine(ShowScreenWithAnimCoroutine());
	}

	public void HideScreenWithAnim(UIScreen guiScreen) {

		_newScreen = guiScreen;
		//currentGUIScreen = guiScreen;
		
		Debug.Log("====================================== HIDE!!");
		StartCoroutine(HideScreenWithAnimCoroutine());
	}

	IEnumerator ShowScreenWithAnimCoroutine() {
		
		/*Animator animator = Camera.main.GetComponent<Animator>();
		
		animator.SetBool("Bloom", true);
		*/
		ShowScreen(_newScreen);

		yield return null;
	}
	
	IEnumerator HideScreenWithAnimCoroutine() {
		/*
		Animator animator = Camera.main.GetComponent<Animator>();
		*/
		//UIScreen oldScreen = currentGUIScreen;
		
		ShowScreen(_newScreen);
		/*
		while (!oldScreen.InCloseState) {
			yield return new WaitForEndOfFrame();
		}
		*/
		//animator.SetBool("Bloom", false);
		
		yield return null;
	}
	
	public void ShowScreen(UIScreen guiScreen) {
		if (currentGUIScreen != null && guiScreen != currentGUIScreen) {
			currentGUIScreen.CloseWindow();
			currentGUIScreen.IsOpen = false;
		}
		
		currentGUIScreen = guiScreen;
		
		if (currentGUIScreen != null) {
			currentGUIScreen.OpenWindow();
			currentGUIScreen.IsOpen = true;
		}
		else {
			Debug.Log("La guiScreen es null. Quizás no has establecido la primera desde el inspector.");
		}
	}
	
	public void ShowPopUpScreen(GUIPopUpScreen guiPopUpScreen) {
		if (currentGUIPopUpScreen != null) {
			currentGUIPopUpScreen.IsOpen = false;
		}
		
		currentGUIPopUpScreen = guiPopUpScreen;
		
		if (currentGUIPopUpScreen != null) {
			currentGUIPopUpScreen.IsOpen = true;
		}
		else {
			Debug.Log("La guiScreen es null. Quizás no has establecido la primera desde el inspector.");
		}
	}
	
	public void ClosePopUpScreen() {
		if (currentGUIPopUpScreen != null) {
			currentGUIPopUpScreen.IsOpen = false;
		}
		
		currentGUIPopUpScreen = null;
	}

	/*
	private void ShowScreenByName(string menuName) 
	{
		if (currentGUIScreen == null || currentGUIScreen.name != menuName)
		{
			ShowScreen(GetUISCreen(menuName));
		}
	}

	private void ShowPopUpScreenByName(string menuName) 
	{
		if (currentGUIPopUpScreen == null || currentGUIPopUpScreen.name != menuName)
		{
			ShowPopUpScreen(GetUIPopUpScreen(menuName));
		}
	}

	private GUIScreen GetUISCreen(string name) 
	{
		if(!GameObject.Find(name)) {
			Debug.LogError(string.Format("No se ha encontrado la GUIScreen: \"{0}\"; Revisa los nombres de las pantallas del menú.", name));
		}
		GUIScreen screen = GameObject.Find(name).GetComponent<GUIScreen>();
		
		return screen;
	}

	private GUIPopUpScreen GetUIPopUpScreen(string name) 
	{
		if(!GameObject.Find(name)) {
			Debug.LogError(string.Format("No se ha encontrado la GUIPopUpScreen: \"{0}\"; Revisa los nombres de las pantallas del menú.", name));
		}
		GUIPopUpScreen popUpScreen = GameObject.Find(name).GetComponent<GUIPopUpScreen>();
		
		return popUpScreen;
	}
	*/
}
