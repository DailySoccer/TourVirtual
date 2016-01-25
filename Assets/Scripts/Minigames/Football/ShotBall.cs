using UnityEngine;
using System.Collections;

namespace Football
{
    public class ShotBall : MonoBehaviour
    {
        public bool isActive { get; private set; }
        public void ChangeActive(){
            isActive = true;
        }
    }
}