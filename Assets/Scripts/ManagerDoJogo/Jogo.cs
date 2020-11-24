using UnityEngine;

/// <summary>
/// Script pra segurar pontuações
/// </summary>
public class Jogo : MonoBehaviour
{
    public static int Pontuação = 0000;
    public static float TimerDificuldade = 2f;
    public static int Vidas = 3;

    //Update pra aumentar a dificuldade do jogo conforme vc pontua
    private void Update()
    {
        if (Pontuação > 50 && Pontuação < 100) TimerDificuldade = 1.5f;
        else if (Pontuação > 100 && Pontuação < 300) TimerDificuldade = 1f;
        else if (Pontuação > 300 && Pontuação < 600) TimerDificuldade = .75f;
        else if (Pontuação > 600 && Pontuação < 1000) TimerDificuldade = .5f;
        else if (Pontuação > 1000) TimerDificuldade = .25f;

        if (Vidas == 0) Application.Quit();

    }
}
