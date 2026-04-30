using UnityEngine;
using UnityEngine.SceneManagement;

public class checkpoint : MonoBehaviour
{
    [Header("Configurações de Vida e Checkpoints")]
    [Tooltip("Sistema de vida")]
    public float life = 100; //vida agora
    public float lifemax = 100; //vida para sempre
    private Vector3 ultimoCheckpoint;
    // Armazena a posição de onde o jogador deve renasce 

    // Referência ao CharacterController do seu script Playermover
    private CharacterController controller;

    void Start()
    {
        // Pega o CharacterController que já está no jogador
        controller = GetComponent<CharacterController>();

        // Define que o checkpoint inicial é o exato local onde ele nasce no mapa
        ultimoCheckpoint = transform.position;
    }

    void Update()
    {

        if (0 >= life)
        {
            Respawnar();
            life = lifemax;
        }


        void Respawnar() // classe de respawnar
        {
            // O SEGREDO DO CHARACTER CONTROLLER:
            // Precisamos desligá-lo rapidamente para que ele permita o teleporte
            if (controller != null)
            {
                controller.enabled = false;
            }
            // Teleporta o jogador de volta para a posição salva
            transform.position = ultimoCheckpoint;
            // Liga o Character Controller de volta para ele voltar a andar e cair
            if (controller != null)
            {
                controller.enabled = true;
            }
            Debug.Log(" Voltando ao último checkpoint...");
        }
    }
    public void tomarDano (float dano)
    {
        life -= dano;
    }

    // Essa função é chamada automaticamente quando o jogador encosta em uma Trigger
    void OnTriggerEnter(Collider outro)
    {
        if (outro.CompareTag("Checkpoint"))
        {
            ultimoCheckpoint = outro.transform.position;
            Debug.Log("Novo checkpoint salvo!");
            outro.enabled = false;
        }
        else if (outro.CompareTag("Trap"))
        {
            tomarDano(25); // dano configurável
        }
        else if (outro.CompareTag("Finish"))
        {
            VencerJogo();
        }
    }
    void VencerJogo()
    {
        Debug.Log("Parabéns!");
        SceneManager.LoadScene("saida");
    }
}
