
using UnityEngine;

/// <summary>
/// Script que vai lidar com o disparo dos tiros
/// </summary>

//Utilizo um requipecomponent pra sempre aplicar um rigidbody no objeto que tiver esse script
[RequireComponent(typeof(Rigidbody2D))]
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
}
