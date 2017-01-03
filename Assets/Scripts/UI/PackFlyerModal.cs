using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using SmartLocalization;

public class PackFlyerModal : MonoBehaviour {

	public Image FlyerThumbnail;
	public Text ContentList;
	public Text Price;
	public Text PriceInApp;
	ContentAPI.Content TheContent;


	public void Setup(ContentAPI.Content content) {
		TheContent = content;
	// FER: 02/01/17
	// Carga el precio en el teaser.
		PriceInApp.text = GoodiesShopController.Instance.item7.text;
		//packurl y thumburl
		StartCoroutine(MyTools.LoadSpriteFromURL(content.PackURL, FlyerThumbnail.gameObject));
        var vg = UserAPI.VirtualGoodsDesciptor.GetByGUID(content.VirtualGoodID);
		if(vg!=null)
			Price.text = vg.Price.ToString(); //LanguageManager.Instance.GetTextValue("TVB.Button.Buy") + " <size=\"50\">" + vg.Price.ToString() + "</size>";
		else
			Debug.LogError(">>>> No se ha encontrado el VG "+content.VirtualGoodID+" asociado al Contenido "+content.GUID);
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
            ModalContents.Instance.ShowModalScreen(9);
        });

    }

   // FER: 02/01/17
	// Compra de todos los contenidos.   
	public void BuyInApp() {
		MainManager.Instance.OnPurchaseInApp = ()=>{
            ModalContents.Instance.ShowModalScreen(9);
        };
		GoodiesShopController.Instance.Product_ClickHandle("_rmvt_pack_all");
    }
}
