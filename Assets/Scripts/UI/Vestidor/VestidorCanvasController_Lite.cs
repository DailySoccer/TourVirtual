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

    // Use this for initialization
    void OnEnable () {
        if (MainManager.IsDeepLinking &&
            MainManager.DeepLinkinParameters!=null &&
            MainManager.DeepLinkinParameters.ContainsKey("idVirtualGood"))
        {
            TryToDressVirtualGood(MainManager.DeepLinkinParameters["idVirtualGood"] as string);
            // MainManager.DeepLinkinParameters["idUser"];
        }
        EnableTopMenu(true);
		ShowVestidor ();
    
	}

    // Update is called once per frame
    void Update () {	
		if (PlayerInstance != null)
			PlayerInstance.transform.position = PlayerPosition.position;
	}

	public void ChangeVestidorState(VestidorState newState) {


        if (MainManager.IsDeepLinking)
        {
            popUpWindow = ModalPopUpScreen.GetComponent<PopUpWindow>();

            modalDetail = ModalPopUpScreen.GetComponentInChildren<DetailedContent2Buttons>();
            modalDetail.TheName.text = MainManager.DeepLinkingURL;
            modalDetail.ThePicture.sprite = null;
            TogglePopUpScreen();
        }

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
        TryToDressVirtualGood(prenda.virtualGood);
    }

    public void TryToDressVirtualGood(string GUID)
    {
        TryToDressVirtualGood(UserAPI.VirtualGoodsDesciptor.GetByGUID(GUID),false);
    }

    public void TryToDressVirtualGood(VirtualGoodsAPI.VirtualGood virtualGood,bool loadmodel=true) {

        if (virtualGood == null)
            return;
		bool CanDressPlayer = true;
		bool EnoughMoney = false;

        if (CanDressPlayer) {
            switch (virtualGood.IdSubType)
            {
                case "HTORSO":
                case "MTORSO":
                    UserAPI.AvatarDesciptor.Torso = virtualGood.GUID;
                    UserAPI.AvatarDesciptor.Pack = null;
                    break;
                case "HLEG":
                case "MLEG":
                    UserAPI.AvatarDesciptor.Legs = virtualGood.GUID;
                    UserAPI.AvatarDesciptor.Pack = null;
                    break;
                case "HSHOE":
                case "MSHOE":
                    UserAPI.AvatarDesciptor.Feet = virtualGood.GUID;
                    UserAPI.AvatarDesciptor.Pack = null;
                    break;
                case "HCOMPLIMENT":
                case "MCOMPLIMENT":
                    UserAPI.AvatarDesciptor.Compliment = virtualGood.GUID;
                    UserAPI.AvatarDesciptor.Pack = null;
                    break;
                case "HHAT":
                case "MHAT":
                    UserAPI.AvatarDesciptor.Hat = virtualGood.GUID;
                    UserAPI.AvatarDesciptor.Pack = null;
                    break;
                case "HPACK":
                case "MPACK":
                    UserAPI.AvatarDesciptor.Pack = virtualGood.GUID;
                    break;
            }
            PlayerManager.Instance.SelectedModel = UserAPI.AvatarDesciptor.ToString();
            if(loadmodel)
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
            UserAPI.Instance.SendAvatar(PlayerManager.Instance.RenderModel(PlayerInstance),()=> {
                if (MainManager.IsDeepLinking)
                {
                    Application.OpenURL("rmapp://");
                    Application.Quit();
                    return;
                }
            });
            UserAPI.Instance.UpdateNick("Nick" + Random.Range(0, 100000));
        }
        Debug.LogError("Aceptar Modelo de Avatar, Cerrar App y Volver");
       
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
