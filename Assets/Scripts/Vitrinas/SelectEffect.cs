using UnityEngine;
using System.Collections;

public class SelectEffect : MonoBehaviour {

	#region Public members
	public float CycleTime;
	public float MaxIntensity;
	public float MinIntensity;
	#endregion

	#region Public methods
	public void StartSelection()
	{
		StartAnim(1);
	}
	public void EndSelection()
	{
		StartAnim(-1);
	}
	#endregion

	#region MonoBehaviour methods
	// Use this for initialization
	void Start () {
		_side = 1;
		_workToDo = false;
		_HALF_CYCLE = CycleTime * 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		if (_workToDo)
		{
			float perc;
			if (_side < 1)
			{
				perc = 1 - ((Time.time - _startTime) / _HALF_CYCLE);
				_workToDo = perc <= 1;
			}
			else
			{
				perc = Mathf.Abs(_HALF_CYCLE - ((Time.time - _startTime) % CycleTime)) / _HALF_CYCLE;
			}
			SetPropertyLevel(Mathf.Clamp01(perc));
		}
	}
	#endregion

	#region Private methods
	private void StartAnim(int side)
	{
		_workToDo = true;
		_side = side;
		_startTime = Time.time - (_side > 0 ? 0 : Mathf.Abs(_HALF_CYCLE - ((Time.time - _startTime) % CycleTime)));
	}
	private void SetPropertyLevel(float unitaryPerc)
	{
		float result = MinIntensity + (MaxIntensity - MinIntensity) * unitaryPerc;
	}
	#endregion

	#region Private members
	private float _startTime;
	private bool _workToDo;
	private int _side;
	private float _HALF_CYCLE;
	#endregion
}
