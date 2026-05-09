using UnityEngine;
using UnityEngine.Audio; // Necessário para o Mixer
using UnityEngine.UI; // Necessário para o Slider

public class ControleVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider slider;

    void Start()
    {
        // Faz o slider começar na posição correta do volume atual
        float valorAtual;
        mixer.GetFloat("MasterVol", out valorAtual);
        slider.value = Mathf.Pow(10, valorAtual / 20);
    }

    public void AlterarVolume(float valorSlider)
    {
        // Converte o valor do slider (0 a 1) para Decibéis (-80 a 0)
        float volumeDb = Mathf.Log10(Mathf.Clamp(valorSlider, 0.0001f, 1f)) * 20;
        mixer.SetFloat("MasterVol", volumeDb);
    }
}