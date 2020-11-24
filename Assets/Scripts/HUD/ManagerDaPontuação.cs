using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script que vai ser responsavel por mudar a pontuação
/// </summary>
public class ManagerDaPontuação : MonoBehaviour
{
    [SerializeField] private Text Pontuação;

    //Ele vai atualizar o placar de acordo com a pontuação marcada
    private void Update()
    {
        Pontuação.text = $"{Jogo.Pontuação}";
    }
}
