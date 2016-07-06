using UnityEngine;

namespace Basket {
    public class GoalArea : MonoBehaviour {
        public ParticleSystem psStar;
        public Shooter shooter;

        // Use this for initialization
        void Start() {

        }

#if UNITY_EDITOR
        void Update() {
            if (Input.GetKeyDown(KeyCode.Return))
                OnGoal();
        }
#endif
        void OnTriggerEnter(Collider other) {
            ShotBall sb = other.GetComponent<ShotBall>();

            if (sb != null) {
				if (!sb.isScored) { 
					sb.isScored = true;
					other.name = "goal";
                	OnGoal();
				}
            }
        }

        void OnGoal() {
            // Goal!!
            psStar.Play();
            if (shooter != null) shooter.OnScore();
        }
    }
}
