using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GuiMinigameScreenPopup : GUIPopUpScreen {

    public GameObject Tutorial;
    public GameObject StartScreen;
    public GameObject EndScreen;
    public GameObject InGameScreen;


    public override void Awake () {
		base.Awake ();
	}

	public override void Start() {
        base.Start();
        //if(score==0)
        Tutorial.SetActive(false);
        //else
        StartScreen.SetActive(true);
        EndScreen.SetActive(false);
    }

    public override void Update () {
		base.Update ();
	}

    public void OnHide()
    {
        gameObject.SetActive(false);
    }

    public void OnShow()
    {
        gameObject.SetActive(true);
    }

    public void PlayGame()
    {
                
        Tutorial.SetActive(false);
        StartScreen.SetActive(false);
        EndScreen.SetActive(false);
        InGameScreen.SetActive(true);
        // 
        GameObject.Find("Shooter").SendMessage("OnRetry");
    }

    public void EndGame()
    {
        Tutorial.SetActive(false);
        StartScreen.SetActive(false);
        EndScreen.SetActive(true);
        InGameScreen.SetActive(false);
    }

}
