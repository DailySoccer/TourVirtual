using UnityEngine;
using System.Collections;

namespace Football
{
    public class Keeper : MonoBehaviour
    {
        float vel = 0;
        void Start() {
            Setup(2);
        }

        public void Setup(int level) {
            switch(level) {
                case 0:
                    gameObject.SetActive(false);
                    break;

                case 1:
                    gameObject.SetActive(true);
                    transform.position = new Vector3(-51.9f, 0.9f, Random.Range(-3f, 3f));
                    vel = 0;
                    break;

                case 2:
                    gameObject.SetActive(true);
                    transform.position = new Vector3(-51.9f, 0.9f, Random.Range(-3f, 3f));
                    vel = Random.value >= 0.5f ? -2 : 2;
                    break;
            }
        }

        void Update() {
            var pos = transform.position + Vector3.forward * vel * Time.deltaTime;
            if (pos.z < -3f) { pos.z = -3f; vel *=-1f; }
            if (pos.z >  3f) { pos.z =  3f; vel *=-1f; }
            transform.position = pos;
        }

    }
}