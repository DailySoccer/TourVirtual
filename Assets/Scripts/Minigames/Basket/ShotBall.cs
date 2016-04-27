using UnityEngine;

namespace Basket
{
    public class ShotBall : MonoBehaviour
    {


        public bool isActive { get; private set; }


        public void ChangeActive()
        {
            isActive = true;
        }
    }
}