using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class VestidorCanvasController_Lite : MonoBehaviour {

	public enum VestidorState{
		NONE,
		SELECT_AVATAR,
		VESTIDOR
	}

	public Transform PlayerPosition;
	//////////////////// Control de ventanas Modales//////////////////// 
	public GUIScreen VestidorScreen;
	public GUIScreen GoodiesShopScreen;
	public GUIScreen AvatarSelectionScreen;
	private GUIScreen currentGUIScreen;

	public GameObject cameraVestidor;
	public GameObject SecondPlaneVestidor;

	public GameObject cameraAvatarSelector;
	public GameObject SecondPlaneAvatarSelect;
	
	public GUIPopUpScreen ModalPopUpScreen;
	private PopUpWindow popUpWindow;
	private DetailedContent2Buttons modalDetail;
	
	public GameObject TopMenu;
		
	private bool isCurrentPopUpOpen;

	private VestidorState currentVestidorState;

	private GameObject PlayerInstance;


    public static Dictionary<string, string> DecodeQueryParameters(System.Uri uri)
    {
        if (uri.Query.Length == 0)
            return new Dictionary<string, string>();

        return uri.Query.TrimStart('?')
                        .Split(new[] { '&', ';' }, System.StringSplitOptions.RemoveEmptyEntries)
                        .Select(kvp => kvp.Split(new[] { '=' }, System.StringSplitOptions.RemoveEmptyEntries))
                        .ToDictionary(kvp => kvp[0],
                                      kvp => kvp.Length > 2 ? string.Join("=", kvp, 1, kvp.Length - 1) : (kvp.Length > 1 ? kvp[1] : ""));
    }

    // Use this for initialization
    void OnEnable () {

        System.Uri uri = new System.Uri(MainManager.DeepLinkingURL);
        var parms = BestHTTP.JSON.Json.Decode(WWW.UnEscapeURL(DecodeQueryParameters(uri)["parameters"])) as Dictionary<string, object>;
        Debug.LogError(">>>> "+ parms["idVirtualGood"] as string);

        EnableTopMenu(true);
		ShowVestidor ();
	}
	
	// Update is called once per frame
	void Update () {	
		if (PlayerInstance != null)
			PlayerInstance.transform.position = PlayerPosition.position;
	}

	public void ChangeVestidorState(VestidorState newState) {
		if (newState != currentVestidorState) {		
			switch(newState) {
				case VestidorState.SELECT_AVATAR:
					cameraAvatarSelector.SetActive(true);
					SecondPlaneAvatarSelect.SetActive(true);
					cameraVestidor.SetActive(false);
					SecondPlaneVestidor.SetActive(false);
					gameObject.GetComponentInChildren<AsociateWithMainCamera>().SetCameraToAssociate(cameraAvatarSelector.GetComponent<Camera>());

					ShowScreen(AvatarSelectionScreen);
				break;

				case VestidorState.VESTIDOR:
					cameraAvatarSelector.SetActive(false);
					SecondPlaneAvatarSelect.SetActive(false);
					cameraVestidor.SetActive(true);
					SecondPlaneVestidor.SetActive(true);
					gameObject.GetComponentInChildren<AsociateWithMainCamera>().SetCameraToAssociate(cameraVestidor.GetComponent<Camera>());

					ShowScreen(VestidorScreen);
				break;
			}
			currentVestidorState = newState;
		}
	}

	void EnableTopMenu(bool val) {
		TopMenu.SetActive (val);
	}

	public void TryToDressPlayer(ClothSlot prenda) {

		bool CanDressPlayer = true;
		bool EnoughMoney = false;

        if (CanDressPlayer) {
            switch (prenda.virtualGood.IdSubType)
            {
                case "HTORSO":
                case "MTORSO":
                    UserAPI.AvatarDesciptor.Torso = prenda.virtualGood.GUID;
                    break;
                case "HLEG":
                case "MLEG":
                    UserAPI.AvatarDesciptor.Legs = prenda.virtualGood.GUID;
                    break;
                case "HSHOE":
                case "MSHOE":
                    UserAPI.AvatarDesciptor.Feet = prenda.virtualGood.GUID;
                    break;
                case "HCOMPLIMENT":
                case "MCOMPLIMENT":
                    UserAPI.AvatarDesciptor.Compliment = prenda.virtualGood.GUID;
                    break;
                case "HHAT":
                case "MHAT":
                    UserAPI.AvatarDesciptor.Hat = prenda.virtualGood.GUID;
                    break;
                case "HPACK":
                case "MPACK":
                    UserAPI.AvatarDesciptor.Pack = prenda.virtualGood.GUID;
                    break;
            }
            PlayerManager.Instance.SelectedModel = UserAPI.AvatarDesciptor.ToString();
            LoadModel();
        } 
		else {
			Debug.Log ("[VestidorCanvas]: No se puede vestir el Player con esto");
#if !LITE_VERSION
			popUpWindow = ModalPopUpScreen.GetComponent<PopUpWindow>();

			modalDetail = ModalPopUpScreen.GetComponentInChildren<DetailedContent2Buttons> ();
			modalDetail.TheName.text = prenda.ClothName.text;
			modalDetail.ThePicture.sprite = prenda.Picture.sprite;

			if (EnoughMoney) {
				Debug.Log ("[VestidorCanvas]: Tengo suficiente dinero para comprarlo");
				popUpWindow.SetState( ModalLayout.SINGLE_CONTENT_BUY_ITEM);
				modalDetail.BuyButton.GetComponentInChildren<Text>().text = prenda.Price.text;
			}
			else {
				Debug.Log ("[VestidorCanvas]: No tengo suficiente dinero para Comprarlo");
				popUpWindow.SetState (ModalLayout.SINGLE_CONTENT_GOTO_SHOP);
			}
			TogglePopUpScreen(); 
#endif
		}
	}

	public void TogglePopUpScreen() {

		if (ModalPopUpScreen != null) {
			isCurrentPopUpOpen = !ModalPopUpScreen.IsOpen;
			ModalPopUpScreen.IsOpen = isCurrentPopUpOpen;
			ModalPopUpScreen.GetComponent<CanvasGroup>().interactable = isCurrentPopUpOpen;
		}
		else {
			Debug.LogError("[VestidorCanvas]: La ModalPopUpScreen es null. Quizás no se ha establecido en el inspector.");
		}
	}

    public void ShowVestidor() {
        if (isCurrentPopUpOpen)
            TogglePopUpScreen();
        if (PlayerInstance == null && MainManager.VestidorMode == VestidorState.VESTIDOR)
            LoadModel();
        ChangeVestidorState(MainManager.VestidorMode);
    }

    void LoadModel() {
        if (PlayerInstance != null)
            Destroy(PlayerInstance);
        StartCoroutine( PlayerManager.Instance.CreateAvatar(PlayerManager.Instance.SelectedModel, (instance) => {
			//Seteamos el Avatar que se muestra en estapantalla
			PlayerInstance = instance;
			PlayerInstance.GetComponent<Rigidbody>().isKinematic = true;
			PlayerInstance.GetComponent<SynchNet>().enabled = false;
			PlayerInstance.transform.localScale = Vector3.one * 10;				
		}) );
        
	}

	public void ShowGoodiesShop() {
		if (PlayerInstance != null)
			Destroy (PlayerInstance);

		if (isCurrentPopUpOpen)
			TogglePopUpScreen();

		ShowScreen(GoodiesShopScreen);
	}

	private void ShowScreen(GUIScreen guiScreen) {
		Debug.LogWarning ("[CanvasManager]: GameCanvasManager/ShowScreen() [Función deprecada]: Esta función no garantiza apagar la cámara de segundo plano. ");
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
			Debug.LogError("[CanvasManager]: La guiScreen es null. Quizás no has establecido la primera desde el inspector.");
		}
	}

	void HideAllScreens() {
		if (PlayerInstance != null)
			Destroy (PlayerInstance);
		
		if (isCurrentPopUpOpen)
			TogglePopUpScreen();
		
		ShowScreen(null);
		EnableTopMenu (false);
	}

	public void AcceptChangesAndBackToRoom() {
#if !LITE_VERSION
		Debug.Log ("[VestidorCanvas]: Guardo la nueva vestimenta y vuelvo al tour");
		HideAllScreens ();
		BackToRoom ();
#else
		Debug.LogError("Aceptar cambios Cerrar App y Volver");

#endif
	}

	public void BackToRoom() {
#if !LITE_VERSION
        if (MainManager.IsDeepLinking) {
            Application.OpenURL("rmapp://");
            Application.Quit();
            return;
        }
		HideAllScreens ();
		RoomManager.Instance.GotoPreviousRoom ();
#else
       
        Debug.LogError("Cerrar App y Volver");
#endif
	}

	public void AcceptThisAvatar() {
#if !LITE_VERSION

#else
        if (UserAPI.Instance != null){
            UserAPI.Instance.UpdateAvatar();
            UserAPI.Instance.SendAvatar(PlayerManager.Instance.RenderModel(PlayerInstance));
            UserAPI.Instance.UpdateNick("Nick" + Random.Range(0, 100000));
        }
        Debug.LogError("Aceptar Modelo de Avatar, Cerrar App y Volver");
        if (MainManager.IsDeepLinking)
        {
            Application.OpenURL("rmapp://");
            Application.Quit();
            return;
        }
#endif
    }

    public void CancelThisAvatar()
    {
#if !LITE_VERSION

#else
        Debug.LogError("Aceptar Modelo de Avatar, Cerrar App y Volver");
#endif
    }

    public void SetLanguage(string lang) {
		MainManager.Instance.ChangeLanguage (lang);
	}
}
