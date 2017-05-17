using UnityEngine;
using System.Collections;

public class ContentInfo : MonoBehaviour {
	
	public string Title;
	public Sprite Image;
	public string Description;
	public bool Money = false;

	static public ContentInfo ContentSelected;
	
	public Transform PointOfInterest {
		get {
			Transform point = transform.FindChild("Point");
			return point ?? transform;
		}
	}
	
	void Start () {
	}
	
	void Update () {
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
    /*
    void OnTriggerEnter(Collider other) {
		if (other.tag != Player.TagUmaAvatar)
			return;
		
		// Debug.Log ("Enter: Cubemap: " + gameObject.name);
		
		ContentSelected = this;
	}
	
	void OnTriggerExit(Collider other) {
		if (other.tag != Player.TagUmaAvatar)
			return;
		
		// Debug.Log ("Exit: Cubemap: " + gameObject.name);
		
		if (ContentSelected == this) {
			ContentSelected = null;
		}
	}
	*/
	GameObject _instance;
}

