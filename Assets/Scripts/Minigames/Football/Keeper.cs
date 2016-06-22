using UnityEngine;

namespace Football
{
    public class Keeper : MonoBehaviour
    {
        float vel = 0;
        float svel = 0;
        float Target = 0;
        bool bTarget=false;
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
                    transform.position = new Vector3(-51.9f, 0.0f, Random.Range(-3f, 3f));
                    vel = 0;
                    break;
                case 5:
                    gameObject.SetActive(true);
                    vel = Random.value >= 0.5f ? -2 : 2;
                    break;

                default: // 10% mas cada vez...
                    vel *= 1.2f;
                    break;
            }
        }
        
        void Update() {
            var pos = Vector3.zero;
            if( !bTarget){
                pos = transform.position + Vector3.forward * vel * Time.deltaTime;
                if (pos.z < -3f) { pos.z = -3f; vel *=-1f; }
                if (pos.z >  3f) { pos.z =  3f; vel *=-1f; }
            }else{
                var dif = (Target-transform.position.z);
                var fvel = svel * Time.deltaTime; 
                if( Mathf.Abs(dif) < fvel ){ // Ya llego,
                    pos = transform.position;
                    pos.z = Target; 
                }else{
                    if( dif<0 ) {
                        pos = transform.position - Vector3.forward * fvel;
                    }
                    else {
                        pos = transform.position + Vector3.forward * fvel;
                    }
                }
            }
            transform.position = pos;
        }

        public void ResetTarget(){
            bTarget=false;
        }
        public void SetTarget(float target){
            if(vel==0) vel=1;
            svel = Mathf.Abs(vel);
            Target=target;
            bTarget=true;
        }
    }
}