using UnityEngine;

/// <summary>
/// Behaviour pra destruir o alimento após a animação
/// </summary>
public class DestruirBehaviour : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Destroy(animator.gameObject, stateInfo.length);
    }
}
