using UnityEngine;
using Soomla.Store;
using System.Collections;

public class GoodiesShopController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Product_ClickHandle(string iapId) {
        
        Debug.LogError(">>>> " + iapId);
        StartCoroutine(Buy("100coins"));
    }

    IEnumerator Buy(string id)
    {
        LoadingCanvasManager.Show();
        yield return null;
        StoreInventory.BuyItem(id);
        LoadingCanvasManager.Hide();
    }
}
