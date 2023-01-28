using UnityEngine;

public class AttackingSMB : SceneLinkedSMB<Enemy>
{
    private static readonly int Attack = Animator.StringToHash("attack");

    public override void OnSLStateNoTransitionUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnSLStateNoTransitionUpdate(animator,stateInfo,layerIndex);

        if (Time.time >= m_MonoBehaviour.timeUntilNextAttack)
        {
            animator.SetTrigger(Attack);
        }
        
    }
        
}