using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ContentModels : MonoBehaviour {

	static public ContentModels ContentSelected;
	
	public List<GameObject> Models;

	public GameObject GetInstance(int index) {
		return ContentManager.Instance.GetModel3DInstance(Models[index]);
	}
	
	public Transform PointOfInterest {
		get {
			Transform point = transform.FindChild("Point");
			return point ?? transform;
		}
	}

	public bool Empty {
		get {
			return Models.Count == 0;
		}
	}
	
	public int Count {
		get {
			return Models.Count;
		}
	}

    void OnSelect()
    {
        ContentSelected = this;
    }

    void OnDeselect()
    {
        if (ContentSelected == this)
        {
            ContentSelected = null;
        }
    }

//    gameObject.SendMessage("ApplyDamage", 5.0F);
/*
	void OnTriggerEnter(Collider other) {
		if (other.tag != Player.TAG_UMA_AVATAR)
			return;
		
		// Debug.Log ("Enter: Models: " + gameObject.name);
		
		ContentSelected = this;
	}
	
	void OnTriggerExit(Collider other) {
		if (other.tag != Player.TAG_UMA_AVATAR)
			return;
		
		// Debug.Log ("Exit: Models: " + gameObject.name);
		
		if (ContentSelected == this) {
			ContentSelected = null;
		}
	}
    */
}
