using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AchievementSlot : MonoBehaviour {

	public Text AchievementName;
	public Image Picture;

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

	public void SetupSlot(PopUpWindow parentController, string productName, string pictureUrl) {
		StartCoroutine(MyTools.LoadSpriteFromURL(pictureUrl, Picture.sprite));
		AchievementName.text = productName;
		theParentController = parentController;
	}

	public void AchievementSlot_ClickHandle() {
		theParentController.AchievementItemSlot_Click(this);
	}
}
