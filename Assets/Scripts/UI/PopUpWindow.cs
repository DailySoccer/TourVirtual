using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public enum ModalLayout {
	BLANK,
	PURCHASED_PACKS_GRID,
	PURCHASED_PACK_CONTENT_LIST,
	ACHIEVEMENTS_GRID,
	SINGLE_CONTENT_GOTO_SHOP,
	SINGLE_CONTENT_BUY_ITEM,
	SINGLE_CONTENT_SARE,
	THIRDS_PROFILE_CONTENT
}

public class PopUpWindow : MonoBehaviour {
	
	public GameObject CloseButton;

	// Titulos
	//public GameObject StandardTitle;
	public Text StandardTitleText;

	public GameObject ThirdsProfileTitle;
	public Text ThirdsProfileTitleText;

	//Contenidos
	public GameObject PurchasedPackGridContent;
	public GameObject PurchasedPackGridContentList;
	public GameObject PurchasedPackItemGridSlot;
	private List<GameObject> PurchasedPaksGridSlots = new List<GameObject>();

	public GameObject PurchasedPackListContent;
	public GameObject PurchasedPackListContentList;
	public GameObject PurchasedContenidoVerticalListSlot;

	public GameObject AchievementGridContent;
	public GameObject AchievementGridContentList;
	public GameObject AchievementSlot;
	private List<GameObject> AchievementsGridSlots = new List<GameObject>();

	public GameObject SingleContent;

	ThirdProfileController ThirdsProfile;
	public GameObject ProfileScreenController;

	private DetailedContent2Buttons SingleContentLayOut;

	public GameCanvasManager TheGameCanvas;

	// Use this for initialization
	void Start () {
		StandardTitleText.gameObject.SetActive(true);
		//CurrentStandardTitleText = StandardTitle.GetComponent<Text> ();
		if (ThirdsProfileTitle != null) {
			ThirdsProfileTitle.SetActive (true);
		} else {
			Debug.LogWarning("No está establecido el GameObject 'ThirdsProfileTitle'. Si es para el vestidor, no es necesario");
		}

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
		case ModalLayout.PURCHASED_PACKS_GRID:
			PurchasedPackGridContent.SetActive(true);
			StandardTitleText.gameObject.SetActive (true);
			StandardTitleText.text = "PACKS COMPRADOS";
			break;
			
		case ModalLayout.PURCHASED_PACK_CONTENT_LIST:
			PurchasedPackListContent.SetActive(true);
			StandardTitleText.gameObject.SetActive (true);
			StandardTitleText.text = "CONTENIDO DEL PACK";
			break;
			
		case ModalLayout.ACHIEVEMENTS_GRID:
			AchievementGridContent.SetActive(true);
			StandardTitleText.gameObject.SetActive (true);
			StandardTitleText.text = "LISTADO DE LOGROS";
			break;
			
		case ModalLayout.SINGLE_CONTENT_GOTO_SHOP:
			SingleContent.SetActive(true);
			StandardTitleText.gameObject.SetActive (true);
			StandardTitleText.text = "FONDOS INSUFICIENTES";
			SingleContentLayOut.CurrentLayout = DetailedContent2ButtonsLayout.GOTOSHOP;
			break;
			
		case ModalLayout.SINGLE_CONTENT_BUY_ITEM:
			SingleContent.SetActive(true);
			StandardTitleText.gameObject.SetActive (true);
			StandardTitleText.text = "ADQUIERE ESTE PRODUCTO";
			SingleContentLayOut.CurrentLayout = DetailedContent2ButtonsLayout.BUYITEM;
			break;
			
		case ModalLayout.SINGLE_CONTENT_SARE:
			SingleContent.SetActive(true);
			StandardTitleText.gameObject.SetActive (true);
			StandardTitleText.text = "COMPARTE TU ADQUISICIÓN";
			SingleContentLayOut.CurrentLayout = DetailedContent2ButtonsLayout.SHARE;
			break;
			
		case ModalLayout.THIRDS_PROFILE_CONTENT:
			ThirdsProfileTitle.SetActive(true);
			ThirdsProfileTitleText.text = "NOMBRE DE USUARIO";
			ProfileScreenController.SetActive(true);
			break;			
		}
	}

	public void ResetWindow() {
		if (StandardTitleText != null)
			StandardTitleText.text = "";

		if (StandardTitleText != null)
			StandardTitleText.gameObject.SetActive (false);

		if (ThirdsProfileTitleText != null)
			ThirdsProfileTitleText.text = "";

		if (ThirdsProfileTitle != null)
			ThirdsProfileTitle.SetActive (false);

		if (ProfileScreenController != null)
			ProfileScreenController.SetActive (false);

		/// Limpieza del grid de contenidos comprados
		if (PurchasedPackGridContentList != null) {
			foreach (Transform t in PurchasedPackGridContent.transform)
				Destroy (t);
			PurchasedPackGridContent.SetActive (false);
		}
		CleanPurchaserGridContent ();
	

		if (PurchasedPackListContentList != null){
			foreach(Transform t in PurchasedPackListContent.transform)
				Destroy (t);
			PurchasedPackListContent.SetActive (false);
		}
	
		/// Limpieza del grid de logros
		if (AchievementGridContent != null) {
			foreach(Transform t in AchievementGridContent.transform)
				Destroy (t);
			AchievementGridContent.SetActive (false);
		}
		CleanAchievementsGridContent ();

		//SingleContentLayOut.CurrentLayout = DetailedContent2ButtonsLayout.BUYITEM;
		SingleContent.SetActive(false);

		CloseButton.SetActive (true);
	}

	/// <summary>
	/// Rellena la lista de packs obtenidos
	/// </summary>
	public void SetupPurchasedGridContent() {

		CleanPurchaserGridContent ();

		foreach (var c in UserAPI.Contents.Contents) {	
			ContentAPI.Content ct = (c.Value as ContentAPI.Content);
			// TODO: rellenar el contenido de cada lista
			if (ct.owned) {
				GameObject slot = Instantiate (PurchasedPackItemGridSlot);
				slot.transform.SetParent(PurchasedPackGridContentList.transform);
				slot.GetComponent<PurchasedItemSlot> ().SetupSlot (this, ct.Title, ct.ThumbURL);
				slot.transform.localScale = Vector3.one;
				slot.name = ct.Description;
				PurchasedPaksGridSlots.Add(slot);
			}
		}
	}

	/// <summary>
	/// Limpia la lista de packs obtenidos
	/// </summary>
	void CleanPurchaserGridContent() {
		foreach (GameObject go in PurchasedPaksGridSlots) {
			Destroy (go);
		}
		PurchasedPaksGridSlots.Clear ();
	}

	public void PurchasedItemSlot_Click(PurchasedItemSlot item) {
		Debug.Log("[" + item.name + " in " + name + "]: Ha detectado un click");
		TheGameCanvas.ShowModalScreen ((int)ModalLayout.PURCHASED_PACK_CONTENT_LIST);
	}

	public void SetupPurchasedListContent() {
		
	}




	/// <summary>
	/// Rellena la lista de Logros desbloqueados
	/// </summary>
	public void SetupAchievementGridContent() {

		CleanAchievementsGridContent ();
		
		foreach (var c in UserAPI.Achievements.Achievements) {	
			AchievementsAPI.Achievement ach = (c.Value as AchievementsAPI.Achievement);
			// TODO: rellenar el contenido de cada lista
			GameObject slot = Instantiate (AchievementSlot);
			slot.transform.SetParent(AchievementGridContentList.transform);
			slot.GetComponent<AchievementSlot> ().SetupSlot (this, ach.Name, ach.Image);
			slot.transform.localScale = Vector3.one;
			if (!ach.earned) {
				slot.GetComponent<Button>().interactable = false;
			}
			slot.name = ach.Description;
			AchievementsGridSlots.Add(slot);
		}
	}

	/// <summary>
	/// Limpia la lista de Logros del grid de logros desbloqueados
	/// </summary>
	void CleanAchievementsGridContent() {
		foreach (GameObject go in AchievementsGridSlots) {
			Destroy (go);
		}
		AchievementsGridSlots.Clear ();
	}
	
	public void AchievementItemSlot_Click(AchievementSlot item) {
		Debug.Log("[" + item.name + " in " + name + "]: Ha detectado un click");
	}



	public void SetupSingleContentBuyContent() {
		
	}
	public void SetupSingleContentGoToShop() {
		
	}
	public void SetupSingleContentToShare() {
		
	}

	public void SetupThirdProfileContent(string playerID) {
		ThirdsProfile = ProfileScreenController.GetComponent<ThirdProfileController> ();
		ThirdsProfile.Setup (playerID);
	}
}
