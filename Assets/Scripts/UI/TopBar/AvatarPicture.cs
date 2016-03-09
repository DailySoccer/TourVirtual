using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

//[ExecuteInEditMode]
public class AvatarPicture : MonoBehaviour {

	public Image Avatar;
	
	void Start () {
		SetAvatarPicture ();
	}

	public void SetAvatarPicture() {
		if (UserAPI.Instance != null && MainManager.Instance != null) {
			Avatar.sprite = MainManager.Instance.GetComponent<AvatarPictureManager>().GetAvatarPicture(UserAPI.AvatarDesciptor.Head);
		}
	}
}
