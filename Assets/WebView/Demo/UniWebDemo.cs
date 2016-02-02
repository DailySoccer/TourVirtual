//
//	UniWebDemo.cs
//  Created by Wang Wei(@onevcat) on 2013-10-20.
//
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// This is a demo script to show how to use UniWebView.
/// You can follow the step 1 to 10 and get started with the basic use of UniWebView.
/// </summary>
public class UniWebDemo : MonoBehaviour {

	public GameObject cubePrefab;
	public TextMesh tipTextMesh;

//Just let it compile on platforms beside of iOS and Android
//If you are just targeting for iOS and Android, you can ignore this
#if UNITY_IOS || UNITY_ANDROID || UNITY_WP8

	//1. First of all, we need a reference to hold an instance of UniWebView
	private UniWebView _webView;

	private string _errorMessage;


	void Update() {
	}
	

	void OnGUI() {
		if (GUI.Button(new Rect(0, Screen.height - 150, 150, 80),"Open")) {
			//2. You can add a UniWebView either in Unity Editor or by code.
			//Here we check if there is already a UniWebView component. If not, add one.
			_webView = GetComponent<UniWebView>();
			if (_webView == null) {
				_webView = gameObject.AddComponent<UniWebView>();
				_webView.OnReceivedMessage += OnReceivedMessage;
				_webView.OnLoadComplete += OnLoadComplete;
				_webView.OnWebViewShouldClose += OnWebViewShouldClose;
				_webView.OnEvalJavaScriptFinished += OnEvalJavaScriptFinished;

				_webView.InsetsForScreenOreitation += InsetsForScreenOreitation;
			}

			_webView.url = "http://www.w3schools.com/html/mov_bbb.mp4";
			_webView.Load();

		}
	}

	//5. When the webView complete loading the url sucessfully, you can show it.
	//   You can also set the autoShowWhenLoadComplete of UniWebView to show it automatically when it loads finished.
	void OnLoadComplete(UniWebView webView, bool success, string errorMessage) {
		if (success) {
			webView.Show();
		} else {
			Debug.Log("Something wrong in webview loading: " + errorMessage);
			_errorMessage = errorMessage;
		}
	}

	//6. The webview can talk to Unity by a url with scheme of "uniwebview". See the webpage for more
	//   Every time a url with this scheme clicked, OnReceivedMessage of webview event get raised.
	void OnReceivedMessage(UniWebView webView, UniWebViewMessage message) {
		Debug.Log ("Received a message from native");
	}

	//9. By using EvaluatingJavaScript method, you can talk to webview from Unity.
	//It can evel a javascript or run a js method in the web page.
	//(In the demo, it will be called when the cube hits the sphere)
	public void ShowAlertInWebview(float time, bool first) {
		if (first) {
			//Eval the js and wait for the OnEvalJavaScriptFinished event to be raised.
			//The sample(float time) is written in the js in webpage, in which we pop
			//up an alert and return a demo string.
			//When the js excute finished, OnEvalJavaScriptFinished will be raised.
			_webView.EvaluatingJavaScript("sample(" + time +")");
		}
	}

	//In this demo, we set the text to the return value from js.
	void OnEvalJavaScriptFinished(UniWebView webView, string result) {
		Debug.Log("js result: " + result);
		tipTextMesh.text = "<color=#000000>" + result + "</color>";
	}

	//10. If the user close the webview by tap back button (Android) or toolbar Done button (iOS),
	//    we should set your reference to null to release it.
	//    Then we can return true here to tell the webview to dismiss.
	bool OnWebViewShouldClose(UniWebView webView) {
		Debug.Log("jOnWebViewShouldClose" );
		if (webView == _webView) {
			_webView = null;
			return true;
		}
		return false;
	}

	// This method will be called when the screen orientation changed. Here we returned UniWebViewEdgeInsets(5,5,bottomInset,5)
	// for both situation. Although they seem to be the same, screenHeight was changed, leading a difference between the result.
	// eg. on iPhone 5, bottomInset is 284 (568 * 0.5) in portrait mode while it is 160 (320 * 0.5) in landscape.
	UniWebViewEdgeInsets InsetsForScreenOreitation(UniWebView webView, UniWebViewOrientation orientation) {
		return new UniWebViewEdgeInsets(0,0,0,0);
    }
#else //End of #if UNITY_IOS || UNITY_ANDROID || UNITY_WP8
	void Start() {
		Debug.LogWarning("UniWebView only works on iOS/Android/WP8. Please switch to these platforms in Build Settings.");
	}
#endif
}
