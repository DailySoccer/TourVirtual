
using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public const string TAG_UMA_AVATAR = "UMAAvatar";
	
	public bool avatarVisible = true;
	
	public float cameraRotation;
	private float _cameraPitch;
	public float cameraPitch {
		get { return _cameraPitch; } 
		set { _cameraPitch = value; }
	}
#if !LITE_VERSION

	private Locomotion _cacheLocomotion;
	
	[SerializeField]
	private Locomotion.MovementStyle _movementStyle;
	public Locomotion.MovementStyle movementStyle {
		get {
			return _movementStyle;
		}
		set {
			Locomotion.movementStyle = _movementStyle = value;
		}
	}
	
	[SerializeField]
	public FollowAvatar.FollowStyle followStyle;
	[SerializeField]
	public SyncCameraTransform.CameraStyle cameraStyle;
#endif
	static public Player Instance {
		get {
			RefreshPlayer();
			return _player;
		}
	}

	public GameObject Avatar {
		get {
			RefreshAvatar();

			// Si no existe el UMAAvatar devolvemos el gameObject del Player
			return _avatar ?? Instance.gameObject;
		}
		set {
			if (_avatar == null) {
				RefreshAvatar();
			}
			if (_avatar != null) {
				Destroy(_avatar);
			} else {
				Debug.LogWarning("Player avatar is not initialized.");
			}

			_avatar = value;
			_avatar.tag = TAG_UMA_AVATAR;
			_avatar.transform.SetParent(transform);
			_avatar.transform.position = transform.position;
#if !LITE_VERSION
			_cacheLocomotion = null;
			Locomotion.movementStyle = _movementStyle;
#endif
			//_umaAvatar.AddComponent<AudioListener>();
		}
	}
#if !LITE_VERSION

	public Locomotion Locomotion {
		get {
			if (_cacheLocomotion == null) {
				_cacheLocomotion = Avatar.GetComponent<Locomotion>();
			}
			return _cacheLocomotion;
		}
	}
#endif
	void Start() {
		RefreshPlayer();
		RefreshAvatar();

		// Por defecto, mantenemos al player desactivado
		if (_player != null) {
			_player.gameObject.SetActive(false);
		}
#if !LITE_VERSION

		if (_avatar != null) {
			Locomotion.movementStyle = movementStyle;
		}
#endif
	}

	private static void RefreshPlayer() {
		GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
		if (playerObj != null) {
			_player = playerObj.GetComponent<Player>();
		}
	}
	
	private void RefreshAvatar() {
		GameObject avatarObj = GameObject.FindGameObjectWithTag(TAG_UMA_AVATAR);
		if (avatarObj != null) {
			_avatar = avatarObj;
			_avatar.GetComponentInChildren<Renderer>().enabled = avatarVisible;
		}
	}
	
	private static Player _player;
	private GameObject _avatar;
}
