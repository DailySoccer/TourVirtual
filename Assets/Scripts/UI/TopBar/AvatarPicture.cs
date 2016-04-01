//#if !LITE_VERSION

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

//[ExecuteInEditMode]
public class AvatarPicture : MonoBehaviour {

	public Image Avatar;

	//public int Index;

	//public List<Sprite> AvatarPictures;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void OnEnable () {
		StartCoroutine (SetAvatarPictureWhenInitializeAPI ());
		//SetAvatarPicture ();
	}


	public IEnumerator SetAvatarPictureWhenInitializeAPI() {
		while (UserAPI.AvatarDesciptor.Head == null) {
			yield return null;
		}
		Debug.LogError("[AvatarPicture] in " + name + ": UserAPI.AvatarDesciptor.Head >>> initialized <<<");
		SetAvatarPicture ();
	} 
	public void SetAvatarPicture() {
		if (Avatar.sprite != null) {
			if (UserAPI.Instance != null) {
				string cara = "";
				Avatar.sprite = MainManager.Instance.GetComponent<AvatarPictureManager>().GetAvatarPicture(UserAPI.AvatarDesciptor.Head);
				/*
				VirtualGoodsAPI.VirtualGood vg  = UserAPI.VirtualGoodsDesciptor.GetByGUID(UserAPI.AvatarDesciptor.Head);
				if (vg != null) {
					cara = vg.Image;
					if (!string.IsNullOrEmpty(cara)) {
						StartCoroutine (MyTools.LoadSpriteFromURL (cara, Avatar.gameObject));
					}
					else {
						Debug.LogError("[SetAvatarPicture] in " + name + ":  La url de la cara del player no es válida");
					}
				}
				else {
					Debug.LogError("[SetAvatarPicture] in " + name + ":  No se ha podido averiguar la imagen del avatar");			
				}
				*/
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

//#endif