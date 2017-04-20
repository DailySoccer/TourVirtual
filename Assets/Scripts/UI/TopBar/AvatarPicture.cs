using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class AvatarPicture : MonoBehaviour {

	public Image Avatar;

    string cara;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void OnEnable () {
		StartCoroutine (SetAvatarPictureWhenInitializeAPI ());
		//SetAvatarPicture ();
	}

    void Update() {
        // Actualizar la imagen si cambia la cara del avatar
        if (UserAPI.AvatarDesciptor.Head != null && UserAPI.AvatarDesciptor.Head != cara) {
            // Debug.Log("AvatarPicture CHANGING");
            SetAvatarPicture();
        }
    }

	public IEnumerator SetAvatarPictureWhenInitializeAPI() {
		while (UserAPI.AvatarDesciptor.Head == null) {
			yield return null;
		}
		SetAvatarPicture ();
	} 

	public void SetAvatarPicture() {
        if (Avatar.sprite != null && UserAPI.Instance != null) {
            cara = UserAPI.AvatarDesciptor.Head;
            Avatar.sprite = MainManager.Instance.GetComponent<AvatarPictureManager>().GetAvatarPicture(cara);
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
