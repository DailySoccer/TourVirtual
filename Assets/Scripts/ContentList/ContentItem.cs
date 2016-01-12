using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ContentItem : MonoBehaviour {
	public Text Title;
	public Text Description;

	void Start() {
	}

	public void Set(CompactContent compactContent) {
		Title.text = compactContent.Title;
		Description.text = compactContent.Description;

		_compactContent = compactContent;
	}

	public void OnClick() {
		Debug.Log ("OnClick: " + "[" + _compactContent.IdContent + "] " + _compactContent.Title);
		GameObject.Find ("ContentInfoUI").GetComponent<ContentImageController>().Set (_compactContent);
	}

	private CompactContent _compactContent;
}
