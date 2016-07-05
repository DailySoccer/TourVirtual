using UnityEngine;

public class CameraAnchor : MonoBehaviour
{
	public enum Type
	{
		None		= 0,
		FirstPerson = 1,
		ThirdPerson = 2,
	}

	public static float PitchDegreesMin;
	public static float PitchDegreesMax;

	[SerializeField]
	private Type _anchorType;
	public Type AnchorType { get { return _anchorType; } }


	public float Radius { get; private set; }
	public float Distance { get; private set; }
	public Vector3 Target
	{
		get { return transform.position + Distance * transform.forward; }
	}

	private float _pitchDegrees;
	public float PitchDegrees
	{
		get { return _pitchDegrees; }
		set
		{
			value = Mathf.Clamp(value, PitchDegreesMin, PitchDegreesMax);
			if (Mathf.Approximately(value, _pitchDegrees))
				return;

			_pitchDegrees = value;

			transform.localRotation = Quaternion.AngleAxis(value, -Vector3.right);
			Distance = Radius / Mathf.Cos(Mathf.Deg2Rad * value);
		}
	}

	public void Awake()
	{
		Vector3 horizontalPos = transform.localPosition;
		horizontalPos.y = 0f;

		Radius = horizontalPos.magnitude;
		PitchDegrees = -transform.eulerAngles.x;
	}
}
