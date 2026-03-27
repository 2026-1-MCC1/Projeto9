using UnityEngine;
using UnityEngine.SceneManagement;

public class creditos : MonoBehaviour
{
 public void jogarnovamente()
    {
        SceneManager.LoadScene("labirinto");
        Debug.Log("entrou no jogo de novo!");
    }
public void sair()
    {
        Debug.Log("fechando sistema!");
        Application.Quit();
    }






    // Start is called once before the first execution of Update after the MonoBehaviour is created
}

