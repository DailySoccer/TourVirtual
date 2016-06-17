using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AchievementSlot : MonoBehaviour {

	public Text AchievementName;
	public Image Picture;

	public AchievementsAPI.Achievement TheAchivment;

	PopUpWindow theParentController;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {	
	}

	public void Reset() {
		AchievementName.text = "";
		Picture.sprite = null;
	}

	public void SetupSlot(PopUpWindow parentController, AchievementsAPI.Achievement achiv) {
		TheAchivment = achiv;

		StartCoroutine(MyTools.LoadSpriteFromURL(achiv.Image, Picture.gameObject));
		AchievementName.text = achiv.Name;

		theParentController = parentController;
	}

	public void AchievementSlot_ClickHandle() {
		theParentController.AchievementItemSlot_Click(this);
	}
}