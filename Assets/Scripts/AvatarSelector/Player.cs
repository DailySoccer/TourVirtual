using System;
using UnityEngine;

public class Player : MonoBehaviour
{
	public const string TagUmaAvatar = "UMAAvatar";

	public event Action<GameObject> AvatarChange;
	public bool AvatarVisible = true;
	public float CameraRotationSpeed;
	public float CameraPitchSpeed { get; set; }

	public FollowAvatar.FollowStyle FollowStyle;
	
	public CameraAnchor.Type CameraType 
	{
		get { return _cameraType; }
		set {
			AvatarVisible = value != CameraAnchor.Type.VirtualReality;
			_cameraType = value;
		}
	} 



	public static Player Instance
	{
		get
		{
			RefreshPlayer();
			return _player;
		}
	}

	public void SetAvatar(GameObject value)
	{
		if (_avatar == null) 
			RefreshAvatar();
		
		value.tag = TagUmaAvatar;
		value.transform.SetParent(transform);
		value.transform.position = transform.position;

		Avatar = value;
	}

	public GameObject Avatar
	{
		get
		{
			RefreshAvatar(); // FRS No sé por qué está esto así, pero es un sobrecoste.
			return _avatar ?? gameObject;
		}
		private set
		{
			if (value != _avatar)
			{
				if (_avatar != null)
					Destroy(_avatar);

				_avatar = value;
				OnAvatarChange(_avatar);
			}
		}
	}


	private void Start()
	{
		RefreshPlayer();
		RefreshAvatar();

		// Por defecto, mantenemos al player desactivado
		if (_player != null)
			_player.gameObject.SetActive(false);
	}

	private static void RefreshPlayer()
	{
		GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
		if (playerObj != null) 
			_player = playerObj.GetComponent<Player>();
	}
	
	private void RefreshAvatar()
	{
		if(gameObject.activeSelf)
			Avatar = GameObject.FindWithTag(TagUmaAvatar);
	}



	private void OnAvatarChange(GameObject avatar)
	{
		if (avatar != null)
		{
			foreach(Renderer r in avatar.GetComponentsInChildren<Renderer>(true) )
				r.enabled = AvatarVisible;
		}
	
		var e = AvatarChange;
		if (e != null)
			e(avatar);
	}


	[SerializeField] private CameraAnchor.Type _cameraType;
	private static Player _player;
	private GameObject _avatar;
}
