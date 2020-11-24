using UnityEngine;

/// <summary>
/// Script que vai ser utilizado para movimentar o Player.
/// </summary>
public class Movimento : MonoBehaviour
{
    [SerializeField] private float VelocidadePadrao;

    private bool LimiteDireta, LimiteEsquerda;
    private void Update()
    {
        //Calculo da Velocidade usando o Input "W" "D" ou "<" ">"
        float VelocidadeFixa = Input.GetAxis("Horizontal") * VelocidadePadrao;

        //Colocamos então o calculo na posição X do objeto
        //Usamos um if para limitar o movimento para não ser usado enquanto estiver tocando no limite da tela
        if (transform.position.x <= 6.75f && transform.position.x >= -6.75f && !LimiteDireta && !LimiteEsquerda) 
            transform.position = new Vector2(transform.position.x + VelocidadeFixa, transform.position.y);

        //Utilizados esses else ifs pra determinar quando o player atinge a tela
        else if (transform.position.x >= 6.75f) LimiteDireta = true;
        else if (transform.position.x <= -6.75f) LimiteEsquerda = true;
    }

    private void FixedUpdate()
    {
        //Um simples if pra retornar caso não esteja em nenhum dos limites
        if (!LimiteDireta && !LimiteEsquerda) return;

        //Caso o player esteja em algum dos limites, a gente trava o movimento dele e usa um movetowards pra movimentar ele para os lados.
        if(LimiteDireta)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(6f, transform.position.y), .07f);

            if (transform.position.x == 6f) LimiteDireta = false;
        }

        if (LimiteEsquerda)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(-6f, transform.position.y), .07f);

            if (transform.position.x == -6f) LimiteEsquerda = false;
        }
    }

}
