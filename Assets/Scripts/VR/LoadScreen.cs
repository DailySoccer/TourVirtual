using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadScreen : MonoBehaviour
{

	public float DistanceToCamera = 1.5f;
	public Canvas[] ScreenCanvases;
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
			//Loading canvas
			ScreenCanvases[0].renderMode = RenderMode.WorldSpace;
			ScreenCanvases[0].transform.SetParent(transform);
			float oldScale = ScreenCanvases[0].transform.localScale.x;
			float width = ScreenCanvases[0].transform.GetComponent<RectTransform>().sizeDelta.x;
			float fov = transform.GetComponent<Camera>().fieldOfView;
			float targetwidth = DistanceToCamera * 2 * Mathf.Tan(fov * Mathf.Deg2Rad * 0.5f);
			float resizeFactor = targetwidth / (oldScale * width);
			ScreenCanvases[0].transform.localScale *= 4 * resizeFactor;
			ScreenCanvases[0].transform.localRotation = Quaternion.identity;
			ScreenCanvases[0].transform.localPosition = new Vector3(0, 0, DistanceToCamera);

			//Game canvas
			ScreenCanvases[1].renderMode = RenderMode.WorldSpace;
			ScreenCanvases[1].transform.SetParent(transform);
			oldScale = ScreenCanvases[1].transform.localScale.x;
			width = ScreenCanvases[1].transform.GetComponent<RectTransform>().sizeDelta.x;
			fov = transform.GetComponent<Camera>().fieldOfView;
			targetwidth = DistanceToCamera * 2 * Mathf.Tan(fov * Mathf.Deg2Rad * 0.5f);
			resizeFactor = targetwidth / (oldScale * width);
			ScreenCanvases[1].transform.localScale *= 3 * resizeFactor;
			ScreenCanvases[1].transform.localRotation = Quaternion.identity;
			ScreenCanvases[1].transform.localPosition = new Vector3(0, 0, DistanceToCamera);
			JoystickController[] joysticks = ScreenCanvases[1].transform.GetComponentsInChildren<JoystickController>();
			foreach (JoystickController jc in joysticks)
			{
				jc.enabled = false;
			}
		}
	}
}
