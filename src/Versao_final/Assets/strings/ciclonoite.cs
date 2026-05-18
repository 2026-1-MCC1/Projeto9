using UnityEngine;

public class ciclonoite : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Configurações de Tempo")]
    public float velocidadeTempo = 1.0f; // Quão rápido o sol se move
    public bool jogoSalvo = false; // Controle para saber se paramos o ciclo

    [Header("Referência")]
    public Light sol;

    void Update()
    {
        // Se o jogo ainda não foi salvo, o sol continua girando
        if (!jogoSalvo)
        {
            RotacionarSol();
            VerificarSeAnoiteceu();
        }
    }

    void RotacionarSol()
    {
        // Faz a luz girar no eixo X para simular o sol nascendo e se pondo
        float rotacao = velocidadeTempo * Time.deltaTime;
        sol.transform.Rotate(Vector3.right * rotacao);
    }

    void VerificarSeAnoiteceu()
    {
        float anguloX = sol.transform.eulerAngles.x;
        // Se o sol "se pôs" (ângulo entre 180 e 190), nós paramos a rotação
        if (anguloX >= 180f && anguloX <= 190f)
        {
            velocidadeTempo = 0; // O sol para de se mover no horizonte
        }
    }

    // Chame esta função quando o jogador interagir com a estátua de Minotauro
    public void MarcarComoSalvo()
    {
        jogoSalvo = true;
        Debug.Log("Progresso salvo! O ciclo de tempo parou.");
    }
}
