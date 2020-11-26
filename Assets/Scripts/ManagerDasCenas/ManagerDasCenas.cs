using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Script para ir em outra cena e fechar o jogo
/// </summary>
public class ManagerDasCenas : MonoBehaviour
{
    //Vai mudar de cena de acordo com o integer que colocarmos no Canvas
    public void MudarDeCena(int CenaParaIr)
    {
        SceneManager.LoadScene(CenaParaIr);
    }

    public void FecharJogo()
    {
        Application.Quit();
    }

    //Função pra mutar ou desmutar a musica
    public void MutarMusica()
    {
        if (AudioListener.volume == 1f) AudioListener.volume = 0f;
        else AudioListener.volume = 1f;
    }
}
