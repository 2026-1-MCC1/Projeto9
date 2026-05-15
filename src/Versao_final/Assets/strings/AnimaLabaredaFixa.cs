using UnityEngine;

public class AnimaLabaredaFixa : MonoBehaviour
{
    private Renderer rend;
    private Transform cameraTransform;

    public int totalFrames = 75;
    public float velocidade = 30f;

    [Header("Configurações de Billboard")]
    [Tooltip("Se ativo, trava o eixo Y para a chama não inclinar para cima/baixo quando a câmera subir.")]
    public bool travarEixoY = true;

    void Start()
    {
        rend = GetComponent<Renderer>();
        
        // Pega a transformação da câmera principal do jogo
        if (Camera.main != null)
        {
            cameraTransform = Camera.main.transform;
        }
        else
        {
            Debug.LogError("Nenhuma Main Camera encontrada na cena! Certifique-se de que sua câmera tem a Tag 'MainCamera'.");
        }
    }

    void Update()
    {
        // 1. SISTEMA DE ANIMAÇÃO (Seu código original)
        int index = (int)(Time.time * velocidade) % totalFrames;
        Vector2 tiling = new Vector2(1f / totalFrames, 1f);
        Vector2 offset = new Vector2((float)index / totalFrames, 0);

        rend.material.SetTextureScale("_MainTex", tiling);
        rend.material.SetTextureOffset("_MainTex", offset);

        // 2. SISTEMA DE BILLBOARD (Garantir que encara a câmera)
        if (cameraTransform != null)
        {
            if (travarEixoY)
            {
                // Calcula a direção ignorando a altura (Y), mantendo a chama reta na parede
                Vector3 direcaoAlvo = cameraTransform.position - transform.position;
                direcaoAlvo.y = 0; // Zera a inclinação vertical

                // Se a direção for válida, rotaciona para encarar a câmera
                if (direcaoAlvo != Vector3.zero)
                {
                    transform.rotation = Quaternion.LookRotation(-direcaoAlvo);
                }
            }
            else
            {
                // Encara a câmera em todos os eixos (360 graus completos)
                transform.LookAt(transform.position + cameraTransform.forward);
            }
        }
    }
}