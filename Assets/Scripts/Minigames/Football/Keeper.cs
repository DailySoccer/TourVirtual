using UnityEngine;
using System.Collections;

namespace Football
{
    public class Keeper : MonoBehaviour
    {
        float vel = 0;
        void Start() {
            Level(0);
        }

        public void Level(int level) {
            switch (Mathf.FloorToInt(level))
            {
                case 0:
                case 1:
                    gameObject.SetActive(false);
                    break;

                case 2:
                case 3:
                case 4:
                    gameObject.SetActive(true);
                    transform.position = new Vector3(-51.9f, 0.9f, Random.Range(-3f, 3f));
                    vel = 0;
                    break;
                case 5:
                    gameObject.SetActive(true);
                    vel = Random.value >= 0.5f ? -2 : 2;
                    break;

                default:
                    vel *= 1.4f;
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