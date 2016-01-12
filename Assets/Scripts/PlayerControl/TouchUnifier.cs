using UnityEngine;

public class TouchUnifier : MonoBehaviour {
	
	public enum TouchState {
		StartTouch,
		MoveTouching,
		StopTouch,
		Idle
	}
	
	public TouchState CurrentState { get; set; }
	public Rect AcceptZone { get; set; }
	
	private Vector2 _startPosition = Vector2.zero;
	public Vector2 StartPosition { 
		get { return _startPosition; } 
	}
	
	private Vector2 _currentPosition = Vector2.zero;
	public Vector2 CurrentPosition { 
		get { return _currentPosition; }
	}
	
	private Vector2 _endPosition = Vector2.zero;
	public Vector2 EndPosition { get { return _endPosition; } }
	
	public Vector2 DifferenceFromStart { 
		get { return CurrentPosition - StartPosition; }
	}
	
	private Vector2 _delta = Vector2.zero;
	public Vector2 DeltaDifference { 
		get { return _delta; }
	}
	
	
	private Vector2 _lastMousePos = Vector2.zero;
	
	public TouchUnifier() {
		CurrentState = TouchState.Idle;
	}
	
	void Update() {
        int touchCount = Input.touchCount;

		Debug.Log("\n\n ====================================== ");
		if (touchCount > 0) {
	        for (int i = 0; i < touchCount; i++)
	        {
	            var touch = Input.GetTouch(i);
				switch (touch.phase) {
					case TouchPhase.Began:
						StartTouch(touch.position);
					break;
					case TouchPhase.Moved:
						MovedTouch(touch.position, touch.deltaPosition);
					break;
					case TouchPhase.Ended:
					case TouchPhase.Canceled:
						EndTouch(touch.position, touch.deltaPosition);
					break;
					default:
					break;
				}
				Debug.LogFormat ("Touch {0}", touch);
	        }
		} else {
			Vector2 pos = Input.mousePosition;
			Vector2 deltaPos = _lastMousePos - pos;
			
			if (Input.GetMouseButtonDown(0)) {
				StartTouch(pos);
			}
			if (Input.GetMouseButtonUp(0)) {
				EndTouch(pos, deltaPos);
			}
			MovedTouch(pos, deltaPos);
			
			_lastMousePos = pos;
		}
		Debug.Log("\n\n ====================================== ");
	}
	
	void StartTouch(Vector2 pos) {
		if ((CurrentState == TouchState.StopTouch || CurrentState == TouchState.Idle) &&
			AcceptZone.Contains(pos)) {
			CurrentState = TouchState.StartTouch;
			_currentPosition = pos;
			_startPosition = pos;
		}
	}
	void EndTouch(Vector2 pos, Vector2 delta) {
		if (CurrentState == TouchState.StartTouch || CurrentState == TouchState.MoveTouching) {
			CurrentState = TouchState.StopTouch;
			_currentPosition = pos;
			_endPosition = pos;
		}
	}
	void MovedTouch(Vector2 pos, Vector2 delta) {
		if (CurrentState == TouchState.StartTouch) {
			CurrentState = TouchState.MoveTouching;
		}
		
		if (CurrentState == TouchState.StopTouch) {
			CurrentState = TouchState.Idle;
		}
	}
	
}