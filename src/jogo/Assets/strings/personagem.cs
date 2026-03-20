using UnityEngine;

public class personagem : MonoBehaviour
{
    public float speed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Transform spawnPoint; //ponto inicial mapa
    public GameObject player;
    void Start()
    {
        Debug.Log("personagem inicio.");
        Instantiate(player, spawnPoint.position, spawnPoint.rotation); //ponto inicial
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetKey(KeyCode.UpArrow)) //movimentações
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
    }
}

