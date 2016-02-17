using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClothSlot : MonoBehaviour {

	public Text ClothName;
	public Image Picture;
	public Text Price;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Reset() {
		ClothName.text = "";
		Price.text = "";
	}

	public void SetupSlot(string productName, string ImageUrl, string ProductPrice) {
		Debug.Log ("[ClothSlot]: Cargar Sprite de: " + ImageUrl);
		StartCoroutine( LoadSprite (ImageUrl) );

		ClothName.text = productName;

		Price.text = ProductPrice;
	}

	public Material defaultMaterial; //prefab material set already

	IEnumerator LoadSprite( string url)
	{
		WWW www = new WWW(url);
		yield return www; 

		Debug.LogWarning ("[ClothSlot]: (antes de crear sprite) Picture.sprite: " + Picture.sprite);
		Picture.sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), Vector2.zero, 100.0f);
		Debug.LogWarning ("[ClothSlot]: (despues crear sprite) Picture.sprite: " + Picture.sprite);
		yield return true;
	}

}
