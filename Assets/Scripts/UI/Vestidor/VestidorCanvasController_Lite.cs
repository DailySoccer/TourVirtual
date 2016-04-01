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
        VESTIDOR
    }

    public Transform PlayerPosition;
    //////////////////// Control de ventanas Modales//////////////////// 
    public GUIScreen VestidorScreen;
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
            }
            currentVestidorState = newState;
        }
    }

    void EnableTopMenu(bool val)
    {
        TopMenu.SetActive(val);
    }

    ClothSlot currentPrenda;
    public void TryToDressPlayer(ClothSlot prenda)
    {
        if (currentPrenda == prenda) return;
        currentPrenda = prenda;

        DressVirtualGood(currentPrenda.virtualGood,true, currentPrenda.virtualGood.count == 0);

        if (!BuyInfoButtom.GetActive()) BuyInfoButtom.SetActive(true);
        if (currentPrenda.virtualGood.count != 0) BuyInfoButtom.GetComponentInChildren<Text>().text = LanguageManager.Instance.GetTextValue("TVB.Button.Info");
        else BuyInfoButtom.GetComponentInChildren<Text>().text = LanguageManager.Instance.GetTextValue("TVB.Button.Buy");


    }

    public void InfoBuyVirtualGood()
    {
        bool EnoughMoney = currentPrenda.virtualGood.Price<= UserAPI.Instance.Points;

        popUpWindow = ModalPopUpScreen.GetComponent<PopUpWindow>();
        modalDetail = ModalPopUpScreen.GetComponentInChildren<DetailedContent2Buttons>();
        modalDetail.TheName.text = currentPrenda.virtualGood.Description;
        StartCoroutine(MyTools.LoadSpriteFromURL(currentPrenda.virtualGood.Thumb, modalDetail.ThePicture.gameObject));

        if (currentPrenda.virtualGood.count != 0)
        { // Lo tengo, presento informacion.
            popUpWindow.SetState(ModalLayout.SINGLE_CONTENT_INFO);
        }
        else {
            if (EnoughMoney)
            {                
                popUpWindow.SetState(ModalLayout.SINGLE_CONTENT_BUY_ITEM);
                try
                {
                    modalDetail.BuyButton.GetComponentInChildren<Text>().text = currentPrenda.Price.text;
                }
                catch { }
            }
            else {
                ModalTextOnly.ShowText(LanguageManager.Instance.GetTextValue("TVB.Error.NoCredit"),()=> {
                    //Authentication.AzureServices.OpenURL("rmapp://You");
                });
//                popUpWindow.SetState(ModalLayout.SINGLE_CONTENT_GOTO_SHOP);
            }
        }
        TogglePopUpScreen();

    }

    public void DressVirtualGood(string GUID)
    {
        DressVirtualGood(UserAPI.VirtualGoodsDesciptor.GetByGUID(GUID), false);
    }

    public void DressVirtualGood(VirtualGoodsAPI.VirtualGood virtualGood, bool loadmodel = true, bool temporal=false)
    {

        if (virtualGood == null)
            return;
        AvatarAPI tmp = UserAPI.AvatarDesciptor.Copy();
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
                //                    UserAPI.AvatarDesciptor.Pack = null;
                break;
            case "HCOMPLIMENT":
            case "MCOMPLIMENT":
                UserAPI.AvatarDesciptor.Compliment = virtualGood.GUID;
                //                    UserAPI.AvatarDesciptor.Pack = null;
                break;
            case "HHAT":
            case "MHAT":
                UserAPI.AvatarDesciptor.Hat = virtualGood.GUID;
                //                    UserAPI.AvatarDesciptor.Pack = null;
                break;
            case "HPACK":
            case "MPACK":
                UserAPI.AvatarDesciptor.Pack = virtualGood.GUID;
                break;
        }
        PlayerManager.Instance.SelectedModel = UserAPI.AvatarDesciptor.ToString();
        if (loadmodel) LoadModel();

        if (temporal) {
            BotonAceptar.interactable = false;
            UserAPI.AvatarDesciptor.Paste(tmp);
        }
        else
            BotonAceptar.interactable = true;
    }

    public void TogglePopUpScreen()
    {

        if (ModalPopUpScreen != null)
        {
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
        if (PlayerInstance == null && MainManager.VestidorMode == VestidorState.VESTIDOR)
            LoadModel();

        ChangeVestidorState(MainManager.VestidorMode);
    }

    void LoadModel()
    {
        if (PlayerInstance != null) Destroy(PlayerInstance);
        StartCoroutine(PlayerManager.Instance.CreateAvatar(PlayerManager.Instance.SelectedModel, (instance) =>
        {
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
        }));
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
        if (PlayerInstance != null)
            Destroy(PlayerInstance);

        if (isCurrentPopUpOpen)
            TogglePopUpScreen();

        ShowScreen(GoodiesShopScreen);
    }

    private void ShowScreen(GUIScreen guiScreen)
    {
        Debug.LogWarning("[CanvasManager]: GameCanvasManager/ShowScreen() [Función deprecada]: Esta función no garantiza apagar la cámara de segundo plano. ");
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
            Debug.LogError("[CanvasManager]: La guiScreen es null. Quizás no has establecido la primera desde el inspector.");
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

    public void AcceptChangesAndBackToRoom()
    {
#if !LITE_VERSION
		Debug.Log ("[VestidorCanvas]: Guardo la nueva vestimenta y vuelvo al tour");
		HideAllScreens ();
		BackToRoom ();
#else
        Debug.LogError("Aceptar cambios Cerrar App y Volver");

#endif
    }

    public void BackToRoom()
    {
#if !LITE_VERSION
        if (MainManager.IsDeepLinking) {
			Authentication.AzureServices.OpenURL("rmapp://You");
            Application.Quit();
            return;
        }
		HideAllScreens ();
		RoomManager.Instance.GotoPreviousRoom ();
#else

        Debug.LogError("Cerrar App y Volver");
#endif
    }

    public void AcceptThisAvatar()
    {
#if !LITE_VERSION

#else
        if (UserAPI.Instance != null)
        {
            if (MainManager.VestidorMode == VestidorCanvasController_Lite.VestidorState.SELECT_AVATAR)
            {
                ModalNickInput.Show((nick) =>
                {
                    if (nick != "<EMPTY>")
                    {
                        LoadingCanvasManager.Show();
                        UserAPI.Instance.UpdateNick(nick, () =>
                         {
                             UserAPI.Instance.UpdateAvatar();
                             UserAPI.Instance.SendAvatar(PlayerManager.Instance.RenderModel(PlayerInstance), () =>
                             {
                                 LoadingCanvasManager.Hide();
                                 ModalNickInput.Close();
                                 if (MainManager.IsDeepLinking)
                                 {
                                     Authentication.AzureServices.OpenURL("rmapp://You");
                                     Application.Quit();
                                     return;
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
            else {
                LoadingCanvasManager.Show();
                // Por si tiene algo de prueba...
                PlayerManager.Instance.SelectedModel = UserAPI.AvatarDesciptor.ToString();
                UserAPI.Instance.UpdateAvatar();
                UserAPI.Instance.SendAvatar(PlayerManager.Instance.RenderModel(PlayerInstance), () =>
                                            {
                                                LoadingCanvasManager.Hide();
                                                if (MainManager.IsDeepLinking)
                                                {
                                                    Authentication.AzureServices.OpenURL("rmapp://You");
                                                    Application.Quit();
                                                    return;
                                                }
                                            });
            }
        }
#endif
    }

    public void CancelThisAvatar()
    {
#if !LITE_VERSION

#else
        if (MainManager.IsDeepLinking)
        {
            Authentication.AzureServices.OpenURL("rmapp://You");
            Application.Quit();
            return;
        }
#endif
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

        LoadingCanvasManager.Show();
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

}