using UnityEngine;

public class MinimapFollow : MonoBehaviour
{
    [Header("Configurações de Seguimento")]
    [Tooltip("Arraste o objeto do jogador para este campo.")]
    public Transform player;

    [Tooltip("Altura da câmera acima do labirinto.")]
    public float altura = 25f;

    [Header("Comportamento Estilo GTA")]
    [Tooltip("Se marcado, o mapa gira acompanhando a visão do jogador. Se desmarcado, o mapa fica fixo.")]
    public bool girarMapaComPlayer = true;

    [Tooltip("Suavidade no acompanhamento da câmera (0 a 20).")]
    public float suavidade = 10f;

    void LateUpdate()
    {
        // Impede erros caso o jogador não esteja configurado
        if (player == null) return;

        // Calcula a posição desejada (x e z do player, mas na altura definida)
        Vector3 posicaoAlvo = new Vector3(player.position.x, player.position.y + altura, player.position.z);

        // Aplica o movimento suave até a posição alvo
        transform.position = Vector3.Lerp(transform.position, posicaoAlvo, Time.deltaTime * suavidade);

        if (girarMapaComPlayer)
        {
            // Estilo GTA: A câmera mantém o ângulo de 90 graus para baixo (X),
            // mas gira no eixo Y conforme o jogador vira.
            transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
        }
        else
        {
            // Mapa estático (Norte sempre para cima)
            transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        }
    }
}