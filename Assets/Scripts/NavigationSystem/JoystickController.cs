#if !LITE_VERSION
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

    private int? _currentTouchId = null;
	private Vector2 _touchStartPoint = Vector2.zero;
	private Vector2 _touchCurrentPoint = Vector2.zero;
	private Vector2 _deltaTouch = Vector2.zero;
	private float _joystickBaseHalfWidth;
	
	private EventTrigger _eventTriggerCache;
	
	/*
	[SerializeField]
	private UnityEngine.UI.Image debugImage;
	[SerializeField]
	private Color color;
	[SerializeField]
	private UnityEngine.UI.Text debugText;
	*/
	
#region "Getters / Communication interface"
	
	public Vector2 joystickValue {
		get {
            Vector2 val = (_touchCurrentPoint - _touchStartPoint) / _joystickBaseHalfWidth;
            val.x += Input.GetAxis(_axisHorizontalName);
            val.y += Input.GetAxis(_axisVerticalName);

            return val.magnitude > 1? val.normalized : val;
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
		_joystickBaseHalfWidth = _joystickBase.GetComponent<RectTransform>().rect.width / 2;
		
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
	
	
	
	// Update is called once per frame
	void Update () {
		//debugText.text = string.Format(" ID: {0} ", _currentTouchId);
		
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
		_touchCurrentPoint = _touchStartPoint = ev.pressPosition;
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
#endif