using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[ExecuteInEditMode]
public class BadgeAlert : MonoBehaviour {

	public GameObject badgeObject;
	public bool IsAnimated;
	public int maxCount = 1000;

	[SerializeField]
	private int count;

	/// <summary>
	/// Gets or sets the count.
	/// </summary>
	/// <value>The number for the badge.</value>
	public int Count { 
		get{return count;}
		set{count = value;}
	}

	private int lastCount;

	Animator myAnimatorComponent;

	// Use this for initialization
	void Awake () {
		if (badgeObject == null) {
			Debug.LogError("Soy un Objecto con Badge y no tengo un badge asociado");
		}
		if (IsAnimated) {
			myAnimatorComponent = GetComponent<Animator>();
			if (myAnimatorComponent == null) {
				Debug.LogError("Soy un Objecto con Badge y no tengo un componente <Animator>");
			}
		}

		//TODO: Nos suscribimos al evento de los mensajes sin leer para actualizar el contador del Badge.
	}
	
	// Update is called once per frame
	void Update () {

		badgeObject.SetActive(count > 0);
		var Texto = badgeObject.GetComponentInChildren<Text>();
		if (Texto != null) {
			if (lastCount != count && count > 0) {
				Texto.text = count < maxCount ? count.ToString() : "+" + (maxCount -1);
				lastCount = count;

				if (IsAnimated) {
					myAnimatorComponent.SetTrigger("Tingling");
				}
			}
		}
	}

}
