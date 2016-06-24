using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//[ExecuteInEditMode]
public class VestidorTab : MonoBehaviour {

	public bool IsTabActive;

	bool lastState;
	int childCount;

	public Image Image;
	public Sprite SpriteOn;
	public Sprite SpriteOff;
	public Text texto;

	void Awake() {
		childCount = transform.parent.childCount;
	}
	// Update is called once per frame
	void Update () {
		if (lastState != IsTabActive) {
			lastState = IsTabActive;			
			Image.sprite = IsTabActive ? SpriteOn : SpriteOff;
			texto.color = IsTabActive ? new Color (0.082f, 0.109f, 0.168f) : new Color (1.0f, 1.0f, 1.0f); 
			transform.localScale = IsTabActive ? new Vector3 (1.1f, 1f, 1f) : Vector3.one;
			transform.SetSiblingIndex (IsTabActive ? childCount : 0);
		}
	}

}
