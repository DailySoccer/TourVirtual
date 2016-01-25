using UnityEngine;
using System.Collections;

namespace Football
{
    public class ShotBall : MonoBehaviour
    {
        public bool isShoted = false;
        float _effect;
        public float effect { set { _effect = value; isShoted = true; } }
        Rigidbody rb;

        public bool isActive { get; private set; }
        public void ChangeActive(){
            isActive = true;
        }
        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            if (isShoted && _effect != 0)
            {
                rb.AddForce(Vector3.forward * _effect, ForceMode.Impulse);
            }
        }

    }
}