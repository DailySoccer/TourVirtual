using UnityEngine;
using System.Collections;

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