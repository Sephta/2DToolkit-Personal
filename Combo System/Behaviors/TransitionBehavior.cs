using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionBehavior : StateMachineBehaviour
{
    [Header("Transition Data")]
    public string _triggerName = "";

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ComboManager._instance.canRecieveInput = true;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (ComboManager._instance.inputRecieved)
        {
            animator.SetTrigger(_triggerName);
            ComboManager._instance.InputManager();
            ComboManager._instance.inputRecieved = false;
        }
    }
}
