using UnityEngine;
using System.Collections;

public class PhotoViewer : MonoBehaviour {

    Coroutine lastCoroutine;
    Texture2D texture;

    float orthoZoomSpeed = 5f;
    float zoomSize = 1;
    Vector2 offset = Vector2.zero;
    Vector2 midScreen;
    Vector2 textureSize;
    Vector2 lastTouch;
    bool draggin = false;

    // Use this for initialization
    void Start () {
        lastCoroutine = StartCoroutine( DownloadImage( "https://az726872.vo.msecnd.net/global-contentasset/asset_92d476d9-7c95-4102-8d7d-b9f18c1fadc7.jpg" ) );
        midScreen = new Vector2(Screen.width, Screen.height) * 0.5f;
    }

    IEnumerator DownloadImage(string url) {
        WWW www = new WWW(url);
        yield return www;
        texture = www.texture;
        textureSize = new Vector2(texture.width, texture.height);
        if (textureSize.x > textureSize.y) {
            float scale = 1;
            if (textureSize.x > Screen.width) {
                scale = Screen.width / textureSize.x;
                textureSize.x = Screen.width;
                textureSize.y *= scale;
            }
        }
        else {
            float scale = 1;
            if (textureSize.y > Screen.height) {
                scale = Screen.height / textureSize.y;
                textureSize.y = Screen.height;
                textureSize.x *= scale;
            }
        }

        zoomSize = textureSize.x;
    }

    void Update()
    {
        // If there are two touches on the device...
        if (Input.touchCount == 2 && Input.GetTouch(0).phase == TouchPhase.Moved && Input.GetTouch(1).phase == TouchPhase.Moved) {
            // Store both touches.
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Find the position in the previous frame of each touch.
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // Find the difference in the distances between each frame.
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;
            zoomSize -= deltaMagnitudeDiff * orthoZoomSpeed;
            draggin = false;
        }
        else {
            if (Input.touchCount == 1) {
                if (Input.GetTouch(0).phase == TouchPhase.Began) {
                    if (Input.GetTouch(0).tapCount == 2) {
                        if (zoomSize == textureSize.x)
                            zoomSize = textureSize.x * 2f;
                        else {
                            zoomSize = textureSize.x;
                            offset = Vector2.zero;
                        }
                    }
                    else {
                        lastTouch = Input.GetTouch(0).position;
                        draggin = true;
                    }
                }
                else
                if (Input.GetTouch(0).phase == TouchPhase.Moved && draggin){
                    Touch touch = Input.GetTouch(0);
                    Vector3 diff = Input.GetTouch(0).position - lastTouch;
                    lastTouch = Input.GetTouch(0).position;
                    offset += new Vector2(diff.x, -diff.y);
                }
            }
            else
                draggin = false;
        }
    }

    void OnGUI() {
        if (texture) {
            float zoom = zoomSize / textureSize.x;
            if (zoom < 1) zoom = 1;
            Rect r = new Rect(offset.x + midScreen.x - textureSize.x * 0.5f * zoom, offset.y + midScreen.y - textureSize.y * 0.5f * zoom,
                textureSize.x * zoom, textureSize.y * zoom);
            GUI.DrawTexture(r, texture);
        }
    }
}