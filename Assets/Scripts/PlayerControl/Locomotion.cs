using UnityEngine;
using System.Collections;

public class Locomotion : MonoBehaviour {

	// this is a constant, not set as constant intentionally
	[SerializeField]
	private float ROTATION_TO_BACK_THRESHOLD = 140;
	private float ROTATION_TO_BACK_THRESHOLD_NORMALIZED() { return ROTATION_TO_BACK_THRESHOLD / 180; }
	private float BACK_MOVEMENT_ROTATION_FACTOR = 0.5f;
	private float SECONDARY_ROTATION_FACTOR = 0.4f;
	
	
	public enum MovementStyle {
		Direct,
		CarLike
	}
	
	
	[HideInInspector]
	public MovementStyle movementStyle;

	protected Animator _animator;
	public float DirectionDampTime = .5f;
	
	[HideInInspector]
	public float movement = 0f;
	[HideInInspector]
	public float rotation = 0f;
	
	private Quaternion _initialRotation;
	private Quaternion _lastRotation;

	void Start() {
		_animator = GetComponent<Animator>();
		_initialRotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
	
		if (_animator == null) return;
		if (_animator.layerCount >= 2)
			_animator.SetLayerWeight(1, 1);
	}
		
	void Update() {
		if (!_animator) {
			_animator = GetComponent<Animator>();
		}
		
		if (_animator) {
			switch (movementStyle) {
				case MovementStyle.Direct:
					DirectMovement();
				break;
				case MovementStyle.CarLike:
					CarMovement();
				break;
			}
			
        	//animator.SetFloat("Direction", movement.x, DirectionDampTime, Time.deltaTime);
			
			/*
      		//float h = Input.GetAxis("Horizontal");
        	//float v = Input.GetAxis("Vertical");
			animator.SetFloat("Speed", movement.magnitude);//h*h+v*v);
			
			float forward = movement.y < -0.85? -1 : 1;
			animator.SetFloat("Forward", forward);
			
			float direction = 0;
			if (forward != -1) {
				direction = movement.y >= 0? Mathf.Pow(movement.x, 3) : movement.x/Mathf.Abs(movement.x);
			}
        	animator.SetFloat("Direction", direction, DirectionDampTime, Time.deltaTime);
			//*/
		}
	}

	void LateUpdate() {
		//STABILIZE X AND Z
		//transform.rotation = new Quaternion(_initialRotation.x, transform.rotation.y, _initialRotation.z, transform.rotation.w);
		//_lastRotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
	}
	
	public void StopMoving() {
		movement = 0f;
		rotation = 0f;
	}

	
	void OnCollisionEnter(Collision collision) {
		Debug.Log(collision.collider.name + ":" + name);
	}
	
	private void DirectMovement() {
		_animator.SetFloat("Speed", movement);
		_animator.SetFloat("Forward", 1f);
		//_animator.SetFloat("Direction", 0f);
		
		transform.Rotate(Vector3.up, rotation);
	}
	
	private void CarMovement() {
		_animator.SetFloat("Speed", movement);
		
		//Hacia delante
		if (Mathf.Abs(rotation) < ROTATION_TO_BACK_THRESHOLD) {
			float normalizedRotation = (rotation/ROTATION_TO_BACK_THRESHOLD);
			float normalizedRotation3 = Mathf.Pow(normalizedRotation, 3);

			//transform.rotation = _lastRotation;
			float currentRotX = transform.rotation.x;
			float currentRotZ = transform.rotation.z;
			transform.rotation = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);
			transform.Rotate(Vector3.up, normalizedRotation * 180 * Time.deltaTime);
			transform.rotation = new Quaternion(currentRotX, transform.rotation.y, currentRotZ, transform.rotation.w);
			
			_animator.SetFloat("Forward", 1 - Mathf.Abs(normalizedRotation3) );
		} else { // Hacia detras
		
			float normalizedRotation = Mathf.Sign(rotation) * (180 - Mathf.Abs(rotation)) / (180 - ROTATION_TO_BACK_THRESHOLD); 
			float rotationAmount = normalizedRotation * 180f * BACK_MOVEMENT_ROTATION_FACTOR;	
				
			if (Mathf.Abs(rotationAmount) > 1)
				transform.Rotate(Vector3.up, rotationAmount/2 * Time.deltaTime);
			_animator.SetFloat("Forward", -0.7f);
		}
		
		if (movement != 0) {
			transform.Rotate(Vector3.up, Player.Instance.cameraRotation * Time.deltaTime * SECONDARY_ROTATION_FACTOR);
		}
		
		//_animator.SetFloat("Direction", Mathf.Clamp(rotation/90, -1f, 1f));
		
	}

}
