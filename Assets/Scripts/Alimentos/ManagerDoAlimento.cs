using UnityEngine;

/// <summary>
/// Script que vai ser responsavel pelo peso e lançamento dos alimentos
/// Vamos utilizar a Interface IDestruir pra ficar responsavel pela função de fazer algo quando atingido pelos tiros
/// </summary>

//RequireComponent pra facilitar no editor, dessa forma não temos que ficar colocando o rigidbody toda vez que criar um novo objeto
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
    AudioSource Acerto;

    //Faço um calculo da velocidade final dividindo o peso pela velocidade
    public float CalculoDaVelocidade()
    {
        VelocidadeFinal = Peso * Velocidade;

        Debug.Log("Calculando Velocidade Final: " + VelocidadeFinal);

        return VelocidadeFinal;
    }

    //Quando inicializado, o objeto vai rodar o calculo do peso e pegar componentes necessarios
    private void Start()
    {
        CalculoDaVelocidade();
        Rb = GetComponent<Rigidbody2D>();
        Box = GetComponent<BoxCollider2D>();
        Acerto = GameObject.Find("Acerto").GetComponent<AudioSource>();

        Rb.AddForce(transform.up * VelocidadeFinal);
    }

    //A função da interface
    public void Destruir()
    {
        Acerto.Play();
        Jogo.Pontuação += PontosDoAlimento;
        Instantiate(Efeito, gameObject.transform.position, Quaternion.identity);
        Box.enabled = false;
        Anim.SetTrigger("Pegou");
    }
}

