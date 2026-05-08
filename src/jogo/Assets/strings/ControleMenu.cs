using UnityEngine;
using UnityEngine.SceneManagement;

public class ControleMenu : MonoBehaviour
{
    public GameObject painelMenu; // Arraste o objeto 'MenuPausa' para cá no Inspector
    public bool jogoPausado = false;

    void Update()
    {
        // Abre e fecha o menu ao apertar a tecla ESC (Escape)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (jogoPausado)
            {
                RetomarJogo();
            }
            else
            {
                PausarJogo();
            }
        }
    }

    public void PausarJogo()
    {
        painelMenu.SetActive(true); // Mostra o menu
        Time.timeScale = 0f;        // Congela o tempo do jogo (IA e Física param)
        jogoPausado = true;

        // Libera o mouse para clicar nos botões
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void RetomarJogo()
    {
        painelMenu.SetActive(false); // Esconde o menu
        Time.timeScale = 1f;         // O tempo volta ao normal
        jogoPausado = false;

        // Esconde o mouse novamente para jogar
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void IrParaMenuPrincipal()
    {
        Time.timeScale = 1f; // Importante resetar o tempo antes de mudar de cena!
        SceneManager.LoadScene("NomeDoSeuMenu"); // Digite o nome da sua cena de menu
    }

    public void AlterarVolume(float volume)
    {
        AudioListener.volume = volume; // Altera o volume geral do jogo
    }

    public void SairDoJogo()
    {
        Debug.Log("Saindo do jogo...");
        Application.Quit(); // Só funciona no jogo buildado (instalado)
    }
}
