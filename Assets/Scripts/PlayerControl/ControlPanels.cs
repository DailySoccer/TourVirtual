#if !LITE_VERSION
using UnityEngine;
using System.Collections;

public class ControlPanels : MonoBehaviour {

	private JoystickMovement _joystick;
	private TouchpadRotation _touchpad;
	
	public bool followPlayer = true;

	// Use this for initialization
	void Start () {
		_joystick = transform.GetComponentInChildren<JoystickMovement>();
		_touchpad = transform.GetComponentInChildren<TouchpadRotation>();
		
		
	}
	 
	// Update is called once per frame
	void Update () {
		Transform playerTransf = GetPlayerAvatarTransform();
		if (playerTransf == null) {
			Debug.LogWarning ("Player Avatar Transform is null");
			return;
		}
	}
	
	private Transform GetPlayerAvatarTransform() {
		Transform transf = null;
		Player player = Player.Instance;
		if (player != null) {
			GameObject avatar = player.Avatar;
			if (avatar != null) {
				transf = avatar.transform;
			}
		}
		
		return transf;
	}
}
#endif