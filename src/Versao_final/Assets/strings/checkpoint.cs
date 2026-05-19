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

    [Header("Referência da Interface")]
    public Slider barraVidaUI;
    public GameObject canvasCheckpoint;

    private CharacterController controller;
    
    private PlayerControllerSounds playerSom;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerSom = GetComponent<PlayerControllerSounds>();
        ultimoCheckpoint = transform.position;

        if (barraVidaUI != null)
        {
            barraVidaUI.maxValue = lifemax;
            AtualizarBarra();
        }
        if (canvasCheckpoint != null)
        {
            canvasCheckpoint.SetActive(false);
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
            if (playerSom != null) playerSom.TocarMorte();

            // A função Respawnar já faz o teletransporte seguro (desligando e ligando o controller)
            Respawnar();

            life = lifemax;
            AtualizarBarra();
            // REMOVIDO: transform.position = ultimoCheckpoint; (Era isso que estava quebrando a física!)
        }
    }

    public void tomarDano(float dano)
    {
        life -= dano;
        AtualizarBarra();

        if (life > 0 && playerSom != null)
        {
            playerSom.audioSource.PlayOneShot(playerSom.somDanoGeral);
        }
    }

    public void Curar(float quantidade)
    {
        life = Mathf.Min(life + quantidade, lifemax);
        AtualizarBarra();
    }

    void Respawnar()
    {
        if (controller != null)
        {
            // OBRIGATÓRIO: Desligar o controller para mover pela Unity
            controller.enabled = false;
        }

        transform.position = ultimoCheckpoint;

        if (controller != null)
        {
            // OBRIGATÓRIO: Ligar de volta após mover
            controller.enabled = true;
        }
        Debug.Log(" Voltando ao último checkpoint...");
    }

    void OnTriggerEnter(Collider outro)
    {
        if (outro.CompareTag("Checkpoint"))
        {
            ultimoCheckpoint = outro.transform.position;
            if (playerSom != null) playerSom.audioSource.PlayOneShot(playerSom.somCheckpoint);
            outro.enabled = false;
            if (canvasCheckpoint != null)
            {
                StartCoroutine(AparecerImagemTempo());
            }
        }


        if (outro.CompareTag("spike"))
        {
            if (playerSom != null)
            {
                playerSom.audioSource.PlayOneShot(playerSom.somEspinhos);
                playerSom.TocarMorte();
            }
            Respawnar();
        }

        if (outro.CompareTag("Arrow"))
        {
            tomarDano(5);
        }

        if (outro.CompareTag("Enemy"))
        {
            tomarDano(80);
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
            if (life < lifemax)
            {
                Curar(0.1f);
                if (playerSom != null) playerSom.IniciarSomCura();
            }
            else
            {
                if (playerSom != null) playerSom.PararSomCura();
            }
        }
    }

    private void OnTriggerExit(Collider outro)
    {
        if (outro.CompareTag("cura"))
        {
            if (playerSom != null) playerSom.PararSomCura();
        }
    }

    void VencerJogo()
    {
        Debug.Log("Parabéns!");
        SceneManager.LoadScene("saida");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    private System.Collections.IEnumerator AparecerImagemTempo()
    {
        // 1. Liga o Canvas (a imagem aparece)
        canvasCheckpoint.SetActive(true);

        // 2. Espera exatamente 2 segundos
        yield return new WaitForSeconds(3f);

        // 3. Desliga o Canvas (a imagem some)
        canvasCheckpoint.SetActive(false);
    }
}
