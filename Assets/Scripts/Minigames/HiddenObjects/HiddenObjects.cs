using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Este objeto esta asociado al GameObject MainManager

namespace HiddenObjects { 
	public enum HiddenObjectGameResult {
		TUTORIAL_INICIO,
		TIME_OUT,
		SUCCESS
	}

    public class HiddenObjects : MonoBehaviour {
        public int objectByRoom = 5;
        public int numHiddenObjects = 10;
        public int numFoundObjects = 0;
        public float maxTime = 20 * 60;
        float startTime;
        float endTime;
        public GameObject prefab;
        List<HiddenObjectPosition> ListOfHiddenObjects;

		public delegate void GameFinishEvent();
		public event GameFinishEvent OnGameFail;
		public event GameFinishEvent OnGameSuccess;

		ModalHiddenObjectsGameScreen mhogs;

        public float RemaingTime {
			get {
				//Debug.Log( "[HiddenObjects] in" + name + ": Tiempo restante del minijuego: " + (endTime - startTime).ToString() );
				return endTime - Time.realtimeSinceStartup;
			} 
		}

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
			enabled = false;
        }

        void Start() {            
            RoomManager.Instance.OnSceneReady += OnSceneReady;
        }

        void OnSuccess() {
            // Mandamos puntuacion al ranking.
            UserAPI.Instance.SetScore(UserAPI.MiniGame.HiddenObjects, (int)(RemaingTime * 10f));
            Authentication.AzureServices.SendAction("VIRTUALTOUR_ACC_SCORE_QUEST");


			OnGameSuccess ();
			Stop();
			mhogs.Launch_HiddenObjectModal(HiddenObjectGameResult.SUCCESS, numFoundObjects + "/" + numHiddenObjects);
        }

        void OnFail() {
            var obj = GameObject.Find("TESOROS");
            Authentication.AzureServices.SendAction("VIRTUALTOUR_ACC_SCORE_QUEST");
            if(obj!=null)
                Destroy(obj);
			            
			OnGameFail ();
			Stop();
			mhogs.Launch_HiddenObjectModal(HiddenObjectGameResult.TIME_OUT);
        }       
        
        public void Play(ModalHiddenObjectsGameScreen modal) {
			if (mhogs == null) mhogs = modal;
            
			if (enabled) return;

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
            numFoundObjects = 0;
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
			if (Input.GetMouseButtonDown(0) && Camera.main != null) {
                Ray mouse = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit[] hits = Physics.RaycastAll( mouse, 20, LayerMask.GetMask("HiddenObject") );
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
                    numFoundObjects++;
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
