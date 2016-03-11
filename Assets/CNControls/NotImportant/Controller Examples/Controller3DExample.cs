﻿#if !LITE_VERSION
using System;
using UnityEngine;
using System.Collections;

public class Controller3DExample : MonoBehaviour
{
    public const float ROTATE_SPEED = 180f;
	private const float JOYSTICK_THRESHOLD = 0.3f;

    public float movementSpeed = 5f;

    public CNAbstractController RotateJoystick;
    public CNAbstractController MovementJoystick;
    private Transform _playerTransform;
	
	//public Transform _playerFollower;
	
	//private bool justTurnedAround = false;
	[SerializeField]
	private bool isMoving = false;

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

    void Start()
    {
        // You can also move the character with an event system
        // You MUST CHOOSE one method and use ONLY ONE a frame
        // If you wan't the event based control, uncomment this line
        // MovementJoystick.JoystickMovedEvent += MoveWithEvent;
		GameObject thePlayerObj = Player.Instance.Avatar;
		if (thePlayerObj != null) {
			PlayerTransform = thePlayerObj.transform;
		}
    }

    
    // Update is called once per frame
    void Update()
    {
		if (PlayerTransform == null || PlayerTransform.GetComponent<Locomotion>() == null) {
			return;
		}

        var movement = new Vector2(
            MovementJoystick.GetAxis("Horizontal"),
            MovementJoystick.GetAxis("Vertical"));

        CommonMovementMethod(movement);
        
        var rotation = new Vector2(
            RotateJoystick.GetAxis("Horizontal"),
            0.0f);
            
        CommonRotationMethod(rotation);
    }
    
    private void CommonRotationMethod(Vector2 rotation)
	{
		/*var euler = PlayerTransform.eulerAngles;
		PlayerTransform.eulerAngles = new Vector3(euler.x, euler.y + rotation.x * ROTATE_SPEED * Time.deltaTime, euler.z);
		*/
		/*Vector3 euler = Player.Instance.cameraRotation.eulerAngles;
		Player.Instance.cameraRotation.eulerAngles = new Vector3(euler.x, euler.y + rotation.x * ROTATE_SPEED * Time.deltaTime, euler.z);
		*/
		Player.Instance.cameraRotation = rotation.x * ROTATE_SPEED;
	
	}
	
    /*
    private void CommonMovementMethod(Vector2 movement)
	{	
		if (justTurnedAround && movement.y > 0f) {
			justTurnedAround = false;
		}
		
		if (_playerFollower == null) {
			var cameraPivot = GameObject.FindGameObjectWithTag("CameraPivot");
			if (cameraPivot != null) {
				_playerFollower = cameraPivot.GetComponent<Transform>();
			}
			if (_playerFollower == null) {
				return;
			}
		}
		
		if (Mathf.Abs(movement.x) < 0.01 && Mathf.Abs(movement.y) < 0.01) {
			PlayerTransform.GetComponent<Locomotion>().movement = movement;
			justTurnedAround = false;
			isMoving = false;
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
		
		
		float appliedRotation = 0f;
		if (relForwardPlayerMov < -0.8f && !justTurnedAround) {
			appliedRotation = 180f;
			//PlayerTransform.Rotate(Vector3.up, 180f);
			justTurnedAround = true;
		} else if (Mathf.Abs(relForwardPlayerMov) < 0.9f) {
			//if (!isMoving) {
			//	float initialRotation = 0f;
			//	if (relForwardPlayerMov > 0f) {
			//		initialRotation = 90f * relPlayerMov;
			//	} else {
			//		initialRotation = 90f + 90f * (Mathf.Sign(relPlayerMov) - relPlayerMov);
			//	}
			//	Debug.Log("INITIAL ROTATION: " + initialRotation);
			//	PlayerTransform.Rotate(Vector3.up, initialRotation);
			//}
			
			//direction = Mathf.Clamp(relPlayerMov * 2f, -1f, 1f);
			//float initialRotation = 0f;
			//if (Mathf.Abs(relPlayerMov) > 0.8) {
			//	initialRotation = 180f * Mathf.Sign(relPlayerMov) * Time.deltaTime * 0.1f;
			//}
			appliedRotation = 180f * Time.deltaTime * Mathf.Clamp(relPlayerMov * 2f, -1f, 1f);
			//PlayerTransform.Rotate(Vector3.up, initialRotation);
		}
		
			PlayerTransform.Rotate(Vector3.up, appliedRotation);
		isMoving = true;
		
    	PlayerTransform.GetComponent<Locomotion>().movement = new Vector2(0, 1f);
    }
*/

    private void CommonMovementMethod(Vector2 movement)
	{	
		/*
		if (justTurnedAround && movement.y > 0f) {
			justTurnedAround = false;
		}
		*/
		/*
		if (_playerFollower == null) {
			var cameraPivot = GameObject.FindGameObjectWithTag("CameraPivot");
			if (cameraPivot != null) {
				_playerFollower = cameraPivot.GetComponent<Transform>();
			}
			if (_playerFollower == null) {
				return;
			}
		}
		*/
		
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
		
		/*
		if (relForwardPlayerMov > 0f) {
			initialRotation = 90f * anglePlayerMov;
		} else {
			initialRotation = 90f + 90f * (Mathf.Sign(relPlayerMov) *  - relPlayerMov);
		}
		*/
		
		
		
		appliedRotation *= Mathf.Clamp((isMoving? Time.deltaTime * 5 : 1f), 0f, 1f);
		
		//Debug.Log("AppliedRotation: " + appliedRotation + "  Rel PM: " + relPlayerMov + " Rel Forward: " + relForwardPlayerMov);
		//Debug.Log("Angle" + angleForwardPlayerMov);
		
		//PlayerTransform.Rotate(Vector3.up, appliedRotation);
		
		
		//isMoving = true;
		//movement.magnitude
    	PlayerTransform.GetComponent<Locomotion>().movement = 1f;
    	PlayerTransform.GetComponent<Locomotion>().rotation = appliedRotation;
    }


}

#endif