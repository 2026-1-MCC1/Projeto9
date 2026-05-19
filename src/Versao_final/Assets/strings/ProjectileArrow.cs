using UnityEngine;

public class ProjectileArrow : MonoBehaviour
{
    [Header("Configurações de Voo")]
    public float speed = 15f;
    public float maxDistance = 50f;

    private Vector3 startPosition;
    private Quaternion startRotation;
    private bool isFlying = false;

    // --- ADIÇÃO: Referência do Som ---
    private AudioSource audioSource;

    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;

        // --- ALTERAÇÃO: Pega o componente Audio Source nos objetos filhos (o seu empty 'som') ---
        audioSource = GetComponentInChildren<AudioSource>();
    }

    void Update()
    {
        if (isFlying)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            if (Vector3.Distance(startPosition, transform.position) > maxDistance)
            {
                ResetArrow();
            }
        }
    }

    public void Shoot()
    {
        isFlying = true;

        // --- ADIÇÃO: Toca o som exatamente no momento em que a flecha é disparada ---
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Trap"))
        {
            ResetArrow();
        }
    }

    void ResetArrow()
    {
        isFlying = false;
        transform.position = startPosition;
        transform.rotation = startRotation;

        // Opcional: Se o som da flecha for muito longo, ele corta o som quando ela bate na parede
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}