using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using SmartLocalization;

public enum ModalLayout {
	BLANK,
	PURCHASED_PACKS_GRID,
	PURCHASED_PACK_CONTENT_LIST,
	ACHIEVEMENTS_GRID,
	SINGLE_CONTENT_GOTO_SHOP,
	SINGLE_CONTENT_BUY_ITEM,
    SINGLE_CONTENT_INFO,
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
	public GameObject PurchasedPacksGridParent;
	public GameObject PurchasedPacksGridList;
	public GameObject PurchasedPacksGridSlot;
	private List<GameObject> PacksGridSlotGameObjectsList = new List<GameObject>();

	public GameObject PurchasedPackContentParent;
	public GameObject PurchasedPackContentList;
	public GameObject PurchasedPackContentSlot;

	public GameObject AchievementsGridParent;
	public GameObject AchievementsGridList;
	public GameObject AchievementSlot;
	private List<GameObject> AchievementsGridSlots = new List<GameObject>();

	public GameObject SingleContent;
#if !LITE_VERSION
	ThirdProfileController ThirdsProfile;
#endif
	public GameObject ProfileScreenController;
	private DetailedContent2Buttons SingleContentLayOut;
#if !LITE_VERSION
    public GameCanvasManager TheGameCanvas;
#endif
    // Use this for initialization
    void Start () {
		StandardTitleText.gameObject.SetActive(true);
		//CurrentStandardTitleText = StandardTitle.GetComponent<Text> ();
		if (ThirdsProfileTitle != null) {
			ThirdsProfileTitle.SetActive (true);
		} else {
			Debug.LogWarning("No está establecido el GameObject 'ThirdsProfileTitle'. Si es para el vestidor, no es necesario");
		}
		if (SingleContent) {
			SingleContentLayOut = SingleContent.GetComponent<DetailedContent2Buttons> ();
		}
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
			PurchasedPacksGridParent.SetActive(true);
			StandardTitleText.gameObject.SetActive (true);
			StandardTitleText.text = "PACKS COMPRADOS";
			break;
			
		case ModalLayout.PURCHASED_PACK_CONTENT_LIST:
			PurchasedPackContentParent.SetActive(true);
			StandardTitleText.gameObject.SetActive (true);
			StandardTitleText.text = "CONTENIDO DEL PACK";
			break;
			
		case ModalLayout.ACHIEVEMENTS_GRID:
			AchievementsGridParent.SetActive(true);
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
            StandardTitleText.text = LanguageManager.Instance.GetTextValue("TVB.Popup.Buy");
            SingleContentLayOut.CurrentLayout = DetailedContent2ButtonsLayout.BUYITEM;
            break;
        case ModalLayout.SINGLE_CONTENT_INFO:
            SingleContent.SetActive(true);
            StandardTitleText.gameObject.SetActive(true);
            StandardTitleText.text = LanguageManager.Instance.GetTextValue("TVB.Popup.Info");
            SingleContentLayOut.CurrentLayout = DetailedContent2ButtonsLayout.OK_ONLY;
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
		if (PurchasedPacksGridList != null) {
			foreach (Transform t in PurchasedPacksGridList.transform)
				Destroy (t);
			PurchasedPacksGridParent.SetActive (false);
		}
		CleanPurchasedPaksGridSlots ();
	    

		if (PurchasedPackContentList != null){
			foreach(Transform t in PurchasedPackContentList.transform)
				Destroy (t);
			PurchasedPackContentParent.SetActive (false);
		}
	
		/// Limpieza del grid de logros
		if (AchievementsGridList != null) {
			foreach(Transform t in AchievementsGridList.transform)
				Destroy (t);
			AchievementsGridParent.SetActive (false);
		}
		CleanAchievementsGridSlots ();

		//SingleContentLayOut.CurrentLayout = DetailedContent2ButtonsLayout.BUYITEM;
		SingleContent.SetActive(false);

		CloseButton.SetActive (true);
	}

	/// <summary>
	/// Rellena la lista de packs obtenidos
	/// </summary>
	public void SetupPurchasedGridContent() {

		CleanPurchasedPaksGridSlots ();
#if !LITE_VERSION
		foreach (var c in UserAPI.Contents.Contents) {	
			ContentAPI.Content ct = (c.Value as ContentAPI.Content);
			// TODO: rellenar el contenido de cada lista
			if (ct.owned) {
				GameObject slot = Instantiate (PurchasedPacksGridSlot);
				slot.transform.SetParent(PurchasedPacksGridList.transform);
				slot.GetComponent<PurchasedItemSlot> ().SetupSlot (this, ct.Title, ct.ThumbURL, ct.VirtualGoodID);
				slot.transform.localScale = Vector3.one;
				slot.name = ct.Description;
				PacksGridSlotGameObjectsList.Add(slot);
			}
		}
#endif
	}

	/// <summary>
	/// Limpia la lista de packs obtenidos
	/// </summary>
	void CleanPurchasedPaksGridSlots() {
		foreach (GameObject go in PacksGridSlotGameObjectsList) {
			Destroy (go);
		}
		PacksGridSlotGameObjectsList.Clear ();
	}
#if !LITE_VERSION
	public void PurchasedItemSlot_Click(PurchasedItemSlot item) {
		Debug.Log("[" + item.name + " in " + name + "]: Ha detectado un click");
		TheGameCanvas.ShowModalScreen ((int)ModalLayout.PURCHASED_PACK_CONTENT_LIST);
	}
#endif
	public void SetupPurchasedListContent() {
		
	}




	/// <summary>
	/// Rellena la lista de Logros desbloqueados
	/// </summary>
	public void SetupAchievementGridContent() {

		CleanAchievementsGridSlots ();
#if !LITE_VERSION
		foreach (var c in UserAPI.Achievements.Achievements) {	
			AchievementsAPI.Achievement ach = (c.Value as AchievementsAPI.Achievement);
			// TODO: rellenar el contenido de cada lista
			GameObject slot = Instantiate (AchievementSlot);
			slot.transform.SetParent(AchievementsGridList.transform);
			slot.GetComponent<AchievementSlot> ().SetupSlot (this, ach.Name, ach.Image);
			slot.transform.localScale = Vector3.one;
			if (!ach.earned) {
				slot.GetComponent<Button>().interactable = false;
			}
			slot.name = ach.Description;
			AchievementsGridSlots.Add(slot);
		}
#endif
	}

	/// <summary>
	/// Limpia la lista de Logros del grid de logros desbloqueados
	/// </summary>
	void CleanAchievementsGridSlots() {
#if !LITE_VERSION
		foreach (GameObject go in AchievementsGridSlots) {
			Destroy (go);
		}
#endif
        AchievementsGridSlots.Clear ();
	}
#if !LITE_VERSION
	public void AchievementItemSlot_Click(AchievementSlot item) {
		Debug.Log("[" + item.name + " in " + name + "]: Ha detectado un click");
	}
#endif


    public void SetupSingleContentBuyContent() {
		
	}
	public void SetupSingleContentGoToShop() {
		
	}
	public void SetupSingleContentToShare() {
		
	}
#if !LITE_VERSION
	public void SetupThirdProfileContent(string playerID) {

		ThirdsProfile = ProfileScreenController.GetComponent<ThirdProfileController> ();
		ThirdsProfile.Setup (playerID);
    }
#endif
	public void CloseModalScreen() {
#if !LITE_VERSION
		TheGameCanvas.HideModalScreen ();
#endif
    }
}
