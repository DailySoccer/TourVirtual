using UnityEngine;


[RequireComponent(typeof(Player))]
public class MovementController : MonoBehaviour
{
	/**
	 * Joysitck Rotation weighted with user's finger speed.
	 */
	//public Vector2 RotationWeighted {
	//	get { return (2f * Rotation + _rotationJoystick.DeltaTouchValue * _rotationJoystick.speed) / 3f; }
	//}

	

	private void Awake()
	{
		if(_player == null)
			_player = GetComponent<Player>();

		if (_camera == null)
			_camera = Camera.main;

		//Assert.IsNotNull(_player	, "MovementController::Awake>> Player Null!!");
		//Assert.IsNotNull(_animator	, "MovementController::Awake>> Animator Null!!");
		//Assert.IsNotNull(_movementTouch, "MovementController::Awake>> Movement joystick Null!!");
		//Assert.IsNotNull(_rotationTouch, "MovementController::Awake>> Rotation joystick Null!!");

		_player.AvatarChange += OnAvatarChange;
		enabled = false;
	}

	private void OnDestroy()
	{
		_player.AvatarChange -= OnAvatarChange;

		_camera = null;
		_player = null;
		_animator = null;
		_movementTouch = null;
		_rotationTouch = null;
		_avatar = null;
	}
	
	// Use this for initialization
	private void Start ()
	{
	}
	
    // Update is called once per frame
    private void Update ()
    {
	    if (_avatar == null)
		    return;

	    _player.CameraRotationSpeed = 0f;
		_player.CameraPitchSpeed = 0f;

		float currentfacingSpeed = _facingSpeed;
		if (!MainManager.Instance.IsVrModeEnabled) _movement = _movementTouch.Value;
		else _movement = Vector2.zero;

	    _movement.x += Input.GetAxis(_movementHorizontalAxis);
		_movement.y += Input.GetAxis(_movementVerticalAxis);
	    _movement.x = Mathf.Clamp(_movement.x, -1f, 1f);
		_movement.y = Mathf.Clamp(_movement.y, -1f, 1f);

		_rotation = _rotationTouch.Value;
		_rotation.x += Input.GetAxis(_rotationHorizontalAxis);
		_rotation.y += Input.GetAxis(_rotationVerticalAxis);
		_rotation.x = Mathf.Clamp(_rotation.x, -1f, 1f);
		_rotation.y = Mathf.Clamp(_rotation.y, -1f, 1f);

		if (!MainManager.Instance.IsVrModeEnabled && Camera.main != null && 
			(Mathf.Abs(_movement.x) >= _joystickThreshold 
		  || Mathf.Abs(_movement.y) >= _joystickThreshold) ) {
            currentfacingSpeed = 0.46f;
            _animator.SetFloat("Speed", Mathf.Abs(_movement.y));

            if (_movement.y > 0) _animator.SetFloat("Forward", 1);
            else _animator.SetFloat("Forward", -1);
        }
        else
		{
			_animator.SetFloat("Speed", 0);
        }
		
		if (!MainManager.Instance.IsVrModeEnabled)
		{
			_player.CameraRotationSpeed = (_movement.x + _rotation.x) * _yawSpeedMax;
			_player.CameraPitchSpeed    = _rotation.y * _pitchSpeedMax;

			_avatar.rotation =
			    Quaternion.Slerp(_avatar.rotation,
				    Quaternion.Euler(0f, _camera.transform.rotation.eulerAngles.y, 0f), currentfacingSpeed);
	    }
    }

	/// <summary>
	/// 
	/// </summary>
	private void FixedUpdate() {
		if (!MainManager.Instance.IsVrModeEnabled)
			return;

		Vector3 forwardHead = _camera.transform.forward;
		forwardHead.y = 0f;
		forwardHead.Normalize();

		Vector3 rightHead = _camera.transform.right;
		rightHead.y = 0f;
		rightHead.Normalize();

		Vector3 nextPos = _avatar.position + Time.fixedDeltaTime * _movementSpeed * (_movement.x * rightHead + _movement.y * forwardHead);

		_avatar.GetComponent<Rigidbody>().MovePosition(nextPos);
	}



	/// <summary>
	/// 
	/// </summary>
	/// <param name="avatar"></param>
	private void OnAvatarChange(GameObject avatar)
	{
		if (avatar != null)
		{
			_avatar = avatar.transform;
			_animator = _avatar.GetComponent<Animator>();
			enabled = true;
		}
		else
		{
			enabled = false;
			_avatar = null;
			_animator = null;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="movement"></param>
	private void CommonMovementMethod(Vector2 movement)
    {
		// Threshold por bajos valores.
	}


	private Animator _animator;
	private Transform _avatar;

	[SerializeField]
	private Player _player;
	[SerializeField]
	private Camera _camera;
	[SerializeField]
	private JoystickController _movementTouch;
	[SerializeField]
	private JoystickController _rotationTouch;

	[SerializeField]
	private float _yawSpeedMax = 180f;
	[SerializeField]
	private float _pitchSpeedMax = 90;
	[SerializeField]
	private float _joystickThreshold = 0.3f;
	[SerializeField]
	private float _facingSpeed = 0.12f;
	[SerializeField]
	private float _movementSpeed = 5f;
	private bool _isMoving = false;
	private Vector2 _movement;
	private Vector2 _rotation;

	[SerializeField] private string _movementHorizontalAxis;
	[SerializeField] private string _movementVerticalAxis;
	[SerializeField] private string _rotationHorizontalAxis;
	[SerializeField] private string _rotationVerticalAxis;
}