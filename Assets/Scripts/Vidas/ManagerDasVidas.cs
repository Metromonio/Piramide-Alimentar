using UnityEngine;

/// <summary>
/// Script pra retirar os corações do jogo quando tomar dano
/// </summary>
public class ManagerDasVidas : MonoBehaviour
{
    [SerializeField] private Animator[] Vidas;

    //Uma simples função que vai pegar um pointer pra saber qual é a vida que tem que ser removida
    public void DestruirVida(int Vida)
    {
        Vidas[Vida].SetTrigger("Destruir");
    }
}
