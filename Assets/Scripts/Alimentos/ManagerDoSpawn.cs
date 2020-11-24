using UnityEngine;

/// <summary>
/// Script que vai ser responsavel pelo peso e lançamento dos alimentos
/// </summary>

//Novamente vamos usar o requirecomponent
[RequireComponent(typeof(Rigidbody2D))]
public class ManagerDoSpawn : MonoBehaviour
{
    [SerializeField] private float Peso, Velocidade;
    private float VelocidadeFinal;

    Rigidbody2D Rb;
    
    //Faço um calculo da velocidade final dividindo o peso pela velocidade
    public float CalculoDaVelocidade()
    {
        VelocidadeFinal = Peso * Velocidade;

        Debug.Log("Calculando Velocidade Final: " + VelocidadeFinal);

        return VelocidadeFinal;
    }

    private void Start()
    {
        CalculoDaVelocidade();
        Rb = GetComponent<Rigidbody2D>();

        Rb.AddForce(transform.up * VelocidadeFinal);
    }
}

