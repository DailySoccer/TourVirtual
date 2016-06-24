using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelFanRankingSlot : MonoBehaviour {

	public Text Position;
	public Text Name;
	public Text Points;

	public Image Selector;

	public Color NormalColor;
	public Color SelectedColor;

	// Use this for initialization
	void Start () {	
	}
	
	// Update is called once per frame
	void Update () {	
	}

	public void SetupSlot(string position, string name, string points, bool isMe) {
		Position.text = position;
		Position.color = isMe ? SelectedColor : NormalColor;

		Name.text = name;
		Name.color = isMe ? SelectedColor : NormalColor;

		Points.text = points;
		Points.color = isMe ? SelectedColor : NormalColor;

		Selector.enabled = isMe;
	}
}
