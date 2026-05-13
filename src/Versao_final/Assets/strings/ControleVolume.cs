using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ControleVolume : MonoBehaviour
{
    public AudioMixer meuMixer;

    public void AlterarVolume(float valorSlider)
    {
        // Converte o valor do slider para a escala do Mixer
        // Isso faz com que o som abaixe de forma natural ao ouvido
        meuMixer.SetFloat("MasterVol", Mathf.Log10(valorSlider) * 20);
    }
}