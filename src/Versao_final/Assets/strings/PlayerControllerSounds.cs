using UnityEngine;

public class PlayerControllerSounds : MonoBehaviour
{
    [HideInInspector]
    public AudioSource audioSource;

    [HideInInspector]
    public AudioSource audioSourceLoop; // Motor dedicado para sons que se repetem

    [Header("Biblioteca de Sons")]
    public AudioClip somPasso;
    public AudioClip somDanoGeral;
    public AudioClip somMorte;
    public AudioClip somEspinhos;
    public AudioClip somCheckpoint;
    public AudioClip somCura;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        // Cria automaticamente um segundo AudioSource via código só para sons contínuos
        audioSourceLoop = gameObject.AddComponent<AudioSource>();
        audioSourceLoop.loop = true; // Já deixa em loop infinito
        audioSourceLoop.playOnAwake = false;
        audioSourceLoop.outputAudioMixerGroup = audioSource.outputAudioMixerGroup; // Usa o mesmo volume SFX
    }

    public void TocarSomPasso()
    {
        if (somPasso != null)
        {
            audioSource.pitch = Random.Range(0.85f, 1.1f);
            audioSource.PlayOneShot(somPasso, 0.5f);
        }
    }

    public void TocarMorte()
    {
        if (somMorte != null)
        {
            audioSource.pitch = 1.0f;
            audioSource.PlayOneShot(somMorte);
        }
    }

    // --- LÓGICA DE CURA CONTÍNUA ---
    public void IniciarSomCura()
    {
        if (somCura != null)
        {
            // Só aperta o 'Play' se o som já não estiver tocando
            if (!audioSourceLoop.isPlaying)
            {
                audioSourceLoop.clip = somCura;
                audioSourceLoop.Play();
            }
        }
    }

    public void PararSomCura()
    {
        // Só aperta o 'Stop' se estiver tocando algo
        if (audioSourceLoop != null && audioSourceLoop.isPlaying)
        {
            audioSourceLoop.Stop();
        }
    }
}
