using UnityEngine;

public class personagem : MonoBehaviour
{
    public float speed = 18f;
    private float verticalclamp = 5f;
    private float sensitivity = 5f;
    private float verticalrotation = 50f;
    public Transform cameraContainer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()

    {
        #region Rotações de mouse
        Cursor.lockState = CursorLockMode.Locked;

        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0f, mouseX, 0f);

        float mouseY = Input.GetAxis("Mouse Y");
        verticalrotation -= mouseY;
        verticalrotation -= Mathf.Clamp(verticalrotation, -verticalclamp, verticalclamp);


        #endregion



        #region Movimentos de Personagem
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float jump = Input.GetAxis("Jump");
        Vector3 direction = transform.right * h + transform.forward * v;
        transform.position += direction * speed * Time.deltaTime;

        }
    }

 
     #endregion
    


