using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


class TextureSwapAnimatorForUI : MonoBehaviour {
	public Sprite[] frames;

	[SerializeField]
	float framesPerSecond = 10.0f;

	void Start() {
		SortFrameByName ();
	}

	void SortFrameByName() {
		List<Sprite> list = frames.ToList ();
		list.Sort((t1,t2) => t1.name.CompareTo(t2.name));
		frames = list.ToArray();
	}

	void Update () {
		int index = (int)(Time.time * framesPerSecond);
		index = index % frames.Length;
		GetComponent<Image>().sprite = frames[index];
	}

}