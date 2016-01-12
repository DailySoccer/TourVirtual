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
		if (PlayerTransform == null || PlayerTransform.GetComponent<Locomotion>() == null) {
			return;
		}
        Vector2 rotCamera = Vector2.zero;
        float facing = FACING_SPEED;

        if ((Mathf.Abs(movement.x) >= JOYSTICK_THRESHOLD || Mathf.Abs(movement.y) >= JOYSTICK_THRESHOLD) && Camera.main != null)
        {
            facing = 0.46f;
            rotCamera.x = movement.x * ROTATE_SPEED;
            if (_animator == null)
                _animator = PlayerTransform.GetComponent<Animator>();

            _animator.SetFloat("Speed", Mathf.Abs(movement.y));

            if (movement.y > 0) _animator.SetFloat("Forward", 1);
            else _animator.SetFloat("Forward", -1);
        }

        rotCamera.x += rotation.x * ROTATE_SPEED;
        rotCamera.y = rotation.y * PITCH_SPEED;
        Player.Instance.cameraRotation = rotCamera.x;
        Player.Instance.cameraPitch = rotCamera.y;

        PlayerTransform.rotation = 
            Quaternion.Slerp(PlayerTransform.rotation, Quaternion.Euler(0, Camera.main.transform.rotation.eulerAngles.y, 0), facing);
    }


    protected Animator _animator;
    private void CommonMovementMethod(Vector2 movement)
    {

        // Threshold por bajos valores.
       

    }
    /*

    private void CommonMovementMethod(Vector2 movement) {
		
        // Threshold por bajos valores.
		if ((Mathf.Abs(movement.x) < JOYSTICK_THRESHOLD && Mathf.Abs(movement.y) < JOYSTICK_THRESHOLD) || Camera.main == null) {
			PlayerTransform.GetComponent<Locomotion>().StopMoving();
			return;
		}

		Transform camTransf = Camera.main.transform;
		
		Vector2 camForward2d = new Vector2(camTransf.forward.x, camTransf.forward.z).normalized;
		Vector2 camRight2d = new Vector2(camTransf.right.x, camTransf.right.z).normalized;
		
		Vector2 playerForward2d = new Vector2(PlayerTransform.forward.x, PlayerTransform.forward.z).normalized;
		Vector2 playerRight2d = new Vector2(PlayerTransform.right.x, PlayerTransform.right.z).normalized;
		
		
		Vector3 movementCameraTransf = camTransf.TransformDirection(new Vector3(movement.x, 1f, movement.y));
		Vector2 movement2d = new Vector2(movementCameraTransf.x, movementCameraTransf.z).normalized;
		
		// -1 Movimiento a la izquierda de la camara. 1 a la derecha de la camara. 0 hacia delante o hacia atras de la camara
		float relMovCam     = Vector2.Dot(movement2d, camRight2d);
		// -1 Avatar de lado izquierdo, 1 de lado derecho. 0 mirando al frente o a la camara
		float relPlayerCam  = Vector2.Dot(playerForward2d, camRight2d);
		// -1 Movimiento del Avatar hacia la izquierda, 1 hacia la derecha. 0 en la direccion en la que está o en la contraria.
		float relPlayerMov  = Vector2.Dot(movement2d, playerRight2d);
		// positivo hacia delante, negativo hacia atras
		float relForwardPlayerMov  = Vector2.Dot(movement2d, playerForward2d);
		
		//float appliedRotation = 0f;
		
		
		//float sugestedRotation = relPlayerMov + relForwardPlayerMov ;
		//float initialRotation = 0f;
		const float TO_DEGREE = 180/Mathf.PI;
		float appliedRotation = Mathf.Atan2(relPlayerMov, relForwardPlayerMov) * TO_DEGREE;
		
		if (relForwardPlayerMov > 0f) initialRotation = 90f * anglePlayerMov;
		else initialRotation = 90f + 90f * (Mathf.Sign(relPlayerMov) *  - relPlayerMov);
		
		appliedRotation *= Mathf.Clamp((isMoving? Time.deltaTime * 5 : 1f), 0f, 1f);
		
		//Debug.Log("AppliedRotation: " + appliedRotation + "  Rel PM: " + relPlayerMov + " Rel Forward: " + relForwardPlayerMov);
		//Debug.Log("Angle" + angleForwardPlayerMov);
		
		//PlayerTransform.Rotate(Vector3.up, appliedRotation);
		
		
		//isMoving = true;
		//movement.magnitude
		PlayerTransform.GetComponent<Locomotion>().movement = movement.magnitude;
    	PlayerTransform.GetComponent<Locomotion>().rotation = appliedRotation;
    }	
    */
}
