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
		StartCoroutine(MyTools.LoadSpriteFromURL(content.PackURL, FlyerThumbnail.gameObject));
        var vg = UserAPI.VirtualGoodsDesciptor.GetByGUID(content.VirtualGoodID);
        Price.text = vg.Price.ToString();
	}

	public void AddContentToList(string contentTitle) {
		if (ContentList == null)
			return;

		if (ContentList.text != "")
			ContentList.text += "\n";

		ContentList.text += contentTitle;
	}

	public void Reset() {
		if (ContentList != null)
			ContentList.text = "";

		Price.text = "";
		TheContent = null;
		FlyerThumbnail.sprite = null;
	}

    public void Buy()
    {
        UserAPI.VirtualGoodsDesciptor.BuyByGUID(TheContent.VirtualGoodID, false, () => {
            GameObject.FindGameObjectWithTag("GameCanvasManager").GetComponent<GameCanvasManager>().ShowModalScreen(9);
        }, () => {
            Debug.Log(">>>>");
        });

    }
}
