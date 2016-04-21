using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadingContentText : MonoBehaviour {
	

	public static LoadingContentText Instance { get; private set; }
	Text TextField;


	void Awake () {
		Instance = this;
		TextField = GetComponent<Text> ();

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void SetText(string text) {
		Instance.TextField.text = text;
	}
}
