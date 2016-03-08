using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class LoadingCanvasManager : MonoBehaviour {

    public static LoadingCanvasManager Instance { get; private set; }
    void Awake () {
        Instance = this;
        Instance.gameObject.SetActive(false);
    }

    public static void Show() {
        Instance.gameObject.SetActive(true);
    }

    public static void Hide() {
        Instance.gameObject.SetActive(false);
    }

}
