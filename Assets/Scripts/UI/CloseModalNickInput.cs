using UnityEngine;
using System.Collections;

public class CloseModalNickInput: MonoBehaviour {
	public void CloseModal() {
		ModalNickInput.Instance.EvaluateNick ();
		if (ModalNickInput.Instance.TheNick.text.Length >= 3)
			ModalNickInput.Instance.AcceptNick ();
	}
}
