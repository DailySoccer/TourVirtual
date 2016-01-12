using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ContentImageController : MonoBehaviour {

	public Text IdContent;
	public Text Title;
	public Text Description;
	public RawImage Imagen;

	public int Index = 0;

	public ContentList CurrentContent {
		get {
			return ContentManager.Instance.ContentNear;
		}
	}
	
	public void Set(CompactContent compactContent) {
		gameObject.SetActive(true);

		IdContent.text = compactContent.IdContent;
		Title.text = compactContent.Title;
		Description.text = compactContent.Description;

		if (compactContent.IsImage) {
			StartCoroutine(ContentManager.Instance.GetTexture2DInstance(compactContent.AssetUrl, (texture2D) => Imagen.texture = texture2D));
		}
	}

	public int Count {
		get {
			return CurrentContent.Count;
		}
	}
	
	public bool Empty {
		get {
			return CurrentContent.Count == 0;
		}
	}
	
	public bool IsFirst {
		get {
			return (CurrentContent.Count > 0) && (Index == 0);
		}
	}
	
	public bool IsLast {
		get {
			return (CurrentContent.Count > 0) && (Index == CurrentContent.Count - 1);
		}
	}
	
	public CompactContent CurrentImage {
		get {
			return CurrentContent.GetInstance(Index);
		}
	}
	
	public void Next() {
		if (CurrentContent.Count == 0)
			return;
		
		if (++Index > CurrentContent.Count - 1) {
			Index = CurrentContent.Count - 1;
		}

		Set (CurrentImage);
	}
	
	public void Prev() {
		if (CurrentContent.Count == 0)
			return;
		
		if (--Index < 0) {
			Index = 0;
		}

		Set (CurrentImage);
	}

	void Start () {
	}
	
	void Update () {
	}

	public IEnumerator ShowContents() {
		gameObject.SetActive(true);

		// TODO: FAKE
		Title.text = "Don Alfredo Di Stéfano";

		yield return StartCoroutine(CurrentContent.LoadContents());

		Index = 0;

		if (CurrentImage != null) {
			Set (CurrentImage);
		}
	}
	
	public IEnumerator HideContents() {
		gameObject.SetActive(false);
		
		yield return null;
	}
}
