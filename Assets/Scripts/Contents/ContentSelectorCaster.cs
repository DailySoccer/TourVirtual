using UnityEngine;
using System.Collections;

public class ContentSelectorCaster : MonoBehaviour {
    public float maxDistance = 10;
    int contentLayer;
    Vector3 lastPosition;
    Quaternion lastRotation;
    GameObject oldContent;
    void Start() {
        contentLayer = LayerMask.GetMask("Content");
    }

    void FixedUpdate() {
        if (transform.position != lastPosition || transform.rotation != lastRotation) {
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
                GameObject cs = best.transform.gameObject;
                if (cs!= oldContent) {
                    if (oldContent != null) {
                        oldContent.SendMessage("OnDeselect");
                        //for (int i = 0; i < oldContent.transform.childCount; ++i)
                        //    oldContent.transform.GetChild(i).gameObject.SetActive(false);
                    }
                    oldContent = cs;
                    oldContent.SendMessage("OnSelect");
                    for (int i = 0; i < oldContent.transform.childCount; ++i)
                        oldContent.transform.GetChild(i).gameObject.SetActive(true);

                }
            }
            else {
                if (oldContent != null) {
                    oldContent.SendMessage("OnDeselect");
                    //for (int i = 0; i < oldContent.transform.childCount; ++i)
                    //    oldContent.transform.GetChild(i).gameObject.SetActive(false);
                    oldContent = null;
                }
            }
        }
    }

}
