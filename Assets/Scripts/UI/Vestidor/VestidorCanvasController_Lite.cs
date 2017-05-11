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
    public GUIScreen AvatarSelectionScreen;
    public GUIScreen PlayTeaserScreen;

	public GUIPopUpScreen ModalPopUpScreen;

	public GameObject TopMenu;
    public GameObject cameraVestidor;
	public GameObject cameraAvatarSelector;
	public GameObject SecondPlaneVestidor;    
    public GameObject SecondPlaneAvatarSelect;
	public GameObject Particles;
	public GameObject BuyInfoButtom;
	public Text BuyInfoButtonText;
	public Sprite BuyButtonBase;
	public Color BuyButtonTextColor;
	public Sprite InfoButtonBase;
	public Color InfoButtonTextColor;

	public Button BotonAceptar;
    // FER: 02/01/17
	// Para poder desactivar el boton y cargar el precio del paquete.
    public Button BuyInAppBtn;
    public Text PriceInApp;

	private GUIScreen currentGUIScreen;
	private PopUpWindow popUpWindow;
    private DetailedContent2Buttons modalDetail;
    private bool isCurrentPopUpOpen;
    private VestidorState currentVestidorState;
    private AvatarAPI mOldAvatarDesciptor;
	private AvatarAPI tmpAvatar;

	private bool IsFirstLaunch;
	
	public GameObject PlayerInstance { get; set; }
	public ClothSlot currentPrenda { get; set; }
	public static VestidorCanvasController_Lite Instance { get; private set; }

    void Awake()
    {
        Instance = this;
    }
    // Use this for initialization
    void OnEnable()
    {
    // FER: 02/01/17
	// Carga el precio en el teaser.
        if(PriceInApp!=null && GoodiesShopController.Instance!=null) PriceInApp.text = GoodiesShopController.Instance.item7.text;
        if((VirtualGoodsAPI.HasPurchase7 || !UserAPI.Instance.Online) && BuyInAppBtn!=null) BuyInAppBtn.interactable = false;
        Debug.Log(">>> IsEditAvatar "+DeepLinkingManager.IsEditAvatar);
        if (BuyInfoButtom != null) BuyInfoButtom.SetActive(false);
        mOldAvatarDesciptor = UserAPI.AvatarDesciptor.Copy();
		tmpAvatar = UserAPI.AvatarDesciptor.Copy();

		if(ClothesListController.Instance != null)
			ClothesListController.Instance.SetCurrentAvatar (tmpAvatar);
        EnableTopMenu(true);
        ShowVestidor();
    }

    // Update is called once per frame
    private void Update()
	{
		//if(Input.GetKeyDown(KeyCode.Escape) && 
		//	DeepLinkingManager.IsEditAvatar &&
		//    DeepLinkingManager.Parameters != null)
		//	CancelThisAvatar();
    }

    public void ChangeVestidorState(VestidorState newState) {
        if (newState != currentVestidorState)
        {
			if (MainManager.VestidorMode != VestidorState.SELECT_AVATAR) {
				InvokeAvatarIfNeeded();
			}

            switch (newState)
            {
                case VestidorState.SELECT_AVATAR:
                    
                    EnableTopMenu(false);
                    cameraAvatarSelector.SetActive(true);
                    SecondPlaneAvatarSelect.SetActive(true);
                    cameraVestidor.SetActive(false);
                    SecondPlaneVestidor.SetActive(false);
					BuyInfoButtom.SetActive(false);
                    gameObject.GetComponentInChildren<AsociateWithMainCamera>().SetCameraToAssociate(cameraAvatarSelector.GetComponent<Camera>());

                    ShowScreen(AvatarSelectionScreen);
                    break;

                case VestidorState.VESTIDOR:
                    if (DeepLinkingManager.IsEditAvatar &&
                        DeepLinkingManager.Parameters != null &&
                        DeepLinkingManager.Parameters.ContainsKey("idVirtualGood")) {
                        DressVirtualGood(DeepLinkingManager.Parameters["idVirtualGood"] as string);
                        // MainManager.DeepLinkinParameters["idUser"];
                    }
                    EnableTopMenu(true);
                    cameraAvatarSelector.SetActive(false);
                    SecondPlaneAvatarSelect.SetActive(false);
                    cameraVestidor.SetActive(true);
                    SecondPlaneVestidor.SetActive(true);
					//VestidorScreen.GetComponentInChildren<ClothesListController>().ShowTShirtsList();	
					//BuyInfoButtom.SetActive(true);
                    gameObject.GetComponentInChildren<AsociateWithMainCamera>().SetCameraToAssociate(cameraVestidor.GetComponent<Camera>());

                    ShowScreen(VestidorScreen);
					
					//??
					ClothesListController.Instance.SetCurrentAvatar (tmpAvatar);

                    break;

                case VestidorState.LANDING_PAGE:
					IsFirstLaunch = true;
					EnableTopMenu(true);
                    cameraAvatarSelector.SetActive(false);
                    SecondPlaneAvatarSelect.SetActive(false);
                    cameraVestidor.SetActive(true);
                    SecondPlaneVestidor.SetActive(true);
					BuyInfoButtom.SetActive(false);
                    gameObject.GetComponentInChildren<AsociateWithMainCamera>().SetCameraToAssociate(cameraVestidor.GetComponent<Camera>());
//					InvokeAvatarIfNeeded();
									
					ShowScreen(lobbyScreen);
                    break;
            }
		//	lastVestidorState = currentVestidorState == VestidorState.NONE ? newState : currentVestidorState;
            currentVestidorState = newState;
        }
    }

	void InvokeAvatarIfNeeded() {
		if (MainManager.VestidorMode != VestidorState.SELECT_AVATAR) {
			if (PlayerInstance == null){
				Invoke("LoadModel", 0.25f);
            }
			else {
				if (tmpAvatar.ToString() != mOldAvatarDesciptor.ToString()) {
					Invoke("LoadModel", 0.25f);
				}
			}
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
		ClothesListController.Instance.SetCurrentAvatar (tmpAvatar);

        if (currentPrenda != null) {
			BuyInfoButtom.SetActive (true);
			if (currentPrenda.virtualGood.count != 0) {
				BuyInfoButtom.GetComponentInChildren<Text> ().text = LanguageManager.Instance.GetTextValue ("TVB.Button.Info");
				BuyInfoButtom.GetComponent<Image> ().sprite = InfoButtonBase;
				BuyInfoButtonText.color = InfoButtonTextColor;
			}
			else {
				BuyInfoButtom.GetComponentInChildren<Text> ().text = LanguageManager.Instance.GetTextValue ("TVB.Button.Buy");
				BuyInfoButtom.GetComponent<Image> ().sprite = BuyButtonBase;
				BuyInfoButtonText.color = BuyButtonTextColor;
			}
		} else {
			BuyInfoButtom.SetActive (false);
		}

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
                else {
                    UserAPI.AvatarDesciptor.Pack = virtualGood.GUID;


					var mypack = PlayerManager.Instance.GetPackDescriptor(UserAPI.AvatarDesciptor.Pack);
					if(mypack!=null) {
						foreach( var cloth in mypack)
						{
							switch (cloth.Key)
							{
							case "torso":
								UserAPI.AvatarDesciptor.Torso = null;
								break;
							case "piernas":
								UserAPI.AvatarDesciptor.Legs = null;
								break;
							}
						}
					}
				}
                break;
        }
        PlayerManager.Instance.SelectedModel = UserAPI.AvatarDesciptor.ToString();
        if (loadmodel) {
            LoadModel();
        }

		tmpAvatar = UserAPI.AvatarDesciptor.Copy();

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
    }

    public void ShowVestidor()
    {
        AnalyticsManager.Dresser.Enter();
		if (isCurrentPopUpOpen)
			TogglePopUpScreen();
        /*if (PlayerInstance == null && MainManager.VestidorMode != VestidorState.SELECT_AVATAR)
            Invoke("LoadModel", 0.25f);
		*/
        ChangeVestidorState(MainManager.VestidorMode);
    }

    public void ShowClothesShop() {
        
        AnalyticsManager.Dresser.OpenBuy();
        if( Authentication.Instance.CheckOffline()) return;
		if (isCurrentPopUpOpen)
			TogglePopUpScreen();
        /*if (PlayerInstance == null && MainManager.VestidorMode != VestidorState.SELECT_AVATAR)
			Invoke("LoadModel", 0.25f);
		*/
		ChangeVestidorState (VestidorState.VESTIDOR);
	}

	public void ShowLandingPage() {
		if (isCurrentPopUpOpen)
			TogglePopUpScreen();
		/*if (PlayerInstance == null && MainManager.VestidorMode != VestidorState.SELECT_AVATAR)
			Invoke("LoadModel", 0.25f);
		*/
		ChangeVestidorState (VestidorState.LANDING_PAGE);
	}

    void LoadModel()
    {
        StartCoroutine(PlayerManager.Instance.CreateAvatar(PlayerManager.Instance.SelectedModel, (instance) =>
        {
        MyTools.SetLayerRecursively(instance, LayerMask.NameToLayer("Model3D"));
        //Seteamos el Avatar que se muestra en estapantalla
        PlayerInstance = instance;
        PlayerInstance.GetComponent<Rigidbody>().isKinematic = true;
        PlayerInstance.GetComponent<SynchNet>().enabled = false;
        PlayerInstance.transform.localScale = Vector3.one;
        Camera[] cams = new Camera[Camera.allCamerasCount];
        Camera.GetAllCameras(cams);
        Camera best = null;

        foreach (Camera cam in cams)
            if (cam.name.Contains("[VESTIDOR_LITE]") && cam.isActiveAndEnabled)
                best = cam;

        var v = best.WorldToViewportPoint(PlayerPosition.position);
        v.z = 10;
        PlayerInstance.transform.position = best.ViewportToWorldPoint(v);
        PlayerInstance.transform.localRotation = Quaternion.Euler(7.3f, 0, 0);
        AddParticles();

        PlayerInstance.GetComponent<Animator>().SetTrigger("ChangingClothes");
        ParticleSystem pEmitter = particles.GetChild(0).GetChild(0).GetComponent<ParticleSystem>();
        if(pEmitter != null)
            {
                pEmitter.Play();
            }

        }, PlayerInstance) );
    }

    Transform particles;
    public void AddParticles()
    {
        if (particles == null) particles = Instantiate(Particles).transform;
        particles.position = PlayerInstance.transform.position;
        PlayerInstance.AddComponent<RotateDrag>();
    }

    public void ShowGoodiesShop()
    {
        if( Authentication.Instance.CheckOffline()) return;
#if UNITY_WSA
        ModalTextOnly.ShowText(LanguageManager.Instance.GetTextValue("TVB.Error.CantBuyOnWindows"), (state) => { Authentication.AzureServices.OpenURL("rmapp://You"); });
#else
        GoodiesShopController.Show ();
#endif
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
        //else {
        //    Debug.LogWarning("[CanvasManager]: La guiScreen es null. Estás cerrando todas las screens ? ó quizás no has establecido la primera desde el inspector.");
        //}
    }

    void HideAllScreens()
    {
        if (PlayerInstance != null && !IsFirstLaunch)
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

    public void SetVRMode()
    {
        BackToRoom();
        MainManager.Instance.SetVrMode();
    }

    public void BackToRoom()
    {
        if (DeepLinkingManager.IsEditAvatar) {
			Authentication.AzureServices.OpenURL("rmapp://You");
            Application.Quit();
            return;
        }
        MainManager.VestidorMode = VestidorCanvasController_Lite.VestidorState.VESTIDOR; // Siempre volvere al vestidor.
        HideAllScreens ();

		if (IsFirstLaunch && currentVestidorState != VestidorState.LANDING_PAGE)
			ShowLandingPage ();
		else {
			IsFirstLaunch = false;
			RoomManager.Instance.GotoPreviousRoom ();
		}
    }

    public void AcceptThisAvatar()
    {
        if (UserAPI.Instance != null) {
            if (MainManager.VestidorMode == VestidorCanvasController_Lite.VestidorState.SELECT_AVATAR) {
                ModalNickInput.Show((nick) => {
                    if (nick != "<EMPTY>") {
                        LoadingCanvasManager.Show("TVB.Message.UpdatingAvatar");
                        UserAPI.Instance.UpdateNick(nick, () => {
							UserAPI.VirtualGoodsDesciptor.FilterBySex();
							UserAPI.Instance.Nick = nick;
							Authentication.AzureServices.CreateProfileAvatar( UserAPI.AvatarDesciptor.GetProperties(), (res) =>{
								UserAPI.Instance.SendAvatar(PlayerManager.Instance.RenderModel(PlayerInstance), () => {
									LoadingCanvasManager.Hide();
									ModalNickInput.Close();
									HideAllScreens();
                                    MainManager.VestidorMode = VestidorCanvasController_Lite.VestidorState.VESTIDOR;
									if (DeepLinkingManager.IsEditAvatar) {
										Authentication.AzureServices.OpenURL("rmapp://You");
										Application.Quit();
										return;
									}
									else
									{
										BackToRoom();
									}

                                    AnalyticsManager.Dresser.CloseAccept();
                                    AnalyticsManager.AvatarSelection.SelectModel();
								});
							},(error)=>{
								Debug.LogError("ERROR CreateProfileAvatar "+error);
							});
                        }, () => { // Error
                            LoadingCanvasManager.Hide();
                            ModalTextOnly.ShowText(LanguageManager.Instance.GetTextValue("TVB.Error.NickUsed"));
                        });
                    }
                });
            }
            else {
                LoadingCanvasManager.Show("TVB.Message.UpdatingAvatar");
                // Por si tiene algo de prueba...
                PlayerManager.Instance.SelectedModel = UserAPI.AvatarDesciptor.ToString();

				mOldAvatarDesciptor = UserAPI.AvatarDesciptor.Copy();

                UserAPI.Instance.UpdateAvatar();
                UserAPI.Instance.SendAvatar(PlayerManager.Instance.RenderModel(PlayerInstance), () => {
                    LoadingCanvasManager.Hide();
                    HideAllScreens();
					BackToRoom();

                    AnalyticsManager.AvatarSelection.SelectModel();
                });
            }
        }
    }

    public void CancelThisAvatar() {
        AnalyticsManager.Dresser.CloseCancel();
        UserAPI.AvatarDesciptor.Paste(mOldAvatarDesciptor);
        PlayerManager.Instance.SelectedModel = UserAPI.AvatarDesciptor.ToString();
        HideAllScreens();
        if (DeepLinkingManager.IsEditAvatar) {
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
                AnalyticsManager.Dresser.BuySuccess(currentPrenda);
            }, () => {
                TogglePopUpScreen();
                ModalTextOnly.ShowText(LanguageManager.Instance.GetTextValue("TVB.Error.Buying"));
                LoadingCanvasManager.Hide();
                AnalyticsManager.Dresser.BuyCancel(currentPrenda);
            });
    }

    public void OnGoShop()
    {
        Debug.Log(">>>>OnGoShop");
        // currentPrenda
    }

    public void Opciones(){
        ModalContents.Instance.ShowModalScreen(10);
    }


	public void showLastVestidorState() {
		HideAllScreens();

		/*if (PlayerInstance == null && MainManager.VestidorMode != VestidorState.SELECT_AVATAR)
			Invoke("LoadModel", 0.25f);
		 */
		// Forzamos el cambio del vestidor state para volver a su estado anterior
		VestidorState newVestidorState = currentVestidorState;
		currentVestidorState = VestidorState.NONE;

		ChangeVestidorState(newVestidorState);
	}
    // FER: 02/01/17
	// Compra de todos los contenidos.
    public void BuyInApp() {
        MainManager.Instance.OnPurchaseInApp = ()=>{
            BuyInAppBtn.interactable = false;
        };
		GoodiesShopController.Instance.Product_ClickHandle("_rmvt_pack_all");
    }
}