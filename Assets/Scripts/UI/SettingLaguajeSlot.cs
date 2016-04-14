using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SettingLaguajeSlot : MonoBehaviour {

	public Image iconSelected;
	public Text Texto;

	public void SetActive(bool isActive) {
		iconSelected.enabled = isActive;
		Texto.color = isActive ? new Color(0.239f, 0.286f, 0.392f) : new Color(0.619f, 0.619f, 0.619f);
	}

}
