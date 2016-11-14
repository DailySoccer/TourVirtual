using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VestidorCanvasController : MonoBehaviour {

	public Transform PlayerPosition;

	private GameObject PlayerInstance;

	// Use this for initialization
	void OnEnable () {
		EnableTopMenu(true);
		ShowVestidor ();
	}
	
	// Update is called once per frame
	void Update () {	
		if (PlayerInstance != null)
			PlayerInstance.transform.position = PlayerPosition.position;
	}

	void EnableTopMenu(bool val) {
		TopMenu.SetActive (val);
	}

	public void TryToDressPlayer(ClothSlot prenda) {

		bool CanDressPlayer = false;
		bool EnoughMoney = false;

		if (CanDressPlayer) {
			Debug.Log ("[VestidorCanvas]: Se puede vestir el Player con esto");

		} else {
			Debug.Log ("[VestidorCanvas]: No se puede vestir el Player con esto");
			popUpWindow = ModalPopUpScreen.GetComponent<PopUpWindow>();
			modalDetail = ModalPopUpScreen.GetComponentInChildren<DetailedContent2Buttons> ();

			modalDetail.TheName.text = prenda.virtualGood.Description;
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
		}
	}

	//////////////////// Control de ventanas Modales//////////////////// 
	public GUIScreen VestidorScreen;
	public GUIScreen GoodiesShopScreen;
	private GUIScreen currentGUIScreen;

	public GUIPopUpScreen ModalPopUpScreen;
	private PopUpWindow popUpWindow;
	private DetailedContent2Buttons modalDetail;

	public GameObject TopMenu;


	private bool isCurrentPopUpOpen;

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

		if (PlayerInstance == null)
			StartCoroutine( PlayerManager.Instance.CreateAvatar(PlayerManager.Instance.SelectedModel, (instance) => {
				//Seteamos el Avatar que se muestra en estapantalla
				PlayerInstance = instance;
				PlayerInstance.GetComponent<Rigidbody>().isKinematic = true;
				PlayerInstance.GetComponent<SynchNet>().enabled = false;
				PlayerInstance.transform.localScale = Vector3.one * 10;				
			}) );

		ShowScreen(VestidorScreen);	
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
		Debug.Log ("[VestidorCanvas]: Guardo la nueva vestimenta y vuelvo al tour");
		HideAllScreens ();
		BackToRoom ();
	}

	public void BackToRoom() {
        if (DeepLinkingManager.IsEditAvatar) {
			Authentication.AzureServices.OpenURL("rmapp://You");
            Application.Quit();
            return;
        }
		HideAllScreens ();
		RoomManager.Instance.GotoPreviousRoom ();
	}
}
