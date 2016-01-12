using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections;

public class ContentInfoController : MonoBehaviour {

	public Text Title;
	public Text Description;
	public RawImage Imagen;

	public UnityEvent Show3D;

	public ContentInfo CurrentContent {
		get {
			return ContentInfo.ContentSelected;
		}
	}

	public void Set(ContentInfo contentInfo) {
		gameObject.SetActive(true);
		
		Title.text = contentInfo.Title;
		// Description.text = contentInfo.Description;
		
		if (contentInfo.Image != null) {
			// Imagen = contentInfo.Image.texture;
		}
	}

	public void ShowContent3D() {
		if (Show3D != null) {
			Show3D.Invoke();
		}
	}

	void Start () {
	}
	
	void Update () {
	}
	
	public IEnumerator ShowContents() {
		gameObject.SetActive(true);

		Set (CurrentContent);

		yield return null;
	}
	
	public IEnumerator HideContents() {
		gameObject.SetActive(false);
		
		yield return null;
	}
}
