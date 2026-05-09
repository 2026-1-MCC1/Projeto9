using UnityEngine;

public class ProjectileArrow : MonoBehaviour
{
    [Header("Configurações de Voo")]
    public float speed = 15f;
    public float maxDistance = 50f; // Distância máxima antes de resetar (caso não bata em nada)

    private Vector3 startPosition;
    private Quaternion startRotation;
    private bool isFlying = false;

    void Start()
    {
        // Salva a posição e rotação inicial (dentro do lançador)
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    void Update()
    {
        if (isFlying)
        {
            // Move para frente
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            // Se voar demais sem bater em nada, reseta
            if (Vector3.Distance(startPosition, transform.position) > maxDistance)
            {
                ResetArrow();
            }
        }
    }

    // Esta função será chamada pelo seu script de "Timer" ou "TrapManager"
    public void Shoot()
    {
        isFlying = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Se bater em algo que não seja o lançador
        if (!other.CompareTag("Trap"))
        {
            Debug.Log($"Colidiu com {other.name}, voltando para o lançador.");
            ResetArrow();
        }
    }

    void ResetArrow()
    {
        isFlying = false;
        // Teletransporta a flecha de volta para o lugar original
        transform.position = startPosition;
        transform.rotation = startRotation;
    }
}
