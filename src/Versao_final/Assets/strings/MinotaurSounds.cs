using UnityEngine;

public class MinotaurSounds : MonoBehaviour
{
    [Header("Motores de Áudio")]
    public AudioSource fontePassos;
    public AudioSource fonteRugido;

    [Header("Arquivos de Som")]
    public AudioClip somPasso;
    public AudioClip somRugido;

    // Chamado pelo Animation Event do Minotauro
    public void TocarPassoMinotauro()
    {
        if (somPasso != null && fontePassos != null)
        {
            // Variação de tom para o passo ser pesado
            fontePassos.pitch = Random.Range(0.7f, 0.9f);
            fontePassos.PlayOneShot(somPasso);
        }
    }

    // Chamado quando o Minotauro detecta o jogador
    public void TocarRugido()
    {
        if (somRugido != null && fonteRugido != null)
        {
            fonteRugido.PlayOneShot(somRugido);
        }
    }
}