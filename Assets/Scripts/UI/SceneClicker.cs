using System;
using UnityEngine;


public class SceneClicker : MonoBehaviour
{
	public event Action<GameObject> SceneClick;

	private void Awake()
	{
		_clickMask = LayerMask.GetMask("Net", "Content");
	}

	private void OnDestroy()
	{
		_gcm = null;
	}

	private void OnEnable()
	{
		foreach (var joystick in GetComponentsInChildren<JoystickController>())
		{
			joystick.JoystickDown += OnJoystickDown;
			joystick.JoystickUp   += OnJoystickUp;
			joystick.JoystickDrag += OnJoystickDrag;
		}
	}

	private void OnDisable()
	{
		foreach (var joystick in GetComponentsInChildren<JoystickController>())
		{
			joystick.JoystickDown -= OnJoystickDown;
			joystick.JoystickUp -= OnJoystickUp;
			joystick.JoystickDrag -= OnJoystickDrag;
		}
	}

	private void Start()
	{
		_gcm = GameObject.FindGameObjectWithTag("GameCanvasManager").GetComponent<GameCanvasManager>();
	}

	private void OnJoystickDrag(Vector2 pos, Vector2 deltaPos)
	{
		_canClick = false;
	}

	private void OnJoystickDown(Vector2 pos)
	{
		_canClick = true;
	}

	private void OnJoystickUp(Vector2 pos)
	{
		_canClick &= Camera.main != null
			    || _gcm.currentGUIPopUpScreen == null
				|| !_gcm.ModalScreen.IsOpen
				|| !InitialTutorial.Instance.InOpenState;

		if (_canClick)
		{
#if !UNITY_EDITOR
			CastClick(Input.GetTouch(0).position);
#else
			CastClick(Input.mousePosition);
#endif
		}

		_canClick = false;
	}



	

	/// <summary>
	/// 
	/// </summary>
	/// <param name="inputPos"></param>
	private void CastClick(Vector2 inputPos)
	{
		Ray ray = Camera.main.ScreenPointToRay(inputPos);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 20.0f, _clickMask))
			OnSceneClick(hit.transform.gameObject);
	}

	private void OnSceneClick(GameObject clickedGo)
	{
		var e = SceneClick;
		if (e != null)
			e(clickedGo);
	}
	
	private GameCanvasManager _gcm;
	private int _clickMask;
	private bool _canClick = false;

}
