using UnityEngine;

public class TorchFlicker : MonoBehaviour
{
    [Header("Configurações de Intensidade")]
    [SerializeField] private Light torchLight;
    [SerializeField] private float minIntensity = 1.5f;
    [SerializeField] private float maxIntensity = 3.0f;
    
    [Header("Configurações de Suavizado")]
    [Tooltip("Quanto maior o valor, mais rápida e caótica é a oscilação.")]
    [Range(0.01f, 0.2f)] 
    private float flickerSpeed = 0.07f;

    private float targetIntensity;
    private float timer;

    void Start()
    {
        if (torchLight == null)
        {
            torchLight = GetComponent<Light>();
        }
        
        targetIntensity = torchLight.intensity;
    }

    void Update()
    {
        if (torchLight == null) return;

        // Cronômetro para definir a próxima intensidade aleatória
        timer += Time.deltaTime;
        if (timer >= flickerSpeed)
        {
            targetIntensity = Random.Range(minIntensity, maxIntensity);
            timer = 0;
        }

        // Suaviza a transição entre a intensidade atual e o alvo para não ficar piscando como luz estroboscópica
        torchLight.intensity = Mathf.Lerp(torchLight.intensity, targetIntensity, Time.deltaTime * (1f / flickerSpeed));
    }
}