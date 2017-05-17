using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(EventTrigger))]
public class JoystickController : MonoBehaviour {
	
	delegate void ControlTouchEventHandler(BaseEventData data);

	public event Action<Vector2> JoystickDown;
	public event Action<Vector2> JoystickUp;
	public event Action<Vector2, Vector2> JoystickDrag;

	[SerializeField]
	private bool _showJoystick = true;
	[SerializeField]
	private bool _showAlways = false;
	[SerializeField]
	private Transform _joystickBase;
	[SerializeField]
	private Transform _joystickStick;
	[SerializeField, Range(0, 0.999f)]
	private float _deadZone = 0.01f;

    private int? _currentTouchId = null;
	private Vector2 _touchStartPoint = Vector2.zero;
	private Vector2 _touchCurrentPoint = Vector2.zero;
	private Vector2 _deltaTouch = Vector2.zero;
	private float _joystickBaseHalfWidth;

   private float _deadRad;
   private float _actionRad;
	
	private EventTrigger _eventTriggerCache;

	private static float DPI = 1;
	
	/*
	[SerializeField]
	private UnityEngine.UI.Image debugImage;
	[SerializeField]
	private Color color;
	[SerializeField]
	private UnityEngine.UI.Text debugText;
	*/
	
#region Getters / Communication interface
	
	public Vector2 Value
	{
		get
		{
			if (!isActiveAndEnabled)
				return Vector2.zero;

			Vector2 val = (_touchCurrentPoint - _touchStartPoint) * DPI / _actionRad;
			val.x = Mathf.Abs(val.x) < _deadRad ? 0f :
				Mathf.Clamp(val.x, -1f, 1f);
			val.y = Mathf.Abs(val.y) < _deadRad ? 0f :
				Mathf.Clamp(val.y, -1f, 1f);

			return val;
		}
	}
	
	// UNDONE FRS 160817
	//public Vector2 DeltaTouchValue {
	//	get {
 //           Vector2 val = _deltaTouch;
 //               val.x += Input.GetAxis(_axisHorizontalName);
 //               val.y += Input.GetAxis(_axisVerticalName);
 //           return val; }
	//}
	
	public float speed {
		get { return _deltaTouch.magnitude/Time.deltaTime; }
	}
	
#endregion

	private void Awake()
	{
		DPI = Mathf.Approximately(Screen.dpi, 0f) ? 1f : 1f / Screen.dpi;
		_joystickBaseHalfWidth = _joystickBase.GetComponent<RectTransform>().rect.width;
		UpdateJoystickParams();
	}

	private void Start ()
	{
		_eventTriggerCache = GetComponent<EventTrigger>();
		
		AddEventListener(EventTriggerType.PointerDown, OnPointerDownHandler);
		AddEventListener(EventTriggerType.PointerUp, OnPointerUpHandler);
		AddEventListener(EventTriggerType.Drag, OnPointerDragHandler);

		ControlVisible(false);
	}

	private void OnDestroy()
	{
		JoystickDown = null;
		JoystickUp   = null;
		JoystickDrag = null;
	}

	
	private void AddEventListener(EventTriggerType type, ControlTouchEventHandler func) {
		
		UnityAction<BaseEventData> callback = new UnityAction<BaseEventData>(func);

		var entry = new EventTrigger.Entry
		{
			eventID = type,
			callback = new EventTrigger.TriggerEvent()
		};

		entry.callback.AddListener(callback);
		
		_eventTriggerCache.triggers.Add(entry);
	}

   private void UpdateJoystickParams()
   {
      _deadRad   = (_deadZone * _joystickBaseHalfWidth) * DPI;
      _actionRad = (_joystickBaseHalfWidth - _deadRad) * DPI;
   }

   // Update is called once per frame
   void Update ()
	{
		//debugText.text = string.Format(" ID: {0} ", _currentTouchId);

#if UNITY_EDITOR
		UpdateJoystickParams();
#endif

		if(_currentTouchId.HasValue) {
			//debugImage.color = new Color(color.r, color.g, color.b, 0.5f);
			
			_joystickBase.transform.position = _touchStartPoint;
			_joystickStick.transform.position = _touchStartPoint + Value * _joystickBaseHalfWidth;
		} /*else {
			debugImage.color = new Color(color.r, color.g, color.b, 0.2f);
		}*/
	}
	
	
	private void OnPointerDownHandler(UnityEngine.EventSystems.BaseEventData eventData)
	{
		UnityEngine.EventSystems.PointerEventData ev = (UnityEngine.EventSystems.PointerEventData) eventData;
		_touchCurrentPoint = _touchStartPoint = ev.pressPosition ;
		_deltaTouch = Vector2.zero;
		_currentTouchId = ev.pointerId;
		ControlVisible(false);

		var e =JoystickDown;
		if (e != null)
			e(ev.position);
	}
	
	private void OnPointerUpHandler(UnityEngine.EventSystems.BaseEventData eventData)
	{
		UnityEngine.EventSystems.PointerEventData ev = (UnityEngine.EventSystems.PointerEventData) eventData;
		if (ev.pointerId != _currentTouchId)
			return;

		ResetTouchInfo();
		ControlVisible(false);

		var e = JoystickUp;
		if (e != null)
			e(ev.position);
	}
	
	private void OnPointerDragHandler(UnityEngine.EventSystems.BaseEventData eventData)
	{
		UnityEngine.EventSystems.PointerEventData ev = (UnityEngine.EventSystems.PointerEventData) eventData;
		if (ev.pointerId != _currentTouchId)
			return;

		ControlVisible(true);
		_deltaTouch = (ev.position - _touchCurrentPoint) / _joystickBaseHalfWidth;
		_touchCurrentPoint = ev.position;

		var e = JoystickDrag;
		if (e != null)
			e(ev.position, _deltaTouch);
	}
	
	private void ControlVisible(bool visible) {
		
		bool isVisible = _showAlways || (_showJoystick && visible);
		
		_joystickBase.GetComponent<Image>().enabled = isVisible;
		_joystickStick.GetComponent<Image>().enabled = isVisible;

		if (visible) return;
		_joystickBase.GetComponent<RectTransform>().position = Vector2.zero;
		_joystickStick.GetComponent<RectTransform>().position = Vector2.zero;
	}
		
	private void ResetTouchInfo()
	{
		_currentTouchId = null;
		_touchStartPoint = Vector2.zero;
		_deltaTouch = Vector2.zero;
		_touchCurrentPoint = Vector2.zero;
	}
	
}