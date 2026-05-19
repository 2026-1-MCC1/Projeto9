using UnityEngine;

public class BirdsController : MonoBehaviour
{
    [Header("Alvo")]
    public Transform alvo;

    [Header("Configurações")]
    public float raio = 5f;
    public float velocidade = 2f;
    public bool sentidoHorario = true;

    [Header("Rotação")]
    public float velocidadeRotacao = 10f;
    public bool andarDeCostas = true; // marca para andar de costas

    private float angulo = 0f;
    private Vector3 posicaoAnterior;

    void Start()
    {
        posicaoAnterior = transform.position;
    }

    void Update()
    {
        if (alvo == null) return;

        float direcao = sentidoHorario ? -1f : 1f;
        angulo += direcao * (velocidade / raio) * Time.deltaTime * Mathf.Rad2Deg;

        float rad = angulo * Mathf.Deg2Rad;
        float x = alvo.position.x + Mathf.Cos(rad) * raio;
        float z = alvo.position.z + Mathf.Sin(rad) * raio;

        Vector3 novaPosicao = new Vector3(x, transform.position.y, z);
        Vector3 direcaoMovimento = (novaPosicao - posicaoAnterior);

        if (direcaoMovimento.sqrMagnitude > 0.001f)
        {
            // Inverte a direção para andar de costas
            Vector3 direcaoFinal = andarDeCostas ? -direcaoMovimento.normalized : direcaoMovimento.normalized;

            Quaternion rotacaoAlvo = Quaternion.LookRotation(direcaoFinal);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacaoAlvo, Time.deltaTime * velocidadeRotacao);
        }

        transform.position = novaPosicao;
        posicaoAnterior = novaPosicao;
    }
}