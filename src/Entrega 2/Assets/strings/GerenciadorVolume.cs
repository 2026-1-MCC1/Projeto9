using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GerenciadorVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider slider;

    void Start()
    {
        if (mixer == null || slider == null)
        {
            Debug.LogError("Faltam referências no GerenciadorVolume de " + gameObject.name);
            return;
        }

        // Sincroniza o slider com o volume real do Mixer ao abrir a cena
        if (mixer.GetFloat("MasterVol", out float valorMixer))
        {
            // Converte decibéis para 0.0001 - 1
            slider.value = Mathf.Pow(10, valorMixer / 20);
        }

        // Garante que o slider mude o som
        slider.onValueChanged.AddListener(AlterarVolume);
    }

    public void AlterarVolume(float valorSlider)
    {
        float volumeDb = Mathf.Log10(Mathf.Clamp(valorSlider, 0.0001f, 1f)) * 20;
        mixer.SetFloat("MasterVol", volumeDb);
    }
}