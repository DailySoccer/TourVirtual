using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[ExecuteInEditMode]
public class ShopGoodie : MonoBehaviour {

	public Text TheUnits;
	public Image TheIcon;
	public Text ThePrice;
	public GameObject BestPrice;
	public bool IsBestPrice;
	public GameObject MostPopular;
	public bool IsMostPopular;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		MostPopular.SetActive (IsMostPopular);
		BestPrice.SetActive (IsBestPrice);
	}

	void SetValues(string Units, Sprite Icon, string Price) {
		TheUnits.text = Units;
		TheIcon.sprite = Icon;
		ThePrice.text = Price;
	}
}
