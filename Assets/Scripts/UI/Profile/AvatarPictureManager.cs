using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AvatarPictureManager : MonoBehaviour {

	public List<Sprite> AvatarSprites;

	public Sprite GetAvatarPicture(string id) {
		//Debug.Log ("[AvatarPictureManager] in " + name + ": La cabeza del avatar es `" + id + "`");
		return AvatarSprites.Find (d => d.name == id);
	}
}
