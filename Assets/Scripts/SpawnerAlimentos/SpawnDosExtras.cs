using UnityEngine;

/// <summary>
/// Script que vai ser responsavel pra ficar lançando alimentos na horizontal da tela
/// </summary>
public class SpawnDosExtras : MonoBehaviour
{
    [SerializeField] private Transform[] PontosDeSpawn;
    [SerializeField] private GameObject[] Alimentos;
    [SerializeField] private int MaximoPontos;

    private float Timer;

    //A cada segundo o sccript vai lançar a função spawn no ponto
    private void Update()
    {
        Timer += Time.deltaTime;

        if (Timer >= Jogo.TimerDificuldade && !Jogo.Pausado) SpawnNoPonto(Random.Range(0, MaximoPontos));
    }

    //Essa função vai pegar um alimento aleatorio e usar um pointer aleatorio pra determinar a posição
    void SpawnNoPonto(int Ponto)
    {
        int Alimento = 0;
        if (Ponto == 0) Alimento = Random.Range(0, 3);
        else if (Ponto == 1) Alimento = Random.Range(3, 6);

        Instantiate(Alimentos[Alimento], PontosDeSpawn[Ponto].position, Quaternion.identity);
        Timer = 0f;
    }
}
