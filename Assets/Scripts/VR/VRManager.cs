using UnityEngine;
using System.Collections;

public class VRManager : MonoBehaviour {

	/// <summary>
	/// Singleton reference.
	/// </summary>
	public static VRManager Instance
	{
		get
		{
			return _instance;
		}
		private set { }
	}

	/// <summary>
	/// Is VR mode on?
	/// </summary>
	public static bool VRModeON
	{
		get { return _instance != null && _instance.gameObject.activeSelf; }
	}

	/// <summary>
	/// Set VR mode.
	/// </summary>
	/// <param name="on">True to activate VR mode, false to deactivate it.</param>
	/// <returns></returns>
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
}
