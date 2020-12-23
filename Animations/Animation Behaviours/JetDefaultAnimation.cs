using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetDefaultAnimation : StateMachineBehaviour
{
    [SerializeField] AnimationClip clipToRandomize;

    AnimationCurve GenerateJetAnimationCurve(RectTransform objectsTransform, bool forXAxis)
    {
      Keyframe[] keyframes = new Keyframe[3];

      if (forXAxis)
      {
         keyframes[0] = new Keyframe(0.0f, 1f);
         keyframes[1] = new Keyframe(0.5f, 0.9f + 0.1f * Random.value);
         keyframes[2] = new Keyframe(1f, 1f);
      }
      else
      {
         keyframes[0] = new Keyframe(0.0f, objectsTransform.localScale.y);
         keyframes[1] = new Keyframe(0.5f, 0.5f + 0.3f * Random.value);
         keyframes[2] = new Keyframe(1f, 0.75f + 0.15f * Random.value);
      }

      return new AnimationCurve(keyframes);
    }
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    // override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    // {
    // }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      clipToRandomize.SetCurve("", typeof(RectTransform), "localScale.x", GenerateJetAnimationCurve((RectTransform) animator.transform, true));
      clipToRandomize.SetCurve("", typeof(RectTransform), "localScale.y", GenerateJetAnimationCurve((RectTransform) animator.transform, false));
      animator.SetFloat("Speed Multiplier", (1.0f));
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
