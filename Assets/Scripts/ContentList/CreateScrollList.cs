using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Item {
	public string name;
}

public class CreateScrollList : MonoBehaviour {

	public GameObject sampleButton;
	public List<Item> itemList;

	public Transform contentPanel;

	void Start () {
		PopulateList();	
	}

	void PopulateList() {
		foreach(var item in itemList) {
			GameObject newButton = Instantiate(sampleButton) as GameObject;
			ContentItem contentItem = newButton.GetComponent<ContentItem>();
			contentItem.Title.text = item.name;
			newButton.transform.SetParent(contentPanel);
		}
	}
}
