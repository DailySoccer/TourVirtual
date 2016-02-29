using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections;

public enum ModalLayout {
	BLANK,
	PURCHASED_GRID_CONTENT,
	PURCHASED_LIST_CONTENT,
	ACHIEVEMENTS_GRID_CONTENT,
	SINGLE_CONTENT_GOTO_SHOP,
	SINGLE_CONTENT_BUY_ITEM,
	SINGLE_CONTENT_SARE,
	THIRDS_PROFILE_CONTENT
}

public class PopUpWindow : MonoBehaviour {
	
	public GameObject CloseButton;

	// Titulos
	public GameObject StandardTitle;
	public GameObject ThirdsProfileTitle;

	//Contenidos
	public GameObject PurchasedPackGridContent;
	public GameObject PurchasedPackListContent;
	public GameObject AchievementGridContent;
	public GameObject SingleContent;
	public GameObject ThirdsProfileContent;

	// Contenidos de las listas
	public GameObject PurchasedItemGridSlot;
	public GameObject PurchasedContenidoVerticalListSlot;
	public GameObject AchievementSlot;
	public GameObject ProfileScreenController;
	
	private Text _CurrentStandardTitleText;
	private Text _CurrentThirdsProfileTitleText;

	private DetailedContent2Buttons SingleContentLayOut;

	// Use this for initialization
	void Start () {
		StandardTitle.SetActive(true);
		_CurrentStandardTitleText = StandardTitle.GetComponent<Text> ();
		if (ThirdsProfileTitle != null) {
			ThirdsProfileTitle.SetActive (true);
		} else {
			Debug.LogWarning("No está establecido el GameObject 'ThirdsProfileTitle'. Si es para el vestidor, no es necesario");
		}

		if (_CurrentThirdsProfileTitleText != null)
			_CurrentThirdsProfileTitleText = ThirdsProfileTitle.GetComponentsInChildren<Text>().Where(t => t.name == "User Other Name").First();

		SingleContentLayOut = SingleContent.GetComponent<DetailedContent2Buttons> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void SetState(ModalLayout newPopUpLayout) {

		ResetWindow ();

		switch (newPopUpLayout) {
		case ModalLayout.BLANK:
			break;
		case ModalLayout.PURCHASED_GRID_CONTENT:
			PurchasedPackGridContent.SetActive(true);
			StandardTitle.SetActive (true);
			_CurrentStandardTitleText.text = "PACKS COMPRADOS";
			break;
			
		case ModalLayout.PURCHASED_LIST_CONTENT:
			PurchasedPackListContent.SetActive(true);
			StandardTitle.SetActive (true);
			_CurrentStandardTitleText.text = "CONTENIDO DEL PACK";
			break;
			
		case ModalLayout.ACHIEVEMENTS_GRID_CONTENT:
			AchievementGridContent.SetActive(true);
			StandardTitle.SetActive (true);
			_CurrentStandardTitleText.text = "LISTADO DE LOGROS";
			break;
			
		case ModalLayout.SINGLE_CONTENT_GOTO_SHOP:
			SingleContent.SetActive(true);
			StandardTitle.SetActive (true);
			_CurrentStandardTitleText.text = "FONDOS INSUFICIENTES";
			SingleContentLayOut.CurrentLayout = DetailedContent2ButtonsLayout.GOTOSHOP;
			break;
			
		case ModalLayout.SINGLE_CONTENT_BUY_ITEM:
			SingleContent.SetActive(true);
			StandardTitle.SetActive (true);
			_CurrentStandardTitleText.text = "ADQUIERE ESTE PRODUCTO";
			SingleContentLayOut.CurrentLayout = DetailedContent2ButtonsLayout.BUYITEM;
			break;
			
		case ModalLayout.SINGLE_CONTENT_SARE:
			SingleContent.SetActive(true);
			StandardTitle.SetActive (true);
			_CurrentStandardTitleText.text = "COMPARTE TU ADQUISICIÓN";
			SingleContentLayOut.CurrentLayout = DetailedContent2ButtonsLayout.SHARE;
			break;
			
		case ModalLayout.THIRDS_PROFILE_CONTENT:
			ThirdsProfileTitle.SetActive(true);
			_CurrentThirdsProfileTitleText.text = "NOMBRE DE USUARIO";
			ThirdsProfileContent.SetActive(true);
			break;			
		}
	}

	public void ResetWindow() {
		_CurrentStandardTitleText.text = "";
		StandardTitle.SetActive (false);

		if (_CurrentThirdsProfileTitleText != null)
			_CurrentThirdsProfileTitleText.text = "";

		if (ThirdsProfileTitle != null)
			ThirdsProfileTitle.SetActive (false);

		if (ThirdsProfileContent != null)
			ThirdsProfileContent.SetActive (false);

		if (PurchasedPackGridContent != null) {
			foreach (Transform t in PurchasedPackGridContent.transform)
				Destroy (t);
			PurchasedPackGridContent.SetActive (false);
		}

		if (PurchasedPackListContent != null){
			foreach(Transform t in PurchasedPackListContent.transform)
				Destroy (t);
			PurchasedPackListContent.SetActive (false);
		}

		if (AchievementGridContent != null) {
			foreach(Transform t in AchievementGridContent.transform)
				Destroy (t);
			AchievementGridContent.SetActive (false);
		}

		//SingleContentLayOut.CurrentLayout = DetailedContent2ButtonsLayout.BUYITEM;
		SingleContent.SetActive(false);

		CloseButton.SetActive (true);
	}
}
