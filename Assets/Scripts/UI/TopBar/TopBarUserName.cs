#if !LITE_VERSION
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TopBarUserName : MonoBehaviour {

	public Text UserName;
	public Image Flag;
	public AvatarPicture ProfilePicture;
	
	void Update () {
		if (UserAPI.Instance != null) 
			UserName.text = UserAPI.Instance.Nick;

		//TODO: ProfilePicture ID.
		//ProfilePicture.Index = UserAPI.Instance 

		//TODO: Recuperar la bandera de la nacionalidad del usuario
		//if (Flag.isActiveAndEnabled)
		//	Flag.sprite = UserAPI.Instance.FlagSprite;
	}
}
#endif