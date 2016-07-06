using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(EventTrigger))]
public class JoystickController : MonoBehaviour {
	
	delegate void ControlTouchEventHandler(BaseEventData data);
	
	[SerializeField]
	private bool _showJoystick = true;
	[SerializeField]
	private bool _showAlways = false;
	[SerializeField]
	private Transform _joystickBase;
	[SerializeField]
	private Transform _joystickStick;
    [SerializeField]
    public string _axisHorizontalName;
    [SerializeField]
    public string _axisVerticalName;
   [SerializeField]
   [Range(0, 0.999f)]
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
	
	public Vector2 joystickValue {
		get
      {
         Vector2 val = (_touchCurrentPoint - _touchStartPoint) * DPI;
         val.x += Input.GetAxis(_axisHorizontalName);
         val.y += Input.GetAxis(_axisVerticalName);
         val.x = Mathf.Clamp01((Mathf.Abs(val.x) - _deadRad) / _actionRad) * Mathf.Sign(val.x);
         val.y = Mathf.Clamp01((Mathf.Abs(val.y) - _deadRad) / _actionRad) * Mathf.Sign(val.y);

         return val;
      }
	}
	
	public Vector2 deltaTouchValue {
		get {
            Vector2 val = _deltaTouch;
                val.x += Input.GetAxis(_axisHorizontalName);
                val.y += Input.GetAxis(_axisVerticalName);
            return val; }
	}
	
	public float speed {
		get { return _deltaTouch.magnitude/Time.deltaTime; }
	}
	
#endregion

	// Use this for initialization
	void Start () {
		_eventTriggerCache = GetComponent<EventTrigger>();
		
		AddEventListener(EventTriggerType.PointerDown, OnPointerDownHandler);
		AddEventListener(EventTriggerType.PointerUp, OnPointerUpHandler);
		AddEventListener(EventTriggerType.Drag, OnPointerDragHandler);
		_joystickBaseHalfWidth = _joystickBase.GetComponent<RectTransform>().rect.width;

		DPI = Screen.dpi != 0 ? 1 / Screen.dpi : 1;
      	UpdateJoystickParams();

		ControlVisible(false);
	}
	
	private void AddEventListener(EventTriggerType type, ControlTouchEventHandler func) {
		
		UnityAction<BaseEventData> callback = new UnityAction<BaseEventData>(func);
		
		EventTrigger.Entry entry = new EventTrigger.Entry();
		
		entry.eventID = type;
		entry.callback = new EventTrigger.TriggerEvent();
		entry.callback.AddListener(callback);
		
		_eventTriggerCache.triggers.Add(entry);
	}

   private void UpdateJoystickParams()
   {
      _deadRad = _deadZone * _joystickBaseHalfWidth;
      _actionRad = _joystickBaseHalfWidth - _deadRad;
	  _deadRad *= DPI;
	  _actionRad *= DPI;
   }

   // Update is called once per frame
   void Update () {
      //debugText.text = string.Format(" ID: {0} ", _currentTouchId);

      UpdateJoystickParams();

		if(_currentTouchId.HasValue) {
			//debugImage.color = new Color(color.r, color.g, color.b, 0.5f);
			
			_joystickBase.transform.position = _touchStartPoint;
			_joystickStick.transform.position = _touchStartPoint + joystickValue * _joystickBaseHalfWidth;
		} /*else {
			debugImage.color = new Color(color.r, color.g, color.b, 0.2f);
		}*/
	}
	
	
	private void OnPointerDownHandler(UnityEngine.EventSystems.BaseEventData eventData) {
		UnityEngine.EventSystems.PointerEventData ev = (UnityEngine.EventSystems.PointerEventData) eventData;
		_touchCurrentPoint = _touchStartPoint = ev.pressPosition ;
		_deltaTouch = Vector2.zero;
		_currentTouchId = ev.pointerId;
		ControlVisible(false);
	}
	
	private void OnPointerUpHandler(UnityEngine.EventSystems.BaseEventData eventData) {
		UnityEngine.EventSystems.PointerEventData ev = (UnityEngine.EventSystems.PointerEventData) eventData;
		if (ev.pointerId == _currentTouchId) {
			ResetTouchInfo();
			ControlVisible(false);
		}
		
	}
	
	private void OnPointerDragHandler(UnityEngine.EventSystems.BaseEventData eventData) {
		UnityEngine.EventSystems.PointerEventData ev = (UnityEngine.EventSystems.PointerEventData) eventData;
		if (ev.pointerId == _currentTouchId) {
			ControlVisible(true);
			_deltaTouch = (ev.position - _touchCurrentPoint) / _joystickBaseHalfWidth;
			_touchCurrentPoint = ev.position;
		}
	}
	
	private void ControlVisible(bool visible) {
		
		bool isVisible = _showAlways || (_showJoystick && visible);
		
		_joystickBase.GetComponent<Image>().enabled = isVisible;
		_joystickStick.GetComponent<Image>().enabled = isVisible;
		
		if(!visible) {
			_joystickBase.GetComponent<RectTransform>().position = Vector2.zero;
			_joystickStick.GetComponent<RectTransform>().position = Vector2.zero;
		}
	}
		
	private void ResetTouchInfo() {
		_currentTouchId = null;
		_touchStartPoint = Vector2.zero;
		_deltaTouch = Vector2.zero;
		_touchCurrentPoint = Vector2.zero;
	}
	
}