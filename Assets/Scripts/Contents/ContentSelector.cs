using UnityEngine;
using System.Collections;

public class ContentSelector : MonoBehaviour {
    void Start() {
        OnDeselect();
    }

    public void OnSelect() {
        gameObject.SetActive(true);
    }

    public void OnDeselect() {
        gameObject.SetActive(false);
    }
}
