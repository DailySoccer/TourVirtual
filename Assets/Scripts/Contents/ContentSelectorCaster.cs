using UnityEngine;
using System.Collections;

public class ContentSelectorCaster : MonoBehaviour {
    public float maxDistance = 10;
    int contentLayer;
    Vector3 lastPosition;
    Quaternion lastRotation;
    ContentSelector oldContentSelector;
    void Start() {
        contentLayer = LayerMask.GetMask("Content");
    }

    void FixedUpdate() {
        if (transform.position != lastPosition || transform.rotation != lastRotation)
        {
            lastPosition = transform.position;
            lastRotation = transform.rotation;
            // Mirar si estoy en la layer de player.
            Ray ray = new Ray(transform.position + Vector3.up, transform.forward);
            var hits = Physics.RaycastAll(transform.position + Vector3.up, transform.forward, maxDistance, contentLayer);
            if (hits.Length != 0) {
                RaycastHit best = hits[0];
                for(int i=1;i<hits.Length;++i) {
                    var hit = hits[i];
                    if (hit.distance < best.distance)
                        best = hit;
                }
                var cs = best.transform.GetComponent<ContentSelector>();
                if (cs != null && cs!= oldContentSelector) {
                    if (oldContentSelector != null) oldContentSelector.OnDeselect();
                    oldContentSelector = cs;
                    oldContentSelector.OnSelect();
                }
            }
            else
            {
                if (oldContentSelector != null) oldContentSelector.OnDeselect();
                oldContentSelector = null;
            }


        }
    }

}
