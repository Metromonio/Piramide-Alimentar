using UnityEngine;

/// <summary>
/// Script feito para limpar os alimentos que saem pra fora da tela
/// </summary>
public class Lixeira : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Se o collider que tocar for um alimento, ele vai ser destruido
        if (collision.gameObject.CompareTag("Alimentos"))
        {
            var Sprite = collision.transform.GetChild(0);
            Destroy(collision.gameObject);
            Destroy(Sprite);
        }
    }

}
