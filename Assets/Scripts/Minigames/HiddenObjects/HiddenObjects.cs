using UnityEngine;
using System.Collections;

namespace HiddenObjects
{
    public class HiddenObjects : MonoBehaviour {


        public static HiddenObjects Instance { private set; get; }

        void Awake() {
            Instance = this;
        }

        void Start() {
            enabled = false;
            RoomManager.Instance.OnSceneReady += OnSceneReady;
        }

        public void Play() {
            enabled = true;
        }

        public void Stop() {
            enabled = false;
        }

        public void OnSceneReady() {
            if (enabled) {
                GameObject tesoros = GameObject.Find("Tesoros");
                if (tesoros != null) {
                    Debug.LogError("En " + RoomManager.Instance.Room.Id + " hay " + tesoros.transform.childCount + " tesoros.");
                }
            }
        }
    }
}