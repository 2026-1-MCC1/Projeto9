using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalMeneger : MonoBehaviour
{
    public void Jogar()
    {
        SceneManager.LoadScene("labirinto");
    }
    public void Iniciar()
    {
        SceneManager.LoadScene("Lab2");
    }

    public void AbrirOpcoes()
    {
        SceneManager.LoadScene("opcoes");
    }

    public void VoltarAoMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Sair()
    {
        Application.Quit();
        Debug.Log("teste");
    }
}



