using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[ExecuteInEditMode]
public class ClothesTab : MonoBehaviour {

	public bool IsTabActive;
	public Image Image;
	public Sprite SpriteOn;
	public Sprite SpriteOff;
	public Text texto;

	// Update is called once per frame
	void Update () {
		Image.sprite = IsTabActive ? SpriteOn : SpriteOff;
		texto.color = IsTabActive ? new Color(0.082f, 0.109f, 0.168f) : new Color(1.0f,1.0f,1.0f);
	}

}
