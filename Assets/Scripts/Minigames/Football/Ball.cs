using UnityEngine;
using System.Collections;

namespace Football
{
    public class Ball : MonoBehaviour
    {
        public float effect = 0;
        Rigidbody rb;
        void Start() {
            rb = GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            if (effect!=0) {
                rb.AddForce(Vector3.forward * effect, ForceMode.Impulse);
            }
        }
    }
}