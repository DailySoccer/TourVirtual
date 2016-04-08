using UnityEngine;
using System.Collections;

public class CanvasManager : MonoBehaviour {

	public GameObject MainCamera;
	public GameObject UIScreensCamera;
	public GameObject SecondPlaneCanvas;
	public GameObject PlayerClone;

	public GUIPopUpScreen ModalScreen;
	public ModalLayout currentModalLayout;

	private UIScreen _newScreen;
	private GameObject ProfilePlayerInstance;

	public UIScreen ScreenMainGame;
	public UIScreen ScreenProfile;
	public UIScreen ScreenMap;
	public UIScreen ScreenGoodiesShoop;

    public UIScreen lastGUIScreen;
    public UIScreen currentGUIScreen;
    public GUIPopUpScreen currentGUIPopUpScreen;

	public GameObject ContentLoadingScreen;

	/// <summary>
	/// Intercambia pantallas.	/// 
	/// Sutituye a ShowScreen
	/// </summary>
	/// <param name="guiScreen">GUI screen.</param>
	public void ChangeScreen(UIScreen guiScreen) {
		if (UIScreensCamera.GetActive()) {
			SecondPlaneCanvas.SetActive (false);
			UIScreensCamera.SetActive (false);
			MainCamera.SetActive (true);
		}
		ShowScreen(guiScreen);
	}

	void HideAllSecondPlaneScreens() {
		foreach(Transform t in SecondPlaneCanvas.transform) {
			t.gameObject.SetActive(false);
		}
	}

	void ShowSecondPlaneScreens(params string[] names) {
		HideAllSecondPlaneScreens ();

		foreach(Transform t in SecondPlaneCanvas.transform) {
			for(int i = 0; i < names.Length; ++i){
				if (t.name == names[i]) {
					t.gameObject.SetActive(true);
				}
			}
		}		
	}

	public void ShowMainGameScreen() {
		HideAllSecondPlaneScreens ();
		
		SecondPlaneCanvas.SetActive (false);			
		SecondPlaneCanvas.GetComponent<AsociateWithMainCamera> ().SetCameraToAssociate(MainCamera.GetComponent<Camera>());
		UIScreensCamera.SetActive (false);			
		MainCamera.SetActive (true);			
		
		
		if (ProfilePlayerInstance != null) Destroy(ProfilePlayerInstance);
		
		ShowScreen (ScreenMainGame);
	}

	public void ShowProfileScreen() {

		if (ProfilePlayerInstance != null) Destroy(ProfilePlayerInstance);
		
		//Activamos los elementos necesarios de esta pantalla
		//ShowSecondPlaneScreens("Video Bg", "Profile Screen Plano2");
		//SecondPlaneCanvas.SetActive (true);			
		//SecondPlaneCanvas.GetComponent<AsociateWithMainCamera> ().SetCameraToAssociate(UIScreensCamera.GetComponent<Camera>());
		StartCoroutine( PlayerManager.Instance.CreateAvatar(PlayerManager.Instance.SelectedModel, (instance)=>{
            UIScreensCamera.SetActive (true);
            MainCamera.SetActive(false);

			ActiveSecondPlaneGUI ();	
			ShowScreen(ScreenProfile);

			//Seteamos el Avatar que se muestra en estapantalla
			ProfilePlayerInstance = instance;
			ProfilePlayerInstance.layer = 5;
			foreach(Transform t in ProfilePlayerInstance.transform) {
				t.gameObject.layer = 5;
			}
			ProfilePlayerInstance.name = "UI Player Clone for Profile";
			ProfilePlayerInstance.GetComponent<Rigidbody>().isKinematic = true;
			ProfilePlayerInstance.GetComponent<SynchNet>().enabled = false;
            ProfilePlayerInstance.transform.position = new Vector3(-0.05f, 9998.82f, 0);
            ProfilePlayerInstance.transform.localRotation = Quaternion.Euler(7.3f, 0, 0);
            ProfilePlayerInstance.AddComponent<RotateDrag>();
            AddParticles();
        }) );
	}
    public Transform PlayerPosition;
    public GameObject Particles;
    Transform particles;
    public void AddParticles()
    {
        if (particles == null)
        {
            particles = (GameObject.Instantiate(Particles) as GameObject).transform;
            SetLayerRecursively(particles.gameObject, LayerMask.NameToLayer("UI"));
            particles.position = ProfilePlayerInstance.transform.position;
            particles.transform.rotation = Quaternion.identity;
        }
    }

    void SetLayerRecursively(GameObject obj, int newLayer)
    {
        obj.layer = newLayer;
        foreach (Transform child in obj.transform)
            SetLayerRecursively(child.gameObject, newLayer);
    }

    public void ShowMapScreen() {
//        gameObject.GetComponent<AllViewer>().Show("https://az726872.vo.msecnd.net/global-contentasset/asset_92d476d9-7c95-4102-8d7d-b9f18c1fadc7.jpg", AllViewer.ViewerMode.Image);
        gameObject.GetComponent<AllViewer>().Show("https://googledrive.com/host/0B8a_PPkBFGwNdEhYN2JORGtmRUk/copaforonda", AllViewer.ViewerMode.Model, "Copa Foronda");
        return;


        if (ProfilePlayerInstance != null) 
			Destroy(ProfilePlayerInstance);
		ActiveSecondPlaneGUI ();			
		ShowScreen(ScreenMap);
    }

	public void ShowGoodiesShopScreen() {		
		if (ProfilePlayerInstance != null) 
			Destroy(ProfilePlayerInstance);
		
		ActiveSecondPlaneGUI ();			
		ShowScreen(ScreenGoodiesShoop);
	}

	public void ShowVestidorScreen() {	
		RoomManager.Instance.GotoRoom ("VESTIDORLITE");
		ShowMainGameScreen ();
	}

	private void ActiveSecondPlaneGUI() {
		ShowSecondPlaneScreens("Video Bg", "Profile Screen Plano2");		
		SecondPlaneCanvas.SetActive (true);			
		SecondPlaneCanvas.GetComponent<AsociateWithMainCamera> ().SetCameraToAssociate(UIScreensCamera.GetComponent<Camera>());
		
		UIScreensCamera.SetActive (true);			
		MainCamera.SetActive (false);	
	}

    public void ShowLastScreen()
    {
        ShowScreen(lastGUIScreen);
    }

    /// <summary>
    /// (Deprecated) Shows the screen.
    /// </summary>
    /// <param name="guiScreen">GUI screen.</param>
    public void ShowScreen(UIScreen guiScreen) {
		//Debug.LogWarning ("[CanvasManager]: GameCanvasManager/ShowScreen() [Función deprecada]: Esta función no garantiza apagar la cámara de segundo plano. ");
		if (currentGUIScreen != null && guiScreen != currentGUIScreen) {
			currentGUIScreen.CloseWindow();
			currentGUIScreen.IsOpen = false;
		}

        lastGUIScreen = currentGUIScreen;
        currentGUIScreen = guiScreen;
		
		if (currentGUIScreen != null) {
			currentGUIScreen.OpenWindow();
			currentGUIScreen.IsOpen = true;
		}
		else {
			Debug.LogError("[CanvasManager in " + name +"]: La guiScreen es null. Quizás no has establecido la primera desde el inspector.");
		}
	}
#if !LITE_VERSION
	public void ShowOTherPlayerInfo(string playerID) {
		//Configuramos las modal...
		ModalScreen.GetComponent<PopUpWindow> ().SetupThirdProfileContent(playerID);
		//.. y la mostramos
		ShowModalScreen ((int)ModalLayout.THIRDS_PROFILE_CONTENT);
	}
#endif
	public void ShowModalScreen(int newModalLayout) {

		if (ModalScreen == null) {
			Debug.LogError("[CanvasManager in " + name + "]: La guiModalScreen es null. Quizás no has establecido la primera desde el inspector.");
			return;
		}

		ModalScreen.IsOpen = true;
		ModalScreen.GetComponent<CanvasGroup>().interactable = true;

		PopUpWindow modalPopUpWindow = ModalScreen.GetComponent<PopUpWindow> ();
		modalPopUpWindow.SetState((ModalLayout)newModalLayout);

		/*
		switch((ModalLayout)newModalLayout) {
			case ModalLayout.PURCHASED_PACKS_GRID:
				modalPopUpWindow.();
				break;
			case ModalLayout.ACHIEVEMENTS_GRID:
				modalPopUpWindow.SetupAchievementGridContent();
				break;
			case ModalLayout.PACK_FLYER:
				modalPopUpWindow.LauchFlyerPackContent();
				break;
		
			case ModalLayout.PURCHASED_LIST_CONTENT:
				modalPopUpWindow.SetupPurchasedListContent();
				break;
			case ModalLayout.SINGLE_CONTENT_BUY_ITEM:
				modalPopUpWindow.SetupSingleContentBuyContent();
				break;
			case ModalLayout.SINGLE_CONTENT_GOTO_SHOP:
				modalPopUpWindow.SetupSingleContentGoToShop();
				break;
			case ModalLayout.SINGLE_CONTENT_SARE:
				modalPopUpWindow.SetupSingleContentToShare();
				break;
			case ModalLayout.THIRDS_PROFILE_CONTENT:				
				break;

			 
		}*/

	}

	public void HideModalScreen() {
		//if (ModalScreen != null) {
		ModalScreen.IsOpen = false;
		ModalScreen.GetComponent<CanvasGroup> ().interactable = false;
		ModalScreen.GetComponent<PopUpWindow>().SetState(ModalLayout.BLANK);
		//}
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
			Debug.LogError("[CanvasManager]: La guiScreen es null. Quizás no has establecido la primera desde el inspector.");
		}
	}
	
	public void ClosePopUpScreen() {
		if (currentGUIPopUpScreen != null) {
			currentGUIPopUpScreen.IsOpen = false;
		}
		
		currentGUIPopUpScreen = null;
	}


	/*
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
		* /
		ShowScreen(_newScreen);

		yield return null;
	}
	
	IEnumerator HideScreenWithAnimCoroutine() {
		/*
		Animator animator = Camera.main.GetComponent<Animator>();
		* /
		//UIScreen oldScreen = currentGUIScreen;
		
		ShowScreen(_newScreen);
		/*
		while (!oldScreen.InCloseState) {
			yield return new WaitForEndOfFrame();
		}
		* /
		//animator.SetBool("Bloom", false);
		
		yield return null;
	}
	
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
