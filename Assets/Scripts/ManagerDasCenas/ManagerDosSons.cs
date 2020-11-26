using UnityEngine;

/// <summary>
/// Script responsavel pelos sons do jogo
/// </summary>
public class ManagerDosSons : MonoBehaviour
{
    private GameObject[] Sons;
    private GameObject OST;

    //Eu utilizo uma função dontdestroyonload para funcionar em todos os menus, e uso um find pra não deixar ter mais de 2 objetos iguais no mesmo lugar.
    private void Start()
    {
        Sons = GameObject.FindGameObjectsWithTag("Sons");
        if (Sons.Length > 1) Destroy(Sons[1]);
        DontDestroyOnLoad(gameObject);
    }

    //Esse update vai ser responsavel por checar quando a ost do jogo tiver tocando, se for o caso esse objeto vai ser destruido
    private void Update()
    {
        OST = GameObject.FindGameObjectWithTag("OSTDoJog");

        if (OST == null) return;

        Destroy(gameObject);
    }
}
