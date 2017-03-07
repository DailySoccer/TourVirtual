using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class AvatarPicture : MonoBehaviour {

	public Image Avatar;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void OnEnable () {
		StartCoroutine (SetAvatarPictureWhenInitializeAPI ());
		//SetAvatarPicture ();
	}

	public IEnumerator SetAvatarPictureWhenInitializeAPI() {
		while (UserAPI.AvatarDescriptor.Head == null) {
			yield return null;
		}
		SetAvatarPicture ();
	} 

	public void SetAvatarPicture() {
		if (Avatar.sprite != null) {
			if (UserAPI.Instance != null) {
				string cara = "";
				Avatar.sprite = MainManager.Instance.GetComponent<AvatarPictureManager>().GetAvatarPicture(UserAPI.AvatarDescriptor.Head);
			}
		}
	}

	/*
	public void SetAvatarPicture(int index) {
		if (AvatarPictures.Count <= index) {
			Avatar.sprite = AvatarPictures[index];
		}
	}
	*/
}
