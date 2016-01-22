using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[ExecuteInEditMode]
public class LoadingBar : MonoBehaviour {


    public static LoadingBar Instance { get; private set; }

    public Image fillBar;
	public Text description;
	public float Current = 0;


    void Awake()
    {
        Instance = this;
    }

	public void SetValue(float value) {
        Current = Mathf.Clamp (value, 0, 1);
	}

	public void SetValue(float value, string texto) { 
		SetValue (value);
		description.text = texto;
	}

	// Update is called once per frame
	void Update () {
		if (fillBar != null) {
			fillBar.fillAmount = Current;
		}
	}

    public void Hide()
    {
        gameObject.SetActive(false);
    }

}
