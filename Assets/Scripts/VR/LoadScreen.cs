using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadScreen : MonoBehaviour
{

	public float DistanceToCamera = 1.5f;
	public Canvas LoadScreenCanvas;
	// Use this for initialization
	void Start()
	{
		MainManager.Instance.OnVRModeSwitch -= VRSwitch;
		MainManager.Instance.OnVRModeSwitch += VRSwitch;
	}
	private void VRSwitch()
	{
		if (MainManager.Instance.IsVrModeEnabled)
		{
			CanvasRootController.Instance.OldLayerMask = transform.GetComponent<Camera>().cullingMask;
			CanvasRootController.Instance.UIScreensCamera = transform.GetComponent<Camera>();
			LoadScreenCanvas.renderMode = RenderMode.WorldSpace;
			LoadScreenCanvas.transform.SetParent(transform);
			float oldScale = LoadScreenCanvas.transform.localScale.x;
			float width = LoadScreenCanvas.transform.GetComponent<RectTransform>().sizeDelta.x;
			float fov = transform.GetComponent<Camera>().fieldOfView;
			float targetwidth = DistanceToCamera * 2 * Mathf.Tan(fov * Mathf.Deg2Rad * 0.5f);
			float resizeFactor = targetwidth / (oldScale * width);
			LoadScreenCanvas.transform.localScale *= 4 * resizeFactor;
			LoadScreenCanvas.transform.localRotation = Quaternion.identity;
			LoadScreenCanvas.transform.localPosition = new Vector3(0, 0, DistanceToCamera);
		}
	}
}
