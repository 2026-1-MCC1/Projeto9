using UnityEngine;
using UnityEngine.SceneManagement;

public class ControleVolume : MonoBehaviour // O nome deve ser igual ao arquivo!
{
    private static ControleVolume instancia;

    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void OnEnable() { SceneManager.sceneLoaded += AoCarregarCena; }
    void OnDisable() { SceneManager.sceneLoaded -= AoCarregarCena; }

    void AoCarregarCena(Scene cena, LoadSceneMode modo)
    {
        // Para a música se entrar nessas cenas (letras minúsculas!)
        if (cena.name == "labirinto" || cena.name == "saida")
        {
            Destroy(gameObject);
        }
    }
}