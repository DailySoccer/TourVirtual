using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AchievementSlot : MonoBehaviour {

	public Text AchievementName;
	public Image Picture;

	// Use this for initialization
	void Start () {
		Reset ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Reset() {
		AchievementName.text = "";
	}

	public void SetupSlot(string productName, Sprite ProductPicture, string ProductPrice) {
		AchievementName.text = productName;
		Picture.sprite = ProductPicture;
	}

}
