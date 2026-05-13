using UnityEngine;

public class TrapdoorController : MonoBehaviour
{
    [Header("Objetos do Alçapão")]
    public GameObject portaEsquerda;
    public GameObject portaDireita;

    [Header("Configurações")]
    public bool playerPisou = false;
    public float velocidade = 5f;
    public float distanciaAbrir = 4f;

    private Vector3 alvoEsq;
    private Vector3 alvoDir;

    void Start()
    {
        // Salva as posições locais para onde as portas devem deslizar
        alvoEsq = portaEsquerda.transform.localPosition + new Vector3(0, 0, distanciaAbrir);
        alvoDir = portaDireita.transform.localPosition + new Vector3(0, 0, -distanciaAbrir);
    }

    void FixedUpdate()
    {
        // Se a colisão entre Player e Trapdoor aconteceu, move as portas
        if (playerPisou)
        {
            portaEsquerda.transform.localPosition = Vector3.MoveTowards(
                portaEsquerda.transform.localPosition, alvoEsq, velocidade * Time.fixedDeltaTime);

            portaDireita.transform.localPosition = Vector3.MoveTowards(
                portaDireita.transform.localPosition, alvoDir, velocidade * Time.fixedDeltaTime);
        }
    }

    // Detecta a colisão do Player com este objeto (que terá a Tag Trapdoor)
    private void OnTriggerEnter(Collider other)
    {
        // Verifica se quem entrou no gatilho é o Player
        // E confirma se este objeto onde o script está tem a Tag Trapdoor
        if (other.CompareTag("Player") && gameObject.CompareTag("Trapdoor"))
        {
            playerPisou = true;
        }
    }
}
