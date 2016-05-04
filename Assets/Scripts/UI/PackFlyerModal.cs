using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using SmartLocalization;

public class PackFlyerModal : MonoBehaviour {

	public Image FlyerThumbnail;
	public Text ContentList;
	public Text Price;
	ContentAPI.Content TheContent;


	public void Setup(ContentAPI.Content content) {
		TheContent = content;
		//packurl y thumburl
		StartCoroutine(MyTools.LoadSpriteFromURL(content.PackURL, FlyerThumbnail.gameObject));
        var vg = UserAPI.VirtualGoodsDesciptor.GetByGUID(content.VirtualGoodID);
		Price.text = vg.Price.ToString(); //LanguageManager.Instance.GetTextValue("TVB.Button.Buy") + " <size=\"50\">" + vg.Price.ToString() + "</size>";
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

    public void Buy() {
        LoadingCanvasManager.Show("TVB.Message.Buying");
        UserAPI.VirtualGoodsDesciptor.BuyByGUID(TheContent.VirtualGoodID, false, () => {
            LoadingCanvasManager.Hide();
            GameObject.FindGameObjectWithTag("GameCanvasManager").GetComponent<GameCanvasManager>().ShowModalScreen(9);
        });

    }
}
