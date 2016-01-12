using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ContentVideoController : MonoBehaviour {
	
	public Text IdContent;
	public Text Title;
	public Text Description;
	public RawImage Imagen;
	
	public int Index = 0;
	
	void Start () {
	}
	
	void Update () {
	}
	
	public IEnumerator ShowContents() {
		gameObject.SetActive(true);

		Title.text = ContentVideo.ContentSelected.Title;

		yield return null;
	}
	
	public IEnumerator HideContents() {
		gameObject.SetActive(false);
		
		yield return null;
	}
}
