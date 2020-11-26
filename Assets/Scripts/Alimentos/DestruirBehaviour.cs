using UnityEngine;

/// <summary>
/// Behaviour pra destruir o alimento após a animação
/// </summary>
public class DestruirBehaviour : StateMachineBehaviour
{
    //Ele vai destruir o gameObject após concluir sua animação
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Destroy(animator.gameObject, stateInfo.length);
    }
}
