using UnityEngine;

public class WaterFlowURP : MonoBehaviour
{
    public float speedX = 0.05f;
    public float speedY = 0.05f;
    private Material waterMat;

    void Start()
    {
        // Pega o material instanciado para não afetar o asset original no projeto
        waterMat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        float offsetX = Time.time * speedX;
        float offsetY = Time.time * speedY;

        // No URP, a propriedade principal geralmente é _BaseMap_ST ou _MainTex
        // Esse comando desloca a textura continuamente
        waterMat.SetTextureOffset("_BaseMap", new Vector2(offsetX, offsetY));
    }
}