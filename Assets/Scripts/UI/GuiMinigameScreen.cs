using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GuiMinigameScreen : GUIPopUpScreen {

    public Text TxtScore;
    public Text TxtRecord;
    public MinigameTimerHUD timer;

    public override void Awake () {
		base.Awake ();
	}

	public override void Start() {
        base.Start();
        OnHide();
    }

	public override void Update () {
		base.Update ();
	}

    public void Record(int value)
    {
        TxtRecord.text = "Record: "+value.ToString();
    }

    public void Score(int value)
    {
        TxtScore.text = value.ToString();
    }

    public void Time(float normTime)
    {
        timer.TimeLeft = normTime;
    }

    public void OnShow() {
        gameObject.SetActive(true);
    }

    public void OnHide() {
        gameObject.SetActive(false);
    }

}
