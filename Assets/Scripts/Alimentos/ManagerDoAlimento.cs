using UnityEngine;

/// <summary>
/// Script que vai ser responsavel pelo peso e lançamento dos alimentos
/// Vamos utilizar a Interface IDestruir pra ficar responsavel pela função de fazer algo quando atingido pelos tiros
/// </summary>

//Novamente vamos usar o requirecomponent
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class ManagerDoAlimento : MonoBehaviour, IDestruir
{
    [SerializeField] private float Peso, Velocidade;
    [SerializeField] private GameObject Efeito;
    [SerializeField] private int PontosDoAlimento;
    [SerializeField] private Animator Anim;
    private float VelocidadeFinal;

    Rigidbody2D Rb;
    BoxCollider2D Box;

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
        Box = GetComponent<BoxCollider2D>();

        Rb.AddForce(transform.up * VelocidadeFinal);
    }

    public void Destruir()
    {
        Jogo.Pontuação += PontosDoAlimento;
        Instantiate(Efeito, gameObject.transform.position, Quaternion.identity);
        Box.enabled = false;
        Anim.SetTrigger("Pegou");
    }
}

