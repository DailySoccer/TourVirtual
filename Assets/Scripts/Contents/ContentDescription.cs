using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ContentDescription : MonoBehaviour {

	public enum ETipo {
		GENERICO,
		COPA,
		CAMISETA,
		BOTA,
		BALON
	}

	public ETipo Tipo;
	public string Title;
	public string Description;
	public Texture2D Image;

	void Start () {
	}
	
	void Update () {
	}
}
