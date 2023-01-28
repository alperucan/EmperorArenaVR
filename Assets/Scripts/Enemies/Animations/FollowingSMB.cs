using UnityEngine;


public class FollowingSMB : SceneLinkedSMB<Enemy>
{
    public override void OnSLStateNoTransitionUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnSLStateNoTransitionUpdate(animator,stateInfo,layerIndex);

        m_MonoBehaviour.Agent.SetDestination(m_MonoBehaviour.Target.position);
    }
        
}
