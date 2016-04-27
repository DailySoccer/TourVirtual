using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SmartLocalization;

public class VestidorCanvasController_Lite : MonoBehaviour
{

    public enum VestidorState
    {
        NONE,
        SELECT_AVATAR,
        VESTIDOR,
        LANDING_PAGE
    }

    public Transform PlayerPosition;
    //////////////////// Control de ventanas Modales//////////////////// 
    public GUIScreen VestidorScreen;
	public GUIScreen lobbyScreen;
    public GUIScreen GoodiesShopScreen;
    public GUIScreen AvatarSelectionScreen;
    public GUIScreen PlayTeaserScreen;
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

    public GameObject PlayerInstance;
    public GameObject Particles;
    public static VestidorCanvasController_Lite Instance { get; private set; }

    public GameObject BuyInfoButtom;

    public UnityEngine.UI.Button BotonAceptar;

	public ClothSlot currentPrenda;
    AvatarAPI mOldAvatarDesciptor;

    //private VestidorState lastVestidorState;

    void Awake()
    {
        Instance = this;
    }
    // Use this for initialization
    void OnEnable()
    {
        if (BuyInfoButtom != null) BuyInfoButtom.SetActive(false);
        if (MainManager.IsDeepLinking &&
            MainManager.DeepLinkinParameters != null &&
            MainManager.DeepLinkinParameters.ContainsKey("idVirtualGood"))
        {
            DressVirtualGood(MainManager.DeepLinkinParameters["idVirtualGood"] as string);
            // MainManager.DeepLinkinParameters["idUser"];
        }
        mOldAvatarDesciptor = UserAPI.AvatarDesciptor.Copy();
        EnableTopMenu(true);
        ShowVestidor();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ChangeVestidorState(VestidorState newState)
    {

#if !PRE && !PRO
//        if (MainManager.IsDeepLinking) ModalTextOnly.ShowText(MainManager.DeepLinkingURL);
#endif
        if (newState != currentVestidorState)
        {
            switch (newState)
            {
                case VestidorState.SELECT_AVATAR:
                    EnableTopMenu(false);
                    cameraAvatarSelector.SetActive(true);
                    SecondPlaneAvatarSelect.SetActive(true);
                    cameraVestidor.SetActive(false);
                    SecondPlaneVestidor.SetActive(false);
                    gameObject.GetComponentInChildren<AsociateWithMainCamera>().SetCameraToAssociate(cameraAvatarSelector.GetComponent<Camera>());

                    ShowScreen(AvatarSelectionScreen);
                    break;

                case VestidorState.VESTIDOR:
                    EnableTopMenu(true);
                    cameraAvatarSelector.SetActive(false);
                    SecondPlaneAvatarSelect.SetActive(false);
                    cameraVestidor.SetActive(true);
                    SecondPlaneVestidor.SetActive(true);
                    gameObject.GetComponentInChildren<AsociateWithMainCamera>().SetCameraToAssociate(cameraVestidor.GetComponent<Camera>());

                    ShowScreen(VestidorScreen);
                    break;
                case VestidorState.LANDING_PAGE:
					EnableTopMenu(true);
                    cameraAvatarSelector.SetActive(false);
                    SecondPlaneAvatarSelect.SetActive(false);
                    cameraVestidor.SetActive(true);
                    SecondPlaneVestidor.SetActive(true);
                    gameObject.GetComponentInChildren<AsociateWithMainCamera>().SetCameraToAssociate(cameraVestidor.GetComponent<Camera>());
                    ShowScreen(lobbyScreen);
                    break;
            }
		//	lastVestidorState = currentVestidorState == VestidorState.NONE ? newState : currentVestidorState;
            currentVestidorState = newState;
        }
    }

    void EnableTopMenu(bool val)
    {
        TopMenu.SetActive(val);	
    }
	       
	public void TryToDressPlayer(ClothSlot prenda)
    {
        currentPrenda = prenda;

        //if (currentPrenda == prenda) return;
        DressVirtualGood( currentPrenda.virtualGood,true, currentPrenda.virtualGood.count == 0);

		// Actualizamos la lista para que marque como seleccionados las cosas que tengo puestas
		ClothesListController.Instance.UpdateSelectedSlots ();

        if (currentPrenda != null)
        {
            BuyInfoButtom.SetActive(true);
            if (currentPrenda.virtualGood.count != 0) BuyInfoButtom.GetComponentInChildren<Text>().text = LanguageManager.Instance.GetTextValue("TVB.Button.Info");
            else BuyInfoButtom.GetComponentInChildren<Text>().text = LanguageManager.Instance.GetTextValue("TVB.Button.Buy");
        }
        else
            BuyInfoButtom.SetActive(false);
    }


	ModalLayout CurrentModalLayout;
    public void InfoBuyVirtualGood()
    {
		// Tenemos la prenda seleccionada en posesión?
		bool currentlyPurchasedClothing = currentPrenda.virtualGood.count != 0;
		//Tenemos suficiente dinero?
        bool EnoughMoney = currentPrenda.virtualGood.Price <= UserAPI.Instance.Points;

		// Si tenemos la prenda
		if (currentlyPurchasedClothing) {
			// Hay que mostrar una modal con el layout de INFO
			CurrentModalLayout = ModalLayout.SINGLE_CONTENT_INFO;
		}
		else {
            CurrentModalLayout = ModalLayout.SINGLE_CONTENT_BUY_ITEM;
		}

		OpenModalScreen ();
    }

	public void OpenModalScreen() {
		
		if (ModalPopUpScreen == null) {
			Debug.LogError("[VestidorCanvasController in " + name + "]: \"ModalPopUpScreen\" es null.");
			return;
		}
		
		// Lanzamos la modal, solo si está cerrada previamente.
		ModalPopUpScreen.IsOpen = false;
		StartCoroutine (ModalCloseBeforeOpenAgain(CurrentModalLayout));
	}
	
	
	IEnumerator ModalCloseBeforeOpenAgain(ModalLayout newModalLayout) {
		
		while (ModalPopUpScreen.InOpenState) {
			yield return null;
		}
		
		ModalPopUpScreen.IsOpen = true;
		ModalPopUpScreen.GetComponent<CanvasGroup>().interactable = true;
		
		VestidorModalManager modalManager = ModalPopUpScreen.GetComponent<VestidorModalManager> ();
		modalManager.CurrentModalLayout = newModalLayout;
	}



    public void DressVirtualGood(string GUID)
    {
        DressVirtualGood(UserAPI.VirtualGoodsDesciptor.GetByGUID(GUID), false);
    }

    public void DressVirtualGood(VirtualGoodsAPI.VirtualGood virtualGood, bool loadmodel = true, bool temporal=false)
    {

        if (virtualGood == null) return;

        AvatarAPI tmp = UserAPI.AvatarDesciptor.Copy();
        switch (virtualGood.IdSubType) {
            case "HTORSO":
            case "MTORSO":
                if (UserAPI.AvatarDesciptor.Torso == virtualGood.GUID)
                {
                    currentPrenda = null;
                    UserAPI.AvatarDesciptor.Torso = null;
                }
                else
                    UserAPI.AvatarDesciptor.Torso = virtualGood.GUID;
                UserAPI.AvatarDesciptor.Pack = null;
                break;
            case "HLEG":
            case "MLEG":
                if (UserAPI.AvatarDesciptor.Legs == virtualGood.GUID)
                {
                    currentPrenda = null;
                    UserAPI.AvatarDesciptor.Legs = null;
                }
                else
                    UserAPI.AvatarDesciptor.Legs = virtualGood.GUID;
                UserAPI.AvatarDesciptor.Pack = null;
                break;
            case "HSHOE":
            case "MSHOE":
			if (UserAPI.AvatarDesciptor.Feet == virtualGood.GUID) {
                    currentPrenda = null;
					UserAPI.AvatarDesciptor.Feet = null;
			}
			else
                    UserAPI.AvatarDesciptor.Feet = virtualGood.GUID;
                //                    UserAPI.AvatarDesciptor.Pack = null;
                break;
            case "HCOMPLIMENT":
            case "MCOMPLIMENT":
                if (UserAPI.AvatarDesciptor.Compliment == virtualGood.GUID)
                {
                    currentPrenda = null;
                    UserAPI.AvatarDesciptor.Compliment = null;
                }
                else
                    UserAPI.AvatarDesciptor.Compliment = virtualGood.GUID;
                //                    UserAPI.AvatarDesciptor.Pack = null;
                break;
            case "HHAT":
            case "MHAT":
                if (UserAPI.AvatarDesciptor.Hat == virtualGood.GUID)
                {
                    currentPrenda = null;
                    UserAPI.AvatarDesciptor.Hat = null;
                }
                else
                    UserAPI.AvatarDesciptor.Hat = virtualGood.GUID;
                //                    UserAPI.AvatarDesciptor.Pack = null;
                break;
            case "HPACK":
            case "MPACK":
                if (UserAPI.AvatarDesciptor.Pack == virtualGood.GUID)
                {
                    currentPrenda = null;
                    UserAPI.AvatarDesciptor.Pack = null;
                }
                else
                    UserAPI.AvatarDesciptor.Pack = virtualGood.GUID;
                break;
        }
        PlayerManager.Instance.SelectedModel = UserAPI.AvatarDesciptor.ToString();
        if (loadmodel) LoadModel();

        if (temporal) {
            BotonAceptar.interactable = false;
            UserAPI.AvatarDesciptor.Paste(tmp);
            PlayerManager.Instance.SelectedModel = UserAPI.AvatarDesciptor.ToString();
        }
        else
            BotonAceptar.interactable = true;
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

    public void ShowVestidor()
    {
        if (isCurrentPopUpOpen)
            TogglePopUpScreen();
        if (PlayerInstance == null && MainManager.VestidorMode != VestidorState.SELECT_AVATAR)
            Invoke("LoadModel", 0.25f);

        ChangeVestidorState(MainManager.VestidorMode);
    }

    void LoadModel()
    {
        StartCoroutine(PlayerManager.Instance.CreateAvatar(PlayerManager.Instance.SelectedModel, (instance) => {
            MyTools.SetLayerRecursively(instance, LayerMask.NameToLayer("Model3D"));
            //Seteamos el Avatar que se muestra en estapantalla
            PlayerInstance = instance;
            PlayerInstance.GetComponent<Rigidbody>().isKinematic = true;
            PlayerInstance.GetComponent<SynchNet>().enabled = false;
            PlayerInstance.transform.localScale = Vector3.one;
            Camera[] cams = new Camera[Camera.allCamerasCount];
            Camera.GetAllCameras(cams);
            Camera best = null;
            foreach ( Camera cam in cams)
                if( cam.name.Contains("[VESTIDOR_LITE]") && cam.isActiveAndEnabled)
                    best = cam;
            var v = best.WorldToViewportPoint(PlayerPosition.position);
            v.z = 10;
            PlayerInstance.transform.position = best.ViewportToWorldPoint(v);
            PlayerInstance.transform.localRotation = Quaternion.Euler(7.3f, 0, 0);
            AddParticles();
        }, PlayerInstance) );
    }

    Transform particles;
    public void AddParticles()
    {
        if (particles == null) particles = (GameObject.Instantiate(Particles) as GameObject).transform;
        particles.position = PlayerInstance.transform.position;
        PlayerInstance.AddComponent<RotateDrag>();
    }

    public void ShowGoodiesShop()
    {
       /*
		if (PlayerInstance != null)
            Destroy(PlayerInstance);

        if (isCurrentPopUpOpen)
            TogglePopUpScreen();

        ShowScreen(GoodiesShopScreen);
        */

		//GameObject.FindGameObjectWithTag ("GameCanvasManager").GetComponent<GameCanvasManager> ().ShowModalScreen (10);
		GoodiesShopController.Show ();
    }

    private void ShowScreen(GUIScreen guiScreen)
    {
        //Debug.LogWarning("[CanvasManager]: GameCanvasManager/ShowScreen() [Función deprecada]: Esta función no garantiza apagar la cámara de segundo plano. ");
        if (currentGUIScreen != null && guiScreen != currentGUIScreen)
        {
            currentGUIScreen.CloseWindow();
            currentGUIScreen.IsOpen = false;
        }

        currentGUIScreen = guiScreen;

        if (currentGUIScreen != null)
        {
            currentGUIScreen.OpenWindow();
            currentGUIScreen.IsOpen = true;
        }
        else {
            Debug.LogWarning("[CanvasManager]: La guiScreen es null. Estás cerrando todas las screens ? ó quizás no has establecido la primera desde el inspector.");
        }
    }

    void HideAllScreens()
    {
        if (PlayerInstance != null)
            Destroy(PlayerInstance);

        if (isCurrentPopUpOpen)
            TogglePopUpScreen();

        ShowScreen(null);
        EnableTopMenu(false);
    }

    public void AcceptChangesAndBackToRoom() {
		HideAllScreens ();
		BackToRoom ();
    }

    public void BackToRoom()
    {
        if (MainManager.IsDeepLinking) {
			Authentication.AzureServices.OpenURL("rmapp://You");
            Application.Quit();
            return;
        }
        MainManager.VestidorMode = VestidorCanvasController_Lite.VestidorState.VESTIDOR; // Siempre volvere al vestidor.
        HideAllScreens ();
		RoomManager.Instance.GotoPreviousRoom ();
    }

    public void AcceptThisAvatar()
    {

        if (UserAPI.Instance != null)
        {
            if (MainManager.VestidorMode == VestidorCanvasController_Lite.VestidorState.SELECT_AVATAR)
            {
                ModalNickInput.Show((nick) =>
                {
                    if (nick != "<EMPTY>")
                    {
                        LoadingCanvasManager.Show("TVB.Message.UpdatingAvatar");
                        UserAPI.Instance.UpdateNick(nick, () =>
                        {
                            UserAPI.Instance.UpdateAvatar();
                            UserAPI.Instance.SendAvatar(PlayerManager.Instance.RenderModel(PlayerInstance), () =>
                            {
                                LoadingCanvasManager.Hide();
                                ModalNickInput.Close();
                                HideAllScreens();
                                if (MainManager.IsDeepLinking) {
                                    Authentication.AzureServices.OpenURL("rmapp://You");
                                    Application.Quit();
                                    return;
                                }
                                else
                                {
                                    BackToRoom();
                                }
                            });
                        }, () =>
                        { // Error
                            LoadingCanvasManager.Hide();
                            ModalTextOnly.ShowText(LanguageManager.Instance.GetTextValue("TVB.Error.NickUsed"));
                        });
                    }
                });
            }
            else
            {
                LoadingCanvasManager.Show("TVB.Message.UpdatingAvatar");
                // Por si tiene algo de prueba...
                PlayerManager.Instance.SelectedModel = UserAPI.AvatarDesciptor.ToString();
                UserAPI.Instance.UpdateAvatar();
                UserAPI.Instance.SendAvatar(PlayerManager.Instance.RenderModel(PlayerInstance), () =>
                {
                    LoadingCanvasManager.Hide();
                    HideAllScreens();
                    BackToRoom();
                });
            }
        }


    }

    public void CancelThisAvatar() {
        UserAPI.AvatarDesciptor.Paste(mOldAvatarDesciptor);
        PlayerManager.Instance.SelectedModel = UserAPI.AvatarDesciptor.ToString();
        HideAllScreens();
        if (MainManager.IsDeepLinking)
        {
            Authentication.AzureServices.OpenURL("rmapp://You");
            Application.Quit();
            return;
        } else {
            BackToRoom();
        }
    }

    public void SetLanguage(string lang)
    {
        MainManager.Instance.ChangeLanguage(lang);
    }

    public void showModalOnlyText(string t)
    {
        ModalTextOnly.ShowText(t);
    }

    public void ShowModalNickInput()
    {
        ModalNickInput.Show();
    }

    public void OnBuy() {
        LoadingCanvasManager.Show("TVB.Message.Buying");
        UserAPI.VirtualGoodsDesciptor.BuyByGUID(currentPrenda.virtualGood.GUID, false, () => {
                LoadingCanvasManager.Hide();
                currentPrenda.SetupSlot(currentPrenda.virtualGood);
                BuyInfoButtom.GetComponentInChildren<Text>().text = LanguageManager.Instance.GetTextValue("TVB.Button.Info");
                DressVirtualGood(currentPrenda.virtualGood, true, currentPrenda.virtualGood.count == 0);
                TogglePopUpScreen();
            }, () => {
                TogglePopUpScreen();
                ModalTextOnly.ShowText(LanguageManager.Instance.GetTextValue("TVB.Error.Buying"));
                LoadingCanvasManager.Hide();
                
            });
    }

    public void OnGoShop()
    {
        Debug.Log(">>>>OnGoShop");
        // currentPrenda
    }


	public void showLastVestidorState() {
		HideAllScreens();

		if (PlayerInstance == null && MainManager.VestidorMode != VestidorState.SELECT_AVATAR)
			Invoke("LoadModel", 0.25f);
		// Forzamos el cambio del vestidor state para volver a su estado anterior
		VestidorState newVestidorState = currentVestidorState;
		currentVestidorState = VestidorState.NONE;

		ChangeVestidorState(newVestidorState);
	}

}