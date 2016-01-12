using UnityEngine;
using System.Collections;

public class SlidePopUp: StateMachineBehaviour {
	
	public enum Direction {
		Top,
		Bottom,
		Left,
		Right
	}

	private struct Anchors {
		public Vector2 max;
		public Vector2 min;
	}

	[SerializeField]
	private Direction _entranceDirectionFrom;
	
	[SerializeField]
	private float _speed = 1f;

	[SerializeField]
	private GoEaseType _easeType;

	[SerializeField]
	private float _delay = 0f;

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		
		RectTransform screenTransf = animator.gameObject.transform.GetChild(0) as RectTransform;
		screenTransf.anchoredPosition = new Vector2(screenTransf.anchoredPosition.x, 0f);
		screenTransf.pivot = new Vector2(0.5f, 0.5f);
		
		GoTweenConfig finalConfig = new GoTweenConfig();
		Anchors anchors = GetEntranceDirectionAnchors();
		
		if (_speed > 0f) {
			screenTransf.anchorMax = anchors.max;
			screenTransf.anchorMin = anchors.min;
			
			finalConfig.anchorMax(new Vector2(1f, 1f))
						.anchorMin(new Vector2(0f, 0f));

		} else {
			screenTransf.anchorMax = new Vector2(1f, 1f);
			screenTransf.anchorMin = new Vector2(0f, 0f);
			
			finalConfig.anchorMax(anchors.max)
						.anchorMin(anchors.min);

		}

		finalConfig.setDelay(_delay);

		Go.to(screenTransf, stateInfo.length * Mathf.Abs(1/_speed), finalConfig).easeType = _easeType;
	}

	private Anchors GetEntranceDirectionAnchors() {

		Anchors anchors = new Anchors();
		switch (_entranceDirectionFrom) {
			case Direction.Top:
				anchors.max = new Vector2(1f, 2f);
				anchors.min = new Vector2(0f, 1f);
			break;
			case Direction.Bottom:
				anchors.max = new Vector2(1f, 0f);
				anchors.min = new Vector2(0f, -1f);
			break;
			case Direction.Left:
				anchors.max = new Vector2(0f, 1f);
				anchors.min = new Vector2(-1f, 0f);
			break;
			case Direction.Right:
				anchors.max = new Vector2(2f, 1f);
				anchors.min = new Vector2(1f, 0f);
			break;
			default:
				Debug.LogError("Pop up screen animation direction not covered");
			break;
		}

		return anchors;
	}
	
	
	
	
	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	/*override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		RectTransform screenTransf = animator.gameObject.transform.GetChild(0) as RectTransform;
		//animator.speed;
		float t = timeFunction(stateInfo.normalizedTime);

		if (t != old_t) {

			screenTransf.anchoredPosition = new Vector2(screenTransf.anchoredPosition.x, 0f);
			screenTransf.anchorMax = new Vector2(screenTransf.anchorMax.x, t);
			screenTransf.pivot = new Vector2(screenTransf.pivot.x, 1f - t/2f);
			old_t = t;

		}
	}
	*/
	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
	
	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
	
	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
	/*
	private float timeFunction(float normalizedTime) {
		float result = normalizedTime;

		if ( speed < 0f ) {
			result = 1f + result * speed;
		}

		return Mathf.Clamp01(result);
	}
*/
}
