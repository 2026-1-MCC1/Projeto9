using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalMeneger : MonoBehaviour
{
    [SerializeField] private string nomeDeLevelDeJogo;
    [SerializeField] private GameObject CanvaSom, CanvaMenu;
    
 

    //---Carrega a cena do jogo---
    public void Jogar()
    {
        SceneManager.LoadScene("labirinto");
    }

    //---Abre o menu de opções---
    public void AbrirOpcoes() 
    {
        CanvaMenu.SetActive(false);
        CanvaSom.SetActive(true);
        
    }

    //---Fecha o menu de opções---
    public void FecharOpcoes()
    {
        CanvaMenu.SetActive(true);
        CanvaSom.SetActive(false);
       

    }

    //---Fecha o jogo---
    public void SairJogo() 
    {
        Debug.Log("Fechando o game");
        Application.Quit();

    }
}






