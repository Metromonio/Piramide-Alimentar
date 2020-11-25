using UnityEngine;

public class ManagerDoPause : MonoBehaviour
{
    [SerializeField] private Animator AnimDoPause;

    public void Pause()
    {
        Jogo.Pausado = true;
        AnimDoPause.SetTrigger("Entrar");
    }

    public void UnPause()
    {
        Jogo.Pausado = false;
        Time.timeScale = 1f;
        AnimDoPause.SetTrigger("Sair");
    }

    public void FecharJogo()
    {
        Application.Quit();
    }
}
