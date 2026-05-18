using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuGerenciador : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Painéis")]
    public GameObject painelMenu;      // O objeto 'MenuPausa'
    public GameObject botaoAbrir;      // O ícone de 3 traços

    [Header("Configurações")]
    public Slider sliderVolume;
    public AudioMixer mainMixer;

    private bool jogoPausado = false;

    void Start()
    {
        // Garante que o slider comece no volume atual do sistema
        if (sliderVolume != null) sliderVolume.value = AudioListener.volume;

        // Começa o jogo com o menu fechado
        RetomarJogo();
    }

    void Update()
    {
        // Tecla de atalho ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (jogoPausado) RetomarJogo();
            else PausarJogo();
        }
    }

    public void PausarJogo()
    {
        jogoPausado = true;
        painelMenu.SetActive(true);
        botaoAbrir.SetActive(false);

        Time.timeScale = 0f; // Para o tempo do jogo

        // Libera o mouse
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void RetomarJogo()
    {
        Debug.Log("Botão Retomar Clicado!"); // Isso vai nos dizer no Console se o clique funcionou
        jogoPausado = false;
        painelMenu.SetActive(false);
        botaoAbrir.SetActive(true);

        Time.timeScale = 1f; // O tempo PRECISA voltar para 1 para o jogo despausar

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void AjustarVolume(float valor)
    {
        mainMixer.SetFloat("VolumeMaster", Mathf.Log10(valor) * 20);
    }

    public void IrParaMenu()
    {
        Time.timeScale = 1f; // Nunca mude de cena com o tempo parado!
        SceneManager.LoadScene("Menu");
    }

    public void SairDoJogo()
    {
        Application.Quit();
        Debug.Log("O jogo fechou");
    }
}
