using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SelectEffect : MonoBehaviour {

	#region Public members
	public float CycleTime = 2.5f;
	public float MaxIntensity = 0.5f;
	public float MinIntensity = 0;
	#endregion

	#region Public methods
	public void OnSelect()
	{
		for (int i = 0; i < transform.childCount; ++i)
		{
			transform.GetChild(i).gameObject.SetActive(true);
		}
		StartAnim(1);
	}
	public void OnDeselect()
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
		Transform childResaltado = transform;
		do
		{
			childResaltado = childResaltado.childCount != 0 ? childResaltado.GetChild(0) : null;
			Renderer rendRef = childResaltado == null ? null : childResaltado.GetComponent<Renderer>();
			if (rendRef != null)
			{
				_matRef.Add(rendRef.material);
			}
		} while (childResaltado != null);
	}
	
	// Update is called once per frame
	void Update () {
		//TODO: erase this calculation
		_HALF_CYCLE = CycleTime * 0.5f;
		if (_workToDo)
		{
			float perc;
			if (_side < 1)
			{
				perc = ((Time.time - _startTime) / _HALF_CYCLE);
				_workToDo = perc <= 1;
			}
			else
			{
				perc = (Mathf.Abs(_HALF_CYCLE - ((Time.time - _startTime) % CycleTime)) / _HALF_CYCLE);
			}
			SetPropertyLevel(Mathf.Clamp01(1 - perc));
			if (!_workToDo)
			{
				for (int i = 0; i < transform.childCount; ++i)
				{
					transform.GetChild(i).gameObject.SetActive(false);
				}
			}
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
		if (_matRef != null)
		{
			float result = MinIntensity + (MaxIntensity - MinIntensity) * unitaryPerc;
			foreach (Material mat in _matRef)
			{
				Color matC = mat.GetColor("_TintColor");
				matC.a = result;
				mat.SetColor("_TintColor", matC);
			}
		}
	}
	#endregion

	#region Private members
	private float _startTime;
	private bool _workToDo;
	private int _side;
	private float _HALF_CYCLE;
	private List<Material> _matRef = new List<Material>();
	#endregion
}
