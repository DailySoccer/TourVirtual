using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using SmartLocalization;

public class VestidorModalManager : GUIPopUpScreen {

	public ModalLayout CurrentModalLayout;

	public GameObject ModalBase;
	public GameObject CloseButton;
	public Text StandardTitleText;
	public GameObject SingleContent;

	public VestidorCanvasController_Lite VCC;

	DetailedContent2Buttons ContentType;

	// Use this for initialization
	void Awake () {
		base.Awake ();
	}
	
	// Update is called once per frame
	void Update () {
		base.Update ();
	}


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
		
		ResetModal ();

		if (ContentType == null)
			ContentType = SingleContent.GetComponentInChildren<DetailedContent2Buttons>();

		switch (newPopUpLayout) {
			case ModalLayout.SINGLE_CONTENT_INFO:
				SingleContent.SetActive (true);

				StandardTitleText.gameObject.SetActive (true);
				StandardTitleText.text = LanguageManager.Instance.GetTextValue ("TVB.Popup.Info");
							
				ContentType.CurrentLayout = DetailedContent2ButtonsLayout.OK_ONLY;
				ContentType.Setup(VCC.currentPrenda.virtualGood.Description, VCC.currentPrenda.virtualGood.Image);	

				break;
			
			case ModalLayout.SINGLE_CONTENT_BUY_ITEM:
				SingleContent.SetActive (true);

				StandardTitleText.gameObject.SetActive (true);
				StandardTitleText.text = LanguageManager.Instance.GetTextValue ("TVB.Popup.Buy");

				ContentType.CurrentLayout = DetailedContent2ButtonsLayout.BUYITEM;
				ContentType.Setup(VCC.currentPrenda.virtualGood.Description, VCC.currentPrenda.virtualGood.Image);		

				break;
		}
	}


	public void ResetModal () {

	}
}
