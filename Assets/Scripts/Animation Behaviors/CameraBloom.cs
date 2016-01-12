using UnityEngine;
using System.Collections;

public class CameraBloom : StateMachineBehaviour {
	
	[SerializeField]
	private float speed = 1f;

	private Animator camAnimator;
	private AnimatorStateInfo camCurr;
	private float lengthRelation;

	//OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		AnimationEffectsInfo effectsInfo = animator.GetComponent<AnimationEffectsInfo>();
		if (Camera.main && effectsInfo != null && effectsInfo.bloomEnabled) {
			camAnimator = Camera.main.gameObject.GetComponent<Animator>();
			camAnimator.SetBool("Bloom", speed >= 0);

			lengthRelation = 1f / stateInfo.length;

			camAnimator.speed = lengthRelation * Mathf.Abs(speed);
		}
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	/*override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

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
