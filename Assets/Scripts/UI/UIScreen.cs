using UnityEngine;
using System.Collections;

public class UIScreen : MonoBehaviour {

	public bool IsOpen
	{
		get { return _animator.GetBool("IsOpen"); }
		set {
			if (Animator != null) {
				Animator.SetBool("IsOpen", value);
			}
		}
	}

	protected Animator _animator;
	protected Animator Animator {
		get {
			if (_animator == null) {
				_animator = GetComponent<Animator>();
			}
			return _animator;
		}
	}

	public bool InOpenState {
		get {
			return Animator.GetCurrentAnimatorStateInfo(0).IsName("Open");
		}
	}

	public bool InCloseState {
		get {
			return Animator.GetCurrentAnimatorStateInfo(0).IsName("Close");
		}
	}

	public virtual void Awake()
	{
		_animator = GetComponent<Animator>();
		_canvasGroup = GetComponent<CanvasGroup>();
		
		var rect = GetComponent<RectTransform>();
		rect.offsetMax = rect.offsetMin = new Vector2(0, 0);
	}

	public virtual void Start()
	{
	}

	public virtual void Update()
	{
		// Aseguramos que si un menu no está activado, no es interactuable.
		_canvasGroup.blocksRaycasts = _canvasGroup.interactable = Animator.GetCurrentAnimatorStateInfo(0).IsName("Open");
	}

	public virtual void OpenWindow() {
	}

	public virtual void CloseWindow() {
	}
	
	private CanvasGroup _canvasGroup;
}
