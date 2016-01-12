using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class UpdateColor : MonoBehaviour {

    public Color color;
    Material material;
	// Use this for initialization
	void Start () {
        material = gameObject.GetComponent<Renderer>().sharedMaterial;
    }
	
	// Update is called once per frame
	void Update () {
        material.color = color;
    }
}
