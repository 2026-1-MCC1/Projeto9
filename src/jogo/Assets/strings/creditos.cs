using UnityEngine;
using UnityEngine.SceneManagement;

public class creditos : MonoBehaviour
{
    //--- Reiniciar o jogo ---
    public void jogarnovamente()
    {
        SceneManager.LoadScene("Lab2");
        Debug.Log("entrou no jogo de novo!");
    }
    //--- Sair do jogo ---
    public void sair()
    {
        Debug.Log("fechando sistema!");
        Application.Quit();
    }

}

