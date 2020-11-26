using UnityEngine;

/// <summary>
/// Script que vai ser responsavel pelo peso e lançamento dos alimentos ruins
/// Vamos utilizar a Interface IDestruir pra ficar responsavel pela função de fazer algo quando atingido pelos tiros
/// </summary>

//Novamente vamos usar o requirecomponent
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class ManagerDosExtras : MonoBehaviour, IDestruir
{
    [SerializeField] private float Peso, Velocidade;
    [SerializeField] private GameObject Efeito;
    [SerializeField] private bool Direita;
    [SerializeField] private Animator Anim;
    private float VelocidadeFinal;

    Rigidbody2D Rb;
    BoxCollider2D Box;
    ManagerDasVidas Vidas;
    AudioSource Erro, FimDeJogo;

    //Faço um calculo da velocidade final dividindo o peso pela velocidade
    public float CalculoDaVelocidade()
    {
        VelocidadeFinal = Peso * Velocidade;

        Debug.Log("Calculando Velocidade Final: " + VelocidadeFinal);

        return VelocidadeFinal;
    }

    //Quando inciializado vamos fazer o calculo do peso e pegar componentes necessarios
    //Tambem vamos determinar se o objeto sera jogado da direita ou esquerda
    private void Start()
    {
        CalculoDaVelocidade();
        Rb = GetComponent<Rigidbody2D>();
        Box = GetComponent<BoxCollider2D>();
        Erro = GameObject.Find("Erro").GetComponent<AudioSource>();
        FimDeJogo = GameObject.Find("FimDeJogo").GetComponent<AudioSource>();

        //Temos que procurar o script ManagerDasVidas pra referencia-lo
        var ManagerDoJogo = GameObject.Find("ManagerDoJogo");
        Vidas = ManagerDoJogo.GetComponent<ManagerDasVidas>();

        if(Direita) Rb.AddForce(transform.right * VelocidadeFinal);
        else if(!Direita) Rb.AddForce(-transform.right * VelocidadeFinal);
    }

    //Função da interface
    public void Destruir()
    {
        if (Jogo.Vidas > 1) Erro.Play();
        else if (Jogo.Vidas <= 1) FimDeJogo.Play();
        Jogo.Vidas--;
        Instantiate(Efeito, gameObject.transform.position, Quaternion.identity);
        Vidas.DestruirVida(Jogo.Vidas);
        Box.enabled = false;
        Anim.SetTrigger("Pegou");
    }
}
