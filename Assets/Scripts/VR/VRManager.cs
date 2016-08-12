using UnityEngine;
using System.Collections;

public class VRManager : MonoBehaviour {

	public static VRManager Instance
	{
		get
		{
			return _instance;
		}
		private set { }
	}

	public static bool VRModeON
	{
		get { return _instance != null && _instance.gameObject.activeSelf; }
	}

	public static bool SetVR(bool on)
	{
		if (_instance != null)
		{
			_instance.gameObject.SetActive(on);
		}
		return _instance != null && on;
	}

	private static VRManager _instance;
	// Use this for initialization
	void Awake () {
		if (_instance == null)
		{
			_instance = this;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
