
using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

	public const string TAG_UMA_AVATAR = "UMAAvatar";

	public bool avatarVisible = true;

	public float cameraRotation;
	private float _cameraPitch;

	public float cameraPitch
	{
		get { return _cameraPitch; }
		set { _cameraPitch = value; }
	}

	[SerializeField] public FollowAvatar.FollowStyle followStyle;
	[SerializeField] private CameraAnchor.Type _cameraType;
	public CameraAnchor.Type CameraType {
		get { return _cameraType; }
	} 



	static public Player Instance {
		get {
			RefreshPlayer();
			return _player;
		}
	}

	public GameObject Avatar {
		get {
			RefreshAvatar();

			return _avatar ?? Instance.gameObject;
		}
		set {
			if (_avatar == null) 
				RefreshAvatar();

			if (_avatar != null)
				Destroy(_avatar);

			_avatar = value;
			_avatar.tag = TAG_UMA_AVATAR;
			_avatar.transform.SetParent(transform);
			_avatar.transform.position = transform.position;
			//_umaAvatar.AddComponent<AudioListener>();
		}
	}

	void Start() {
		RefreshPlayer();
		RefreshAvatar();

		// Por defecto, mantenemos al player desactivado
		if (_player != null) {
			_player.gameObject.SetActive(false);
		}
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
