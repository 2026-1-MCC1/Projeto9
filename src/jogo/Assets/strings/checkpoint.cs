using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class checkpoint : MonoBehaviour
{
    [Header("Configurações de Vida e Checkpoints")]
    [Tooltip("Sistema de vida")]
    public float life = 100; //vida agora
    public float lifemax = 100; //vida para sempre
    private Vector3 ultimoCheckpoint;
    // Armazena a posição de onde o jogador deve renasce 
    [Header("Referência da Interface")]
    public Slider barraVidaUI;

    // Referência ao CharacterController do seu script Playermover
    private CharacterController controller;

    void Start()
    {
        // Pega o CharacterController que já está no jogador
        controller = GetComponent<CharacterController>();
        
        // Define que o checkpoint inicial é o exato local onde ele nasce no mapa
        ultimoCheckpoint = transform.position;

        if (barraVidaUI != null)
        {
            barraVidaUI.maxValue = lifemax;
            AtualizarBarra();
        }
    }
    void AtualizarBarra()
    {
        if (barraVidaUI != null)
        {
            barraVidaUI.value = life;
        }
    }
    void Update()
    {

        if (0 >= life)
        {
            Respawnar();
            life = lifemax;
            AtualizarBarra();
        }


       
    }
    public void tomarDano (float dano)
    {
        life -= dano;
        AtualizarBarra();
    }
    public void Curar(float quantidade)
    {
        // Mathf.Min garante que a vida não passe do lifemax
        life = Mathf.Min(life + quantidade, lifemax);

        // Atualiza a barra de vida para que o jogador veja subindo
        AtualizarBarra();
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

    // Essa função é chamada automaticamente quando o jogador encosta em uma Trigger
    void OnTriggerEnter(Collider outro)
    {
        if (outro.CompareTag("Checkpoint"))
        {
            ultimoCheckpoint = outro.transform.position;
            Debug.Log("Novo checkpoint salvo!");
            outro.enabled = false;
        }
        if (outro.CompareTag("spike"))
        {
            Respawnar();
        }
        if (outro.CompareTag("Arrow"))
        {
            tomarDano(20); // dano configurável
        }
        if (outro.CompareTag("Finish"))
        {
            VencerJogo();
        }
         
    }

  
    private void OnTriggerStay(Collider segundo)
    {
        if (segundo.CompareTag("cura"))
        {
            Curar(0.5f);
        }
    }
    void VencerJogo()
    {
        Debug.Log("Parabéns!");
        SceneManager.LoadScene("saida");
    }
}
