using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalMeneger : MonoBehaviour
{
    [SerializeField] private string nomeDeLevelDeJogo;
    [SerializeField] private GameObject CanvaSom, CanvaMenu;

    public void Jogar()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void AbrirOpcoes()
    {
        CanvaMenu.SetActive(false);
        CanvaSom.SetActive(true);
        
    }

    public void FecharOpcoes()
    {
        CanvaMenu.SetActive(true);
        CanvaSom.SetActive(false);
       

    }

    public void SairJogo()
    {
        Debug.Log("Fechando o game");
        Application.Quit();

    }
}






