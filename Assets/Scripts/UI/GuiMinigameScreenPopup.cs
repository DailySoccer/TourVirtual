using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GuiMinigameScreenPopup : GUIPopUpScreen {

    public override void Awake () {
		base.Awake ();
	}

	public override void Start() {
        base.Start();
    }

	public override void Update () {
		base.Update ();
	}

    public void OnHide()
    {
        gameObject.SetActive(false);
    }
}
