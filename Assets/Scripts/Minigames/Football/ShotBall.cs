using UnityEngine;
using System.Collections;

namespace Football
{
    public class ShotBall : MonoBehaviour
    {
        public enum Mode
        {
            Wait,
            Shot,
            Goal,
            Clear,
            Out
        };

        public Mode mode = Mode.Wait;
        float _effect;
        public float effect { set { _effect = value; mode = Mode.Shot; } }
        Rigidbody rb;

        public bool isActive { get; private set; }
        public void ChangeActive() {
            isActive = true;
        }
        void Start() {
            rb = GetComponent<Rigidbody>();
        }

        void FixedUpdate() {
            if (mode != Mode.Wait && _effect != 0)
                rb.AddForce(Vector3.forward * _effect, ForceMode.Impulse);
                
            if (mode == Mode.Shot && (rb.velocity.sqrMagnitude < 0.1f || rb.position.x < -53f) )
                mode = ShotBall.Mode.Out;
        }

        void OnCollisionEnter(Collision collision) {
            if (mode == Mode.Shot && collision.gameObject.name != "Game" && collision.gameObject.name != "Ball")
                mode = Mode.Clear;
        }
    }
}