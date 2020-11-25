using UnityEngine;

/// <summary>
/// Script pra controlar o jogo,
/// Nele a gente vai controlar as pontuações, vidas, dificuldades e decidir se ele ta pausado ou não
/// </summary>
public class Jogo : MonoBehaviour
{
    [SerializeField] private Animator AnimaçãoGameOver;

    public static int Pontuação = 0000;
    public static float TimerDificuldade = 2f;
    public static int Vidas = 3;

    public static bool Pausado = false;

    private void Start()
    {
        ResetarJogo();
    }
    //Update pra aumentar a dificuldade do jogo conforme vc pontua
    private void Update()
    {
        //Ciclo de else ifs pra determinar a velocidade de spawn dos alimentos conforme a pontuação
        if (Pontuação > 50 && Pontuação < 100) TimerDificuldade = 1.5f;
        else if (Pontuação > 100 && Pontuação < 300) TimerDificuldade = 1f;
        else if (Pontuação > 300 && Pontuação < 600) TimerDificuldade = .75f;
        else if (Pontuação > 600 && Pontuação < 1000) TimerDificuldade = .5f;
        else if (Pontuação > 1000) TimerDificuldade = .25f;

        if (Vidas == 0) TelaDeGameOver();

        if (!Pausado) return;

        Time.timeScale = 0f;

    }


    //Função pra inicializar a tela de gameover e pausar o jogo
    private void TelaDeGameOver()
    {
        Pausado = true;
        AnimaçãoGameOver.SetTrigger("Acabou");
    }

    //Função pra resetar as variaveis toda vez que reiniciar o jogo
    private void ResetarJogo()
    {
        Vidas = 3;
        Time.timeScale = 1f;
        Pontuação = 0;
        TimerDificuldade = 2f;
        Pausado = false;
    }
}
