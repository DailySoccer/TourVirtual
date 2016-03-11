#if !LITE_VERSION
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Este objeto esta asociado al GameObject MainManager

namespace HiddenObjects { 
    public class HiddenObjects : MonoBehaviour {
        public int objectByRoom = 5;
        public int numHiddenObjects = 10;
        public float maxTime = 20;
        float startTime;
        float endTime;
        public GameObject prefab;
        List<HiddenObjectPosition> ListOfHiddenObjects;

        public float RemaingTime { get { return endTime - startTime; } }

        public class HiddenObjectPosition {
            public string roomid;
            public int position;

            public HiddenObjectPosition(string id, int pos) {
                roomid = id;
                position = pos;
            }
        }

        public static HiddenObjects Instance { private set; get; }

        void Awake() {
            Instance = this;
        }

        void Start() {
            enabled = false;
            RoomManager.Instance.OnSceneReady += OnSceneReady;
        }

        void OnSuccess() {
            Stop();
        }

        void OnFail() {
            var obj = GameObject.Find("Tesoros");
            if(obj!=null)
                Destroy(obj);
            Stop();
        }        

        public void Play() {
            if (enabled) return;
            Debug.LogError(">>>> HiddenObjects.Play()");

            enabled = true;
            // Crear una lista de objetos.
            List<HiddenObjectPosition> usefullRooms = new List<HiddenObjectPosition>();

            foreach (var pair in RoomManager.Instance.RoomDefinitions) {
                RoomDefinition rd = pair.Value as RoomDefinition;
                if(rd.HiddenObjects) {
                    for (int i = 0; i < objectByRoom; ++i)
                        usefullRooms.Add(new HiddenObjectPosition(rd.Id, i));
                }
            }
            List<HiddenObjectPosition> finalList = new List<HiddenObjectPosition>();
            // Seleccionar el numero de objetos totales.
            for ( int i = 0; i < numHiddenObjects; ++i){
                int idx = Random.Range(0, usefullRooms.Count);
                finalList.Add( usefullRooms[idx] );
                usefullRooms.RemoveAt(idx);
            }
            ListOfHiddenObjects = finalList;
            startTime = Time.realtimeSinceStartup;
            endTime = startTime + maxTime;

            OnSceneReady();

        }

        public void Stop() {
            enabled = false;
        }

        public void OnSceneReady() {
            if (enabled) {
                GameObject tesoros = GameObject.Find("TESOROS");
                if (tesoros != null) {
                    foreach (var obj in ListOfHiddenObjects) {
                        if(obj.roomid == RoomManager.Instance.Room.Id) {
                            Transform parent = tesoros.transform.GetChild(obj.position);
                            if (parent != null) {
                                if (prefab != null) {
                                    Transform io = (Instantiate(prefab) as GameObject).transform;
                                    io.name = obj.position.ToString();
                                    io.parent = parent;
                                    io.localPosition = Vector3.zero;
                                }
                            }
                        }
                    }
                }
            }
        }

        void Update() {
            if( Time.realtimeSinceStartup > endTime) {
                OnFail();
                return;
            }
            maxTime -= Time.deltaTime;
            if (Input.GetMouseButtonDown(0)) {
                Ray mouse = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit[] hits = Physics.RaycastAll(mouse,float.MaxValue, (1 << 14) );
                if (hits.Length > 0) {
                    foreach (var hit in hits) {
                        hit.transform.GetComponent<Collider>().enabled = false;
                        RemoveObject(RoomManager.Instance.Room.Id, int.Parse(hit.transform.name));
                        StartCoroutine(Pickup(hit.transform));
                    }
                }
            }
        }

        void RemoveObject(string id, int pos) {
            for( int i=0;i< ListOfHiddenObjects.Count;++i) {
                var item = ListOfHiddenObjects[i];
                if (item.roomid == id && item.position == pos) {
                    ListOfHiddenObjects.RemoveAt(i);
                    break;
                }
            }
            if (ListOfHiddenObjects.Count == 0) OnSuccess();
        }

        IEnumerator Pickup(Transform t) {
            while (t.localScale.x < 1.5f) {
                float v = Time.deltaTime * 4.0f;
                t.localScale += new Vector3(v, v, v);
                yield return null;
            }
            while (t.localScale.x > 0f) {
                float v = Time.deltaTime * 4.0f;
                t.localScale -= new Vector3(v, v, v);
                yield return null;
            }
            Destroy(t.gameObject);
        }
    }
}

#endif