using UnityEngine;


public class SceneClicker : MonoBehaviour
{

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

	private void OnJoystickDrag(Vector2 arg1, Vector2 arg2)
	{
		_canClick = false;
	}

	private void OnJoystickDown(Vector2 obj)
	{
		_canClick = true;
	}

	private void OnJoystickUp(Vector2 obj)
	{
		_canClick &= _gcm.currentGUIPopUpScreen == null
				|| !_gcm.ModalScreen.IsOpen
				|| !InitialTutorial.Instance.InOpenState;

		if(_canClick)
			OnSceneClick();

		_canClick = false;
	}


	// TODO Hud y GCM deberían suscribirse a este evento y coger el hit.transform.gameObject bajo demanda.
	public void OnSceneClick()
	{
		print("SceneClicker::OnSceneClick");

		if (Camera.main == null)
			return;

#if !UNITY_EDITOR
		CastClick(touch.position);
		
#else
		CastClick(Input.mousePosition);
#endif
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
		{
			if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Content"))
			{
				_gcm.OnContentClick(hit.transform.GetComponent<ContentList>());
			}
			else
			{
				RemotePlayerHUD hud = hit.collider.gameObject.GetComponentInChildren<RemotePlayerHUD>();
				//if (hit.collider.gameObject.name.Contains("base"))
				if (hud != null)
					hud.RemotePlayerHUD_ClickHandle();
			}
		}
	}


	
	private GameCanvasManager _gcm;
	private int _clickMask;
	private bool _canClick = false;

}
