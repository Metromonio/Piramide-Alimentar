using UnityEngine;

/// <summary>
/// Script que vai lidar com a ação de atirar
/// </summary>
public class ManagerDoTiro : MonoBehaviour
{
    [SerializeField] private Transform SpawnDoTiro;
    [SerializeField] private GameObject Tiro;
    private float Timer;

    private void Update()
    {
        //Utilizo um timer pra limitar o player a atirar apenas a cada quarto de segundo.
        Timer += Time.deltaTime;

        //Quando o player utilizar algum dos inputs, o tiro vai ser spawnado e o timer resetado
        if (Input.GetMouseButtonDown(0) || Input.GetKey(KeyCode.Space) && Timer >= 1f){
            Instantiate(Tiro, SpawnDoTiro.position, Quaternion.identity);
            Timer = 0f;
        }
    }
}
