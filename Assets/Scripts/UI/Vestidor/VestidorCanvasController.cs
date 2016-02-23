using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VestidorCanvasController : MonoBehaviour {

	public Transform PlayerPosition;

	private GameObject PlayerInstance;

	// Use this for initialization
	void Start () {
		ShowVestidor ();
	}
	
	// Update is called once per frame
	void Update () {	
		if (PlayerInstance != null)
			PlayerInstance.transform.position = PlayerPosition.position;
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

			modalDetail.TheName.text = prenda.ClothName.text;
			modalDetail.ThePicture.sprite = prenda.Picture.sprite;

			if (EnoughMoney) {
				Debug.Log ("[VestidorCanvas]: Tengo suficiente dinero para comprarlo");
				popUpWindow.CurrentState = PopUpLayout.SINGLE_CONTENT_BUY_ITEM;
				modalDetail.BuyButton.GetComponentInChildren<Text>().text = prenda.Price.text;
			}
			else {
				Debug.Log ("[VestidorCanvas]: No tengo suficiente dinero para Comprarlo");
				popUpWindow.CurrentState = PopUpLayout.SINGLE_CONTENT_GOTO_SHOP;
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

	private bool currentPopUpState;

	public void TogglePopUpScreen() {

		if (ModalPopUpScreen != null) {
			currentPopUpState = !ModalPopUpScreen.IsOpen;
			ModalPopUpScreen.IsOpen = currentPopUpState;
			ModalPopUpScreen.GetComponent<CanvasGroup>().interactable = currentPopUpState;
		}
		else {
			Debug.LogError("[VestidorCanvas]: La ModalPopUpScreen es null. Quizás no se ha establecido en el inspector.");
		}
	}

	public void ShowVestidor() {
		if (currentPopUpState)
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

		if (currentPopUpState)
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
}
