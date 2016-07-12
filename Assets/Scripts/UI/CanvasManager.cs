using UnityEngine;
using System.Collections;

public class CanvasManager : MonoBehaviour {

	public UIScreen ScreenMainGame;
	public UIScreen ScreenProfile;
	public UIScreen ScreenMap;
	public UIScreen ScreenChat;
	public UIScreen currentGUIScreen;

	public GUIPopUpScreen ModalScreen;
	
	public GameObject MainCamera;
	public GameObject UIScreensCamera;
	public GameObject SecondPlaneCanvas;
	public GameObject Particles;
	public GameObject ContentLoadingScreen;

	public Transform PlayerPosition;

	private UIScreen _newScreen;
	private GameObject ProfilePlayerInstance;
	private Transform particles;

	public ModalLayout currentModalLayout { get; set; }
	public GameObject PlayerClone { get; set; }
	public UIScreen lastGUIScreen { get; set; }
	public GUIPopUpScreen currentGUIPopUpScreen { get; set;}
	
	[SerializeField] private int _contentScreenId = 9;


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

	void ShowSecondPlaneScreens(params string[] names)
	{
		HideAllSecondPlaneScreens ();

		foreach(Transform t in SecondPlaneCanvas.transform) 
			for(int i = 0; i < names.Length; ++i)
			{
				if (t.name == names[i]) 
					t.gameObject.SetActive(true);
			}
		
	}

	public void ShowMainGameScreen()
	{
		HideAllSecondPlaneScreens ();
		
		SecondPlaneCanvas.SetActive (false);			
		SecondPlaneCanvas.GetComponent<AsociateWithMainCamera> ().SetCameraToAssociate(MainCamera.GetComponent<Camera>());
		UIScreensCamera.SetActive (false);			
		MainCamera.SetActive (true);


        if (ProfilePlayerInstance != null)
        {
            Destroy(ProfilePlayerInstance);
        }
		
		ShowScreen (ScreenMainGame);


		//StartCoroutine (DoStuffAterOpenMainScreen ());
	}
	/*
	IEnumerator DoStuffAterOpenMainScreen() {
			
		while (!ScreenMainGame.InOpenState) {
			yield return null;
		}

		// Si el juego de objetos encontrados esta abierto... abrimos su interfaz.
		if (HiddenObjects.HiddenObjects.Instance.enabled) {
			GetComponent<HiddenObjectsGameCanvasController>().IsHiddenObjectHUD_Open = true;
		}
	}
*/
	/*public void ShowMainScreenNoTouchSecondPlane() {
		ShowScreen (ScreenMainGame);
	}*/

	public void ShowProfileScreen()
	{
		if (ProfilePlayerInstance != null) Destroy(ProfilePlayerInstance);
        StartCoroutine( PlayerManager.Instance.CreateAvatar(PlayerManager.Instance.SelectedModel, (instance)=>{
            MyTools.SetLayerRecursively(instance, LayerMask.NameToLayer("Model3D"));
            UIScreensCamera.SetActive (true);
            MainCamera.SetActive(false);

			ActiveSecondPlaneGUI ("Video Bg", "Profile Screen Plano2");	
			ShowScreen(ScreenProfile);
			//Seteamos el Avatar que se muestra en estapantalla
			ProfilePlayerInstance = instance;
			ProfilePlayerInstance.name = "UI Player Clone for Profile";
			ProfilePlayerInstance.GetComponent<Rigidbody>().isKinematic = true;
			ProfilePlayerInstance.GetComponent<SynchNet>().enabled = false;
            ProfilePlayerInstance.transform.position = new Vector3(-0.05f, 9998.82f, 0);
            ProfilePlayerInstance.transform.localRotation = Quaternion.Euler(7.3f, 0, 0);
            ProfilePlayerInstance.AddComponent<RotateDrag>();

            SkinnedMeshRenderer[] skins = ProfilePlayerInstance.GetComponentsInChildren<SkinnedMeshRenderer>();
            foreach (var skin in skins)
                skin.useLightProbes = false;
            AddParticles();
        }) );
	}

	public void ShowGoodiesShopScreen()
	{
		GoodiesShopController.Show ();
	}


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

    public void ShowMapScreen()
    {
		if (ProfilePlayerInstance != null) {
            Destroy(ProfilePlayerInstance);
        }
			
		ActiveSecondPlaneGUI ("Video Bg");			
		ShowScreen(ScreenMap);
    }

	public void ShowChatScreen()
	{
		if (ProfilePlayerInstance != null) {
			Destroy(ProfilePlayerInstance);
		}
		
		//ActiveSecondPlaneGUI ("Video Bg");			
		ShowScreen(ScreenChat);
	}

	/*
	public void ShowGoodiesShopScreen() {
        if (ProfilePlayerInstance != null){
            Destroy(ProfilePlayerInstance);
        }
		
		ActiveSecondPlaneGUI ("Video Bg");			
		ShowScreen(ScreenGoodiesShoop);
	}
	*/

	public void ShowVestidorScreen()
	{
		RoomManager.Instance.GotoRoom ("VESTIDORLITE");
		ShowMainGameScreen ();
	}

	private void ActiveSecondPlaneGUI(params string[] names)
	{
		ShowSecondPlaneScreens(names);		
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
            if (currentGUIScreen.name == "Map Screen") MainCamera.SetActive(true);
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
	public string[] CurrentPlayerDataModelSelected;
	public void ShowOTherPlayerInfo(string[] dataModel) {
		//Configuramos las modal...
		CurrentPlayerDataModelSelected  = dataModel;
		//.. y la mostramos
		ShowModalScreen ((int)ModalLayout.THIRDS_PROFILE_CONTENT);
	}

	public void ShowModalScreen(int newModalLayout)
	{
		if (ModalScreen == null) {
			Debug.LogError("[CanvasManager in " + name + "]: La guiModalScreen es null. Quizás no has establecido la primera desde el inspector.");
			return;
		}

		// Lanzamos la modal, solo si está cerrada previamente.
		HideModalScreen ();
		StartCoroutine (ModalCloseBeforeOpenAgain(newModalLayout));
	}


	IEnumerator ModalCloseBeforeOpenAgain(int newModalLayout) {

		while (ModalScreen.InOpenState) {
			yield return null;
		}

		ModalScreen.IsOpen = true;
		ModalScreen.GetComponent<CanvasGroup>().interactable = true;
		
		PopUpWindow modalPopUpWindow = ModalScreen.GetComponent<PopUpWindow> ();
		modalPopUpWindow.CurrentModalLayout = (ModalLayout)newModalLayout;
	}

	public void HideModalScreen()
	{
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

    public void HideCameras()
    {
        UIScreensCamera.SetActive(false);
        MainCamera.SetActive(false);
    }

    public void ShowCameras()
    {
        UIScreensCamera.SetActive(true);
        MainCamera.SetActive(true);
    }
	public bool IsInRanking()
	{
		UserAPI.ScoreEntry[] rankingArray = UserAPI.Instance.GetFanRanking();
		UserAPI.ScoreEntry me = new UserAPI.ScoreEntry();

		foreach (UserAPI.ScoreEntry se in rankingArray)
		{
			if (se.IsMe)
				me = se;
		}
		return me.Position != 0;
	}

	public void ShareRankingPosition () {
		UserAPI.ScoreEntry[] rankingArray = UserAPI.Instance.GetFanRanking();
		UserAPI.ScoreEntry me = new UserAPI.ScoreEntry();

		foreach (UserAPI.ScoreEntry se in rankingArray) {
			if (se.IsMe)
				me = se;
		}
		if (me.Position == 0)
		{
			me.Position = rankingArray.Length;
		}

		FacebookManager.Instance.ShareToFacebook(FacebookLink.RankingShare(me.Position));
	}

	public void Launch_Initial_Tutorial()
	{
		InitialTutorial.Instance.SartTutorial();
	}


	/// <summary>
	/// 
	/// </summary>
	/// <param name="content"></param>
	// TODO Sería más correcto que este manager se subscribiera al SceneClicker
	public void OnContentClick(ContentList content)
	{
		if(content == ContentManager.Instance.ContentNear)
			ShowModalScreen(_contentScreenId);
	}
}
