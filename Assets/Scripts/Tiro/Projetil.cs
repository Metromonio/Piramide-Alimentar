
using UnityEngine;

/// <summary>
/// Script que vai lidar com o disparo dos tiros
/// </summary>

//Utilizo um requipecomponent pra sempre aplicar um rigidbody e um boxCollider no objeto
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Projetil : MonoBehaviour
{
    [SerializeField] private float VelocidadeDoDisparo;
    [SerializeField] private Vector2 FinalPos;

    Rigidbody2D Rb;

    //Simplesmente inicializo o rigidbody e aplico uma força nele com a velocidade determinada
    private void Start()
    {
        FinalPos = new Vector2(transform.position.x, transform.position.y + 10);
        Rb = GetComponent<Rigidbody2D>();

        Rb.AddForce(transform.up * VelocidadeDoDisparo);
    }

    //Update pra destroir o projetil ao atingir X altura
    private void Update()
    {
        if (transform.position.y >= FinalPos.y) Destroy(gameObject);
    }

    //Um trigger pra destruir os alimentos que tocar, se for possível
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Alimentos"))
        {
            IDestruir DestruirAlimento = collision.GetComponent<IDestruir>();

            if(DestruirAlimento != null) DestruirAlimento.Destruir();
        }
        Destroy(gameObject);
    }
}
