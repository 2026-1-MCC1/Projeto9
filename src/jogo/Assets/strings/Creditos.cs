using UnityEngine;
using UnityEngine.SceneManagement;

public class Creditos : MonoBehaviour
{
    [SerializeField] private string nomeDeLevelDeJogo;
    [SerializeField] private GameObject CanvaSom, CanvaMenu;

    public void Jogar()
    {
        SceneManager.LoadScene("labirinto");
        Debug.Log("Retornei");

    }
    public void sair()
    {
        Debug.Log("Fechando o game");
        Application.Quit();

    }
}
