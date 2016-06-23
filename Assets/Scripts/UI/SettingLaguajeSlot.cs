using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SettingLaguajeSlot : MonoBehaviour {

	public Image iconSelected;
	public Text Texto;

	public void SetActive(bool isActive) {
		iconSelected.enabled = isActive;
		Texto.color = isActive ? new Color(0.00235f, 0.10980f, 0.16862f) : new Color(0.2392f, 0.10980f, 0.16862f);
	}

}
