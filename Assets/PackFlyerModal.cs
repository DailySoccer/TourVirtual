using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PackFlyerModal : MonoBehaviour {

	public Image FlyerThumbnail;
	public Text ContentList;
	public Text Price;
	ContentAPI.Content TheContent;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Setup(ContentAPI.Content content) {
		TheContent = content;
		//packurl y thumburl
		StartCoroutine(MyTools.LoadSpriteFromURL(content.ThumbURL, FlyerThumbnail.gameObject));
		Price.text = UserAPI.VirtualGoodsDesciptor.GetByGUID (content.VirtualGoodID).Price.ToString();
	}

	public void AddContentToList(string contentTitle) {

		if (ContentList.text != "")
			ContentList.text += "\n";

		ContentList.text += contentTitle;
	}
}
