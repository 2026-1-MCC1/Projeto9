using UnityEngine;

public class BirdsController : MonoBehaviour
{
    public Transform centro; // objeto vazio no centro
                             
    public float velocidade = 5f;
    public float rotacao = 50f; 
    void Update() 
    { 
        // Move o pássaro para frente
      transform.Translate(Vector3.forward * velocidade * Time.deltaTime); // Faz ele girar ao redor do centro
                                                                          
      transform.RotateAround(centro.position, Vector3.up, rotacao * Time.deltaTime); 
    } 
}