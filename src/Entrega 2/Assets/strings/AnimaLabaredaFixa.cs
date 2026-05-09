using UnityEngine;

public class AnimaLabaredaFixa : MonoBehaviour
{
    private Renderer rend;
    public int totalFrames = 75;
    public float velocidade = 30f;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        // Calcula o frame atual
        int index = (int)(Time.time * velocidade) % totalFrames;

        // No shader "Particles/Standard Unlit", usamos o _MainTex
        // Escala: 1 dividido por 75 frames no eixo X, e 1 (inteiro) no eixo Y
        Vector2 tiling = new Vector2(1f / totalFrames, 1f);

        // Offset: Move o "quadrado de visão" para o frame atual
        Vector2 offset = new Vector2((float)index / totalFrames, 0);

        // Aplica ao material
        rend.material.SetTextureScale("_MainTex", tiling);
        rend.material.SetTextureOffset("_MainTex", offset);
    }
}