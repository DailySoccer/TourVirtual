using UnityEngine;
using System.Collections;

public class ContentSelector : MonoBehaviour
{
    public GameObject Marker;

    void Start() {
        OnDeselect();
    }

    public void OnSelect() {
        if(Marker!=null) Marker.SetActive(true);
    }

    public void OnDeselect() {
        if (Marker != null) Marker.SetActive(false);
    }
}
