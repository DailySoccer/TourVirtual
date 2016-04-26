using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class LoadingCanvasManager : MonoBehaviour {

	public UIScreen LoadingScreen;

    public static LoadingCanvasManager Instance { get; private set; }
    void Awake () {
        Instance = this;
		Hide ();
    }

    public static void Show(string text="") {
        if(text!="") LoadingContentText.SetText(text);
        //Instance.gameObject.SetActive(true);

        if (Instance.LoadingScreen == null)
			Debug.LogError("[LoadingCanvasManager] in " + Instance.gameObject.name + ": No esta asignada la pantalla de loading.");
		else 
			Instance.LoadingScreen.IsOpen = true;        
    }

    public static void Hide() {
		if (Instance.LoadingScreen == null)
			Debug.LogError("[LoadingCanvasManager] in " + Instance.gameObject.name + ": No esta asignada la pantalla de loading.");
		else 
			Instance.LoadingScreen.IsOpen = false;

        //Instance.gameObject.SetActive(false);
    }

}
