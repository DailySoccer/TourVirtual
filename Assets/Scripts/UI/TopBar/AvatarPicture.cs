using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

//[ExecuteInEditMode]
public class AvatarPicture : MonoBehaviour {

	public Image Avatar;

	public int Index;

	public List<Sprite> AvatarPictures;

	// Use this for initialization
	void Start () {	
	}
	
	// Update is called once per frame
	void Update () {
		if (Index >= 0) {
			if (Index <= AvatarPictures.Count) {
				Avatar.sprite = AvatarPictures [Index];
			}
			else {
				Index = AvatarPictures.Count;
			}
		} else {
			Index = 0;
		}
	}

	public void SetAvatarPicture(int index) {
		if (AvatarPictures.Count <= index) {
			Avatar.sprite = AvatarPictures[index];
		}
	}
}
