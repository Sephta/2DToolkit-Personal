using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBehavior : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ComboManager._instance.canRecieveInput = true;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (ComboManager._instance.inputRecieved)
        {
            animator.SetTrigger("Attack01");
            ComboManager._instance.InputManager();
            ComboManager._instance.inputRecieved = false;
        }
    }
}
