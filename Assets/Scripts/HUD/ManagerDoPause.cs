using UnityEngine;

/// <summary>
/// Script resposavel pelo menu de pause
/// </summary>
public class ManagerDoPause : MonoBehaviour
{
    [SerializeField] private Animator AnimDoPause;

    //Função para pausar o jogo, ela vai diminuir o som tb
    public void Pause()
    {
        AudioListener.volume = .25f;
        Jogo.Pausado = true;
        AnimDoPause.SetTrigger("Entrar");
    }

    //Função para despausar
    public void UnPause()
    {
        AudioListener.volume = 1f;
        Jogo.Pausado = false;
        Time.timeScale = 1f;
        AnimDoPause.SetTrigger("Sair");
    }

    public void FecharJogo()
    {
        Application.Quit();
    }
}
