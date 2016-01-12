using UnityEngine;
using System.Collections;

public class CanvasFade : StateMachineBehaviour {

	[SerializeField]
	private float speed = 1f;

	[SerializeField]
	private GoEaseType easeType;

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		AnimationEffectsInfo effectsInfo = animator.GetComponent<AnimationEffectsInfo>();

		if (effectsInfo != null && effectsInfo.fadeEnabled) {
			
			CanvasGroup canvas = animator.GetComponent<CanvasGroup>();
			float alpha = Mathf.Sign(speed) / 2f + 0.5f; // -1 -> 0 || 1 -> 1

			GoTweenConfig finalConfig = new GoTweenConfig().floatProp("alpha", alpha);
			Go.to(canvas, stateInfo.length * Mathf.Abs(1/speed), finalConfig).easeType = easeType;

		}
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	/*override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		animator.GetComponent<CanvasGroup>().alpha = Mathf.Clamp01(stateInfo.normalizedTime);

	}*/

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
}
