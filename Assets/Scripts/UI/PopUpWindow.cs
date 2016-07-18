using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using SmartLocalization;

public enum ModalLayout
{
	BLANK,
	PURCHASED_PACKS_GRID,
	PURCHASED_PACK_CONTENT_LIST,
	ACHIEVEMENTS_GRID,
	SINGLE_CONTENT_GOTO_SHOP,
	SINGLE_CONTENT_BUY_ITEM,
    SINGLE_CONTENT_INFO,
    SINGLE_CONTENT_SHARE,
    THIRDS_PROFILE_CONTENT,
	PACK_FLYER,
	SETTINGS,
	FANLEVEL_RANKING,
}

public class PopUpWindow : UIScreen {

	public GameObject ModalBase;

	public GameObject CloseButton;

	// Titulos
	//public GameObject StandardTitle;
	public Text StandardTitleText;

	public GameObject ThirdsProfileTitle;

	//Contenidos
	public GameObject PurchasedPacksGridParent;
	public GameObject PurchasedPacksGridList;
	public GameObject PurchasedPacksGridSlot;
	private List<GameObject> PacksGridSlotGameObjectsList = new List<GameObject>();

	public GameObject PurchasedPackContentParent;
	public GameObject PurchasedPackContentList;
	public GameObject PurchasedPackContentSlot;
	private List<GameObject> PurchasedPackContentGameObjectsList = new List<GameObject>();

	public GameObject SharePurchasedContentButton;

	public GameObject AchievementsGridParent;
	public GameObject AchievementsGridList;
	public GameObject AchievementSlot;
	private List<GameObject> AchievementsGridSlotGameObjectsList = new List<GameObject>();


	public GameObject SingleContent;
	ThirdProfileController ThirdsProfile;
	public GameObject ProfileScreenController;
	private DetailedContent2Buttons SingleContentLayOut;
    public GameCanvasManager TheGameCanvas;

	public GameObject PackFlyerGameObject;
	PackFlyerModal ThePackFlyerModal;

	public GameObject SettingsGameObject;

	public GameObject RankingFanLevelGameObject;
	public GameObject RankingFanLevelParentList;
	public GameObject RankingFanLevelSlot;
	public GameObject RankingShareButton;
	private List<GameObject> RankingFanLevelSlotGameObjectList = new List<GameObject>();


	string currentSelectedItemGUID;
	ContentAPI.Content currentSelectedPack;
	ClothSlot CurrentVestidorPrenda;
	AchievementsAPI.Achievement currentAchivementSelected;

	// Use this for initialization
	void Start () {
		//StandardTitleText.gameObject.SetActive(true);

		if (ThirdsProfileTitle != null) {
			ThirdsProfileTitle.SetActive (true);
		} else {
			Debug.LogWarning("No está establecido el GameObject 'ThirdsProfileTitle'. Si es para el vestidor, no es necesario");
		}
	}

	void Awake() {
		base.Awake ();

		if (SingleContent) {
			SingleContentLayOut = SingleContent.GetComponent<DetailedContent2Buttons> ();
		}

		if (PackFlyerGameObject != null) {
			if (ThePackFlyerModal == null)
				ThePackFlyerModal = PackFlyerGameObject.GetComponent<PackFlyerModal> ();
		}
	}

	// Update is called once per frame
	void Update () {
		base.Update ();
	}

	public ModalLayout CurrentModalLayout{ get; set;}

	void ConfigureModal() {
		StartCoroutine(WaitForModalBaseEnable());
	}

	public IEnumerator WaitForModalBaseEnable() {
		while (!ModalBase.GetActive()) {
			yield return null;
		}
		// cuando la base de la modal está activa... ajecutamos sus operaciones
		SetState(CurrentModalLayout);
	}

	public void SetState(ModalLayout newPopUpLayout) {

		ResetWindow ();

		switch (newPopUpLayout) {
			case ModalLayout.BLANK:
			break;
			case ModalLayout.PURCHASED_PACKS_GRID:
				PurchasedPacksGridParent.SetActive (true);
				StandardTitleText.gameObject.SetActive (true);
				StandardTitleText.text = LanguageManager.Instance.GetTextValue ("TVB.Popup.PurchasedPacks");
				SetupPurchasedGridContent();
			break;
					
			case ModalLayout.PURCHASED_PACK_CONTENT_LIST:
				PurchasedPackContentParent.SetActive (true);
				StandardTitleText.gameObject.SetActive (true);
				StandardTitleText.text = LanguageManager.Instance.GetTextValue ("TVB.Popup.PackContent");
				// 'currentSelectedItemGUID': Seteado al hacer click sobre un pack comprado
				SetupPurchasedPackContentList (currentSelectedItemGUID);
				#if !(UNITY_EDITOR || UNITY_IOS || UNITY_ANDROID)
					SharePurchasedContentButton.setActive(false);
				#endif
			break;
					
			case ModalLayout.ACHIEVEMENTS_GRID:
				AchievementsGridParent.SetActive (true);
				StandardTitleText.gameObject.SetActive (true);
				StandardTitleText.text = LanguageManager.Instance.GetTextValue ("TVB.Popup.AchievementsList");
				SetupAchievementGridContent();
			break;
					
			case ModalLayout.SINGLE_CONTENT_GOTO_SHOP:
				SingleContent.SetActive (true);
				StandardTitleText.gameObject.SetActive (true);
				StandardTitleText.text = LanguageManager.Instance.GetTextValue ("TVB.Popup.InsufficientFunds");
				SingleContentLayOut.CurrentLayout = DetailedContent2ButtonsLayout.GOTOSHOP;
			break;
					
			case ModalLayout.SINGLE_CONTENT_BUY_ITEM:
				SingleContent.SetActive (true);
				StandardTitleText.gameObject.SetActive (true);
				StandardTitleText.text = LanguageManager.Instance.GetTextValue ("TVB.Popup.Buy");
				SingleContentLayOut.CurrentLayout = DetailedContent2ButtonsLayout.BUYITEM;
			break;

			case ModalLayout.SINGLE_CONTENT_INFO:
				SingleContent.SetActive (true);
				StandardTitleText.gameObject.SetActive (true);
				StandardTitleText.text = LanguageManager.Instance.GetTextValue ("TVB.Popup.Info");
				DetailedContent2Buttons modalDetailInfo = SingleContent.GetComponentInChildren<DetailedContent2Buttons>();
				if (currentAchivementSelected != null) 
					modalDetailInfo.Setup (currentAchivementSelected.Name, currentAchivementSelected.Description, currentAchivementSelected.Image, "");
				
				SingleContentLayOut.CurrentLayout = DetailedContent2ButtonsLayout.OK_ONLY;

			break;

			case ModalLayout.SINGLE_CONTENT_SHARE:
				SingleContent.SetActive (true);
				StandardTitleText.gameObject.SetActive (true);
				StandardTitleText.text = LanguageManager.Instance.GetTextValue ("TVB.Popup.ShareContentTitle");
				DetailedContent2Buttons modalDetailShare = SingleContent.GetComponentInChildren<DetailedContent2Buttons>();
				if (currentAchivementSelected != null) 
					modalDetailShare.Setup (currentAchivementSelected.Name, currentAchivementSelected.Description, currentAchivementSelected.Image, "");

				SingleContentLayOut.CurrentLayout = DetailedContent2ButtonsLayout.SHARE;
			break;
					
			case ModalLayout.THIRDS_PROFILE_CONTENT:
				SetupThirdProfileContent(TheGameCanvas.CurrentPlayerDataModelSelected);
				ThirdsProfileTitle.SetActive (true);
				ProfileScreenController.SetActive (true);
			break;			
				
			case ModalLayout.PACK_FLYER:
				// Coger el id del pack asociado a la vitrina
				string packId = ContentManager.Instance.ContentNear.ContentKey;
			
				ContentAPI.Content content = UserAPI.Contents.GetContentByID (packId);
			
				if (content == null) {
					// Ha sucedido un error inesperado
					TheGameCanvas.HideModalScreen();
					ModalTextOnly.ShowText("Ha ocurrido un error con el Pack: \"" + packId + "\" y no se puede mostrar el contenido solicitado");
					return;
				}

				if (content.owned) {
					// El contenido está comprado, asique mostramos la lista de contenidos
					currentSelectedItemGUID = content.GUID;
					SetState(ModalLayout.PURCHASED_PACK_CONTENT_LIST);
					return;
				}
				else {
					// No tenemos el contenido, asique mostramos el flyer
					PackFlyerGameObject.SetActive (true);
					//StandardTitleText.gameObject.SetActive (true);
					//StandardTitleText.text = content.Description;
					SetupFlyerPackContent(content);
				}
			break;

			case ModalLayout.SETTINGS:
				SettingsGameObject.SetActive(true);
				StandardTitleText.gameObject.SetActive (true);
				StandardTitleText.text = LanguageManager.Instance.GetTextValue ("TVB.Popup.SettingsTitle");
			break;

			//TODO: Mostrar modal con el fan level
			case ModalLayout.FANLEVEL_RANKING:
			#if UNITY_EDITOR
				Debug.Log ("TODO: Mostrar modal con el fan level");
			#endif
				RankingFanLevelGameObject.SetActive (true);
				StandardTitleText.gameObject.SetActive (true);
				StandardTitleText.text = LanguageManager.Instance.GetTextValue ("TVB.Popup.FanLevelRankingTitle");
				SetupFanRankingListContent();
				RankingShareButton.SetActive(IsInRanking());
			break;
		}
	}

	public void ResetWindow() {
		if (StandardTitleText != null) {
			StandardTitleText.text = "";
			StandardTitleText.gameObject.SetActive (false);
		}

		if (ThirdsProfileTitle != null)
			ThirdsProfileTitle.SetActive (false);

		if (ProfileScreenController != null)
			ProfileScreenController.SetActive (false);

		/// Limpieza del grid de contenidos comprados
		if (PurchasedPacksGridList != null) {
			CleanPurchasedPaksGridSlotGameObjectsList ();
			PurchasedPacksGridParent.SetActive (false);
		}
	    
		/// Limpieza de la lista de contenidos de un pack
		if (PurchasedPackContentList != null){
			CleanPurchasedPackContentGameObjectsList ();
			PurchasedPackContentParent.SetActive (false);
		}
			
		/// Limpieza del grid de logros
		if (AchievementsGridList != null) {
			CleanAchievementsGridSlotGameObjectList ();
			AchievementsGridParent.SetActive (false);
		}

		//SingleContentLayOut.CurrentLayout = DetailedContent2ButtonsLayout.BUYITEM;
		SingleContent.SetActive(false);

		/// Limpieza del flyer Content
		if (ThePackFlyerModal != null) {
			ThePackFlyerModal = PackFlyerGameObject.GetComponent<PackFlyerModal> ();
			ThePackFlyerModal.Reset ();
		}

		if (PackFlyerGameObject != null)
			PackFlyerGameObject.SetActive(false);

		if (SettingsGameObject != null) {
			SettingsGameObject.SetActive(false);
		}

		if (RankingFanLevelSlotGameObjectList != null){
			CleanARankingFanLevelSlotGameObjectList();
			RankingFanLevelGameObject.SetActive(false);
		}

		CloseButton.SetActive (true);
	}

	/// <summary>
	/// Rellena la lista de packs obtenidos
	/// </summary>
	public void SetupPurchasedGridContent() {

		CleanPurchasedPaksGridSlotGameObjectsList ();
		foreach (var c in UserAPI.Contents.Contents) {	
			ContentAPI.Content content = (c.Value as ContentAPI.Content);
			// TODO: rellenar el contenido de cada lista
			if (content.owned) {
				GameObject slot = Instantiate (PurchasedPacksGridSlot);
				slot.transform.SetParent(PurchasedPacksGridList.transform);
				slot.GetComponent<PurchasedItemSlot> ().SetupSlot (this, content/*.Title, content.ThumbURL, content.VirtualGoodID*/);
				slot.transform.localScale = Vector3.one;
				slot.name = content.Description;
				PacksGridSlotGameObjectsList.Add(slot);
			}
		}
	}

	/// <summary>
	/// Limpia la lista de packs obtenidos
	/// </summary>
	void CleanPurchasedPaksGridSlotGameObjectsList() {
		foreach (GameObject go in PacksGridSlotGameObjectsList) {
			Destroy (go);
		}
		PacksGridSlotGameObjectsList.Clear ();
	}

	public void PurchasedItemSlot_Click(PurchasedItemSlot item) {
		#if UNITY_EDITOR
			Debug.Log("[" + item.name + " in " + name + "]: Ha detectado un click");
		#endif
		currentSelectedItemGUID = item.Content.GUID;
		currentSelectedPack = item.Content;
		TheGameCanvas.ShowModalScreen ((int)ModalLayout.PURCHASED_PACK_CONTENT_LIST);
		//SetupPurchasedPackContentList (item.Content.GUID);
	}

	/// <summary>
	/// Prepara la pantalla de contenido de un pack comprado
	/// </summary>
	/// <param name="packId">Pack identifier.</param>
	public void SetupPurchasedPackContentList(string packId) {
		CleanPurchasedPackContentGameObjectsList ();

		//TODO: Traer los datos y meterlos en la ventana
		LoadingCanvasManager.Show("TVB.Message.LoadingData");

		currentSelectedPack = UserAPI.Contents.Contents[packId];

		StartCoroutine(UserAPI.Contents.GetContent(packId, PackContentCallBack));

	}

	public void PackContentCallBack(List<ContentAPI.Asset> values) {
		LoadingCanvasManager.Hide();
		foreach (ContentAPI.Asset cont in values.Where( c => c.Type != ContentAPI.AssetType.ContentTitleImage )){

			GameObject slot = Instantiate (PurchasedPackContentSlot);
			slot.transform.SetParent(PurchasedPackContentList.transform);
			slot.transform.localScale = Vector3.one;
			slot.name = cont.Title;
			slot.GetComponent<PurchasedPackContentSlot> ().SetupSlot (this, cont);
			PurchasedPackContentGameObjectsList.Add(slot);
		}	
	}

    /// <summary>
    /// Limpia la lista de Logros del grid de logros desbloqueados
    /// </summary>
    void CleanPurchasedPackContentGameObjectsList() {
		foreach (GameObject go in PurchasedPackContentGameObjectsList) {
			Destroy (go);
		}
		PurchasedPackContentGameObjectsList.Clear ();
	}

	public void PurchasedPackContentSlot_Click(PurchasedPackContentSlot item) {
        // Ocultar la lista.
        AllViewer.Instance.Show(item.content.AssetUrl, item.content.Type, item.content.Title, item.content.Body, ()=> { });
    }


	/// <summary>
	/// Rellena la lista de Logros desbloqueados
	/// </summary>
	public void SetupAchievementGridContent() {
		CleanAchievementsGridSlotGameObjectList ();
		foreach (var c in UserAPI.Achievements.Achievements) {
            AchievementsAPI.Achievement ach = (c.Value as AchievementsAPI.Achievement);
            if (!ach.earned) continue;
			// TODO: rellenar el contenido de cada lista
			GameObject slot = Instantiate (AchievementSlot);
			slot.transform.SetParent(AchievementsGridList.transform);
			slot.GetComponent<AchievementSlot> ().SetupSlot (this, ach);
			slot.transform.localScale = Vector3.one;
			slot.name = ach.Name;
			AchievementsGridSlotGameObjectsList.Add(slot);
		}
	}

	/// <summary>
	/// Limpia la lista de Logros del grid de logros desbloqueados
	/// </summary>
	void CleanAchievementsGridSlotGameObjectList() {
		foreach (GameObject go in AchievementsGridSlotGameObjectsList) {
			Destroy (go);
		}
        AchievementsGridSlotGameObjectsList.Clear ();
	}

	public void AchievementItemSlot_Click(AchievementSlot item) {
		#if UNITY_EDITOR
			Debug.Log("[" + item.name + " in " + name + "]: Ha detectado un click");
		#endif
		currentAchivementSelected = item.TheAchivment;
		TheGameCanvas.ShowModalScreen ((int)ModalLayout.SINGLE_CONTENT_SHARE);
	}


	public void SetupThirdProfileContent(string[] dataModel) {

		ThirdsProfile = ProfileScreenController.GetComponent<ThirdProfileController> ();
		ThirdsProfile.Setup (dataModel);
    }

	public void SetupFlyerPackContent(ContentAPI.Content content) {
		#if UNITY_EDITOR
			Debug.Log ("[PopUpWindow] en " + name + "El contenido de esta vitrina está bloqueado");
		#endif

		LoadingCanvasManager.Show ("TVB.Message.LoadingData");

		// Setear el título de la ventana
		//StandardTitleText.gameObject.SetActive (true);			

		// Recuperar la info del pack: Thumb, titulo, contenidos y configuramos la ventana
		ThePackFlyerModal.Setup (content);

		// Solicitamos el contenido del pack y montamos el flyer
		StartCoroutine (UserAPI.Contents.GetContent (content.GUID, PackFlyerContentCallBack));

	}


	public void PackFlyerContentCallBack(List<ContentAPI.Asset> values) {
		LoadingCanvasManager.Hide();
		//TODO: configurar modal de compra de pack
		PackFlyerModal flyer = PackFlyerGameObject.GetComponent<PackFlyerModal> ();

		foreach (ContentAPI.Asset cont in values.Where( c => c.Type != ContentAPI.AssetType.ContentTitleImage )) {
			flyer.AddContentToList(cont.Title);
		}
	}

	public bool IsInRanking()
	{
		UserAPI.ScoreEntry[] rankingArray = UserAPI.Instance.GetFanRanking();
		UserAPI.ScoreEntry me = new UserAPI.ScoreEntry();

		foreach (UserAPI.ScoreEntry se in rankingArray)
		{
			if (se.IsMe)
				me = se;
		}
		return me.Position != 0;
	}

	void SetupFanRankingListContent() {
		UserAPI.ScoreEntry[] scoreArray = UserAPI.Instance.GetFanRanking ();

		RankingFanLevelSlotGameObjectList = new List<GameObject> ();

		bool alreadyInList = false;

		if (IsInRanking())
		{
			for (int i = 0; i < scoreArray.Length; i++)
			{
				if (RankingFanLevelSlotGameObjectList.Count >= 9)
				{
					if (!alreadyInList)
					{// Si ya hay 9 oposiciones en el ranking y no estoy en la lista..
						if (scoreArray[i].IsMe)
						{// Sólo inserto el 10º si soy yo.
							RankingFanLevelSlotGameObjectList.Add(CreateFanRankingSlot(scoreArray[i], i));
						}
					}
					else
					{
						RankingFanLevelSlotGameObjectList.Add(CreateFanRankingSlot(scoreArray[i], i));
					}
				}
				else
				{ // Si hay menos de 9 oposiciones en el ranking

					RankingFanLevelSlotGameObjectList.Add(CreateFanRankingSlot(scoreArray[i], i));
					if (scoreArray[i].IsMe)
					{
						alreadyInList = true;
					}
				}
			}
		}
		else
		{
			int MaxElements = Mathf.Min(10, scoreArray.Length);
			for (int i = 0; i < MaxElements; i++)
			{
				RankingFanLevelSlotGameObjectList.Add(CreateFanRankingSlot(scoreArray[i], i));
			}
		}
	}

	private GameObject CreateFanRankingSlot (UserAPI.ScoreEntry scoreArray, int pos) {
		GameObject slot = Instantiate(RankingFanLevelSlot);
		slot.transform.SetParent(RankingFanLevelParentList.transform);
		slot.GetComponent<LevelFanRankingSlot>().SetupSlot(scoreArray.Position.ToString(), scoreArray.Nick, scoreArray.Score.ToString(), scoreArray.IsMe);
		slot.transform.localScale = Vector3.one;
		slot.name = "FanLevelRankigPosition_" + pos;
		#if UNITY_EDITOR
			Debug.LogErrorFormat("{0}) {1} / {2}, Soy yo? : {3}", scoreArray.Position, scoreArray.Nick, scoreArray.Score, scoreArray.IsMe? "Si" : "No" );
		#endif
		return slot;
	}
	
	void CleanARankingFanLevelSlotGameObjectList() {
		foreach (GameObject go in RankingFanLevelSlotGameObjectList) {
			Destroy (go);
		}
		RankingFanLevelSlotGameObjectList.Clear ();
	}

	public void CloseModalScreen() {
		TheGameCanvas.HideModalScreen ();
		currentAchivementSelected = null;
		currentSelectedPack = null;
    }

	public void ShareWithFB() {
		if (currentAchivementSelected != null) {
			#if UNITY_EDITOR
				Debug.LogErrorFormat("Trying to share Achievement with Facebook: achievementID {0} -> Achievement Name<{1}>", currentAchivementSelected.IName, currentAchivementSelected.Name);
			#endif
			FacebookManager.Instance.ShareToFacebook(FacebookLink.AchievementShare(currentAchivementSelected.IName, currentAchivementSelected.Name));
		}
		if (currentSelectedPack != null) {
			string packId = currentSelectedPack.ContenName.Replace("CONTENT","");
			#if UNITY_EDITOR
				Debug.LogErrorFormat("Trying to share Unlocked Content Pack with Facebook: CONTENT_ID {0}", packId);
			#endif
			FacebookManager.Instance.ShareToFacebook(FacebookLink.ContentUnlockedShare(packId));
		}
	}
}
