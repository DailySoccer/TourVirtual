﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ContentList : MonoBehaviour {
	public string ContentKey;
	public List<CompactContent> CompactContents = new List<CompactContent>();

	public Transform PointOfInterest {
		get {
			Transform point = transform.FindChild("Point");
			return point ?? transform;
		}
	}

	public int Count {
		get {
			return CompactContents.Count;
		}
	}
	
	public bool Empty {
		get {
			return CompactContents.Count == 0;
		}
	}

	public CompactContent GetInstance(int index) {
		return Count > 0 ? CompactContents[index] : null;
	}

	void Start () {
        for (int i = 0; i < transform.childCount; ++i)
            transform.GetChild(i).gameObject.SetActive(false);
    }

	void Update () {
	}

	public IEnumerator LoadContents() {
		yield return StartCoroutine(ContentManager.Instance.LoadContentsByKey(ContentKey));
		CompactContents = ContentManager.Instance.GetCompactContentsByKey(ContentKey);
	}

	public IEnumerator LoadContents(string contentType) {
		yield return StartCoroutine(ContentManager.Instance.LoadContentsByType(contentType));
		CompactContents = ContentManager.Instance.GetCompactContentsByType(contentType);
	}

    void OnSelect()
    {
        ContentManager.Instance.ContentNear = this;
    }

    void OnDeselect()
    {
        if (ContentManager.Instance.ContentNear == this)
        {
            ContentManager.Instance.ContentNear = null;
        }
    }
}
