using UnityEngine;

/// <summary>
/// Script que vai ser responsavel pra ficar lançando alimentos na tela
/// </summary>
public class SpawnDosAlimentos : MonoBehaviour
{
    [SerializeField] private Transform[] PontosDeSpawn;
    [SerializeField] private GameObject[] Alimentos;

    private float Timer;
    
    //A cada segundo o sccript vai lançar a função spawn no ponto
    private void Update()
    {
        Timer += Time.deltaTime;

        if(Timer >= 1f) SpawnNoPonto(Random.Range(0, 4));
    }

    //Essa função vai pegar um alimento aleatorio e usar um pointer aleatorio pra determinar a posição
    void SpawnNoPonto(int Ponto)
    {
        Instantiate(Alimentos[Random.Range(0, 2)], PontosDeSpawn[Ponto].position, Quaternion.identity);
        Timer = 0f;
    }
}
