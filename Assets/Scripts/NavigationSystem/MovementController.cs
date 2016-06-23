using UnityEngine;

public class MovementController : MonoBehaviour {
	
	public float ROTATE_SPEED = 180f;
	public float PITCH_SPEED = 90;
    public float JOYSTICK_THRESHOLD = 0.3f;
    public float FACING_SPEED = 0.12f;
    public float movementSpeed = 5f;
	private bool isMoving = false;
    private Transform _playerTransform;
			
	[SerializeField]
	private JoystickController movementJoystick;
	[SerializeField]
	private JoystickController rotationJoystick;
	
	public Vector2 movement {
		get { return movementJoystick.joystickValue; }
	}

	public Vector2 rotation {
		get { return rotationJoystick.joystickValue; }
	}

	/**
	 * Joysitck rotation weighted with user's finger speed.
	 */
	public Vector2 rotationWeighted {
		get { return (2f * rotation + rotationJoystick.deltaTouchValue * rotationJoystick.speed) / 3f; }
	}
	
	private Transform PlayerTransform {
		get {
			if (_playerTransform == null || !ReferenceEquals(_playerTransform, null)) {
				GameObject thePlayerObj = Player.Instance.Avatar;
				if (thePlayerObj != null) {
					_playerTransform = thePlayerObj.transform;
				}
			}
			return _playerTransform;
		}
		set {
			_playerTransform = value;
		}
	}
	

	// Use this for initialization
	void Start () {
		GameObject thePlayerObj = Player.Instance.Avatar;
		if (thePlayerObj != null) {
			PlayerTransform = thePlayerObj.transform;
		}
    }

    // Update is called once per frame
    void Update () {
        if (PlayerTransform == null )
        {
            return;
        }
        if (PlayerTransform == null) {//|| PlayerTransform.GetComponent<Locomotion>() == null) {
			return;
		}
        Vector2 rotCamera = Vector2.zero;
        float facing = FACING_SPEED;
        if (_animator == null) _animator = PlayerTransform.GetComponent<Animator>();
        if ((Mathf.Abs(movement.x) >= JOYSTICK_THRESHOLD || Mathf.Abs(movement.y) >= JOYSTICK_THRESHOLD) && Camera.main != null){
            facing = 0.46f;
            rotCamera.x = movement.x * ROTATE_SPEED;
            _animator.SetFloat("Speed", Mathf.Abs(movement.y));
            if (movement.y > 0) _animator.SetFloat("Forward", 1);
            else _animator.SetFloat("Forward", -1);
        }
        else{
            if(_animator!=null) _animator.SetFloat("Speed", 0);
        }

        rotCamera.x += rotation.x * ROTATE_SPEED;
        rotCamera.y = rotation.y * PITCH_SPEED;
        Player.Instance.cameraRotation = rotCamera.x;
        Player.Instance.cameraPitch = rotCamera.y;

        if(Camera.main!=null)
            PlayerTransform.rotation = 
                Quaternion.Slerp(PlayerTransform.rotation, Quaternion.Euler(0, Camera.main.transform.rotation.eulerAngles.y, 0), facing);
    }


    protected Animator _animator;
    private void CommonMovementMethod(Vector2 movement)
    {

        // Threshold por bajos valores.
       

    }
}