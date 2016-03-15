using UnityEngine;
using System.Collections;

public class CloseModalNickInput: MonoBehaviour {
	public void CloseModal() {
		if (ModalNickInput.Instance.TheNick.text.Length >= 3)
			ModalNickInput.Instance.AcceptNick ();
	}
}
