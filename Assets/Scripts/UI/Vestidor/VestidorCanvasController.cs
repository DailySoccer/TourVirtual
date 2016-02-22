using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VestidorCanvasController : MonoBehaviour {

	public Transform PlayerPosition;

	private GameObject PlayerInstance;

	// Use this for initialization
	void Start () {

		StartCoroutine( PlayerManager.Instance.CreateAvatar(PlayerManager.Instance.SelectedModel, (instance)=>{

			//Seteamos el Avatar que se muestra en estapantalla
			PlayerInstance = instance;
			PlayerInstance.GetComponent<Rigidbody>().isKinematic = true;
			PlayerInstance.GetComponent<SynchNet>().enabled = false;
			PlayerInstance.transform.localScale = Vector3.one * 10;
			
		}) );
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

	public GUIPopUpScreen ModalPopUpScreen;

	private PopUpWindow popUpWindow;
	private DetailedContent2Buttons modalDetail;

	public void TogglePopUpScreen() {

		if (ModalPopUpScreen != null) {
			bool currentPopUpState = !ModalPopUpScreen.IsOpen;
			ModalPopUpScreen.IsOpen = currentPopUpState;
			ModalPopUpScreen.GetComponent<CanvasGroup>().interactable = currentPopUpState;
		}
		else {
			Debug.LogError("[VestidorCanvas]: La ModalPopUpScreen es null. Quizás no se ha establecido en el inspector.");
		}
	}
}
