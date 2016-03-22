using UnityEngine;
using System.Collections.Generic;

public class RotateDrag : MonoBehaviour
{
    float oldPoint;
    void OnMouseDown()
    {
        oldPoint = Input.mousePosition.x / Screen.width;
    }

    void OnMouseDrag()
    {
        var newPoint = Input.mousePosition.x / Screen.width;
        float dif = (oldPoint- newPoint) * 360.0f;
        transform.Rotate(Vector3.up, dif);

        oldPoint = newPoint;
    }
}
