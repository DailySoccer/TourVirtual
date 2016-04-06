#if !LITE_VERSION

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using SmartLocalization;

public class GuiMinigameScreen : GUIScreen {

    public Text TxtScore;
    public Text TxtRecord;
    public MinigameTimerHUD timer;

    public override void Awake () {
		base.Awake ();
	}

	public override void Start() {
        base.Start();
		//TODO: llamar al canvas controller de esta escena para que muestre la ventana del final.
        //OnHide();
    }

	public override void Update () {
		base.Update ();
	}

    public void Record(int value)
    {
		TxtRecord.text = LanguageManager.Instance.GetTextValue("TVB.Minigame.Record") + ": " + value.ToString();
    }

    public void Score(int value)
    {
        TxtScore.text = value.ToString();
    }

    public void Time(float normTime)
    {
        timer.TimeLeft = normTime;
    }

	/*
    public void OnShow() {
        gameObject.SetActive(true);
    }

    public void OnHide() {
        gameObject.SetActive(false);
    }
	*/
}

#endif