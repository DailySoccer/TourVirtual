using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections;

public enum PopUpLayout {
	PURCHASED_GRID_CONTENT,
	PURCHASED_LIST_CONTENT,
	ACHIEVEMENTS_GRID_CONTENT,
	SINGLE_CONTENT_GOTO_SHOP,
	SINGLE_CONTENT_BUY_ITEM,
	SINGLE_CONTENT_SARE,
	THIRDS_PROFILE_CONTENT
}

[ExecuteInEditMode]
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

	public PopUpLayout CurrentState;
	private PopUpLayout _LastState;


	private Text _CurrentStandardTitleText;
	private Text _CurrentThirdsProfileTitleText;

	private DetailedContent2Buttons SingleContentLayOut;

	// Use this for initialization
	void OnEnable () {
		StandardTitle.SetActive(true);
		_CurrentStandardTitleText = StandardTitle.GetComponent<Text> ();

		ThirdsProfileTitle.SetActive(true);
		Debug.Log("Textos en el titulo de usuario: " + ThirdsProfileTitle.GetComponentsInChildren<Text>().Count());
		_CurrentThirdsProfileTitleText = ThirdsProfileTitle.GetComponentsInChildren<Text>().Where(t => t.name == "User Other Name").First();

		SingleContentLayOut = SingleContent.GetComponent<DetailedContent2Buttons> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (CurrentState != _LastState) {

			ResetWindow();

			switch (CurrentState) {
			case PopUpLayout.PURCHASED_GRID_CONTENT:
				StandardTitle.SetActive (true);
				_CurrentStandardTitleText.text = "PACKS COMPRADOS";
				PurchasedPackGridContent.SetActive(true);
				break;

			case PopUpLayout.PURCHASED_LIST_CONTENT:
				StandardTitle.SetActive (true);
				_CurrentStandardTitleText.text = "CONTENIDO DEL PACK";
				PurchasedPackListContent.SetActive(true);
				break;

			case PopUpLayout.ACHIEVEMENTS_GRID_CONTENT:
				StandardTitle.SetActive (true);
				_CurrentStandardTitleText.text = "LISTADO DE LOGROS";
				AchievementGridContent.SetActive(true);
				break;

			case PopUpLayout.SINGLE_CONTENT_GOTO_SHOP:
				StandardTitle.SetActive (true);
				_CurrentStandardTitleText.text = "FONDOS INSUFICIENTES";
				SingleContentLayOut.CurrentLayout = DetailedContent2ButtonsLayout.GOTOSHOP;
				SingleContent.SetActive(true);
				break;

			case PopUpLayout.SINGLE_CONTENT_BUY_ITEM:
				StandardTitle.SetActive (true);
				_CurrentStandardTitleText.text = "ADQUIERE ESTE PRODUCTO";
				SingleContentLayOut.CurrentLayout = DetailedContent2ButtonsLayout.BUYITEM;
				SingleContent.SetActive(true);
				break;

			case PopUpLayout.SINGLE_CONTENT_SARE:
				StandardTitle.SetActive (true);
				_CurrentStandardTitleText.text = "COMPARTE TU ADQUISICIÓN";
				SingleContentLayOut.CurrentLayout = DetailedContent2ButtonsLayout.SHARE;
				SingleContent.SetActive(true);
				break;

			case PopUpLayout.THIRDS_PROFILE_CONTENT:
				ThirdsProfileTitle.SetActive(true);
				_CurrentThirdsProfileTitleText.text = "NOMBRE DE USUARIO";
				ThirdsProfileContent.SetActive(true);
				break;

			}
			_LastState = CurrentState;
		}
	
	}

	public void ResetWindow() {
		_CurrentStandardTitleText.text = "";
		StandardTitle.SetActive(false);
		_CurrentThirdsProfileTitleText.text = "";
		ThirdsProfileTitle.SetActive (false);
		CloseButton.SetActive (true);


		PurchasedPackGridContent.SetActive(false);
		PurchasedPackListContent.SetActive(false);
		AchievementGridContent.SetActive(false);
		SingleContent.SetActive(false);
		ThirdsProfileContent.SetActive(false);


	}
}
