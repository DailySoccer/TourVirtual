using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ChildrenAnimated : StateMachineBehaviour {
	
	[SerializeField]
	private float speed = 1f;
	
	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		var animatedChildren = new List<IAnimated>(animator.GetComponentsInChildren<IAnimated>());

		if (speed >= 0f) {
			animatedChildren.ForEach( c => c.Open(speed));
		} else {
			animatedChildren.ForEach( c => c.Close(-speed));
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
