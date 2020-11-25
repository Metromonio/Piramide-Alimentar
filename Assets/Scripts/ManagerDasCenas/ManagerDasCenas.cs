using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Script para ir em outra cena e fechar o jogo
/// </summary>
public class ManagerDasCenas : MonoBehaviour
{
    public void MudarDeCena(int CenaParaIr)
    {
        SceneManager.LoadScene(CenaParaIr);
    }

    public void FecharJogo()
    {
        Application.Quit();
    }
}
