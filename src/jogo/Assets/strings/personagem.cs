using UnityEngine;

public class personagem : MonoBehaviour
{
    public float speed = 18f;
    private float verticalclamp = 5f;
    private float sensitivity = 5f;
    private float verticalrotation = 50f;
    public Transform cameraContainer;
    public bool isGrounded;
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        rb = GetComponent<Rigidbody>();
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

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            this.GetComponent<Rigidbody>().AddForce(Vector3.up * 10, ForceMode.Impulse);
        } }
        private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
     #endregion
    }


