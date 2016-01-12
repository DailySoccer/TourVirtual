using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
[RequireComponent (typeof(Scrollbar))]
public class ScrollbarVisibility : MonoBehaviour {

	Scrollbar scrollBarComponent;
	Color colorHide = new Color(1f,1f,1f,0f);
	Color colorShow = new Color(1f,1f,1f,1f);
	void Awake() {
		scrollBarComponent = GetComponent<Scrollbar>();

	}
	// Update is called once per frame
	void Update () {
		scrollBarComponent.targetGraphic.color = (scrollBarComponent.size < 0.8f)? colorShow : colorHide;
	}
}
