using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class PlayerController : MonoBehaviour
{

    [Header("Movimentação")]
    public float moveSpeed = 18f;
    public float jumpForce = 5f;

    [Header("Mouse")]
    public float mouseSensitivity = 2f; // Sensibilidade costuma ser menor que 5
    public float verticalClamp = 50f;

    [Header("Referências")]
    public Transform cameraContainer;

    private float verticalRotation = 0f;
    public bool isGrounded;

    private Rigidbody rb;

    public float forcaPulo = 10f;
    float multiplicadorQueda = 3f;
    float multiplicadorPulo = 2f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // --- Rotação horizontal (Gira o corpo todo no eixo Y) ---
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0f, mouseX, 0f);

        // --- Rotação vertical (Gira apenas o container da câmera no eixo X) ---
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -verticalClamp, verticalClamp);
        cameraContainer.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);

        // Captura input
        float movimentoX = Input.GetAxis("Horizontal");
        float movimentoZ = Input.GetAxis("Vertical");

        Vector3 movimento = transform.right * movimentoX + transform.forward * movimentoZ;

        // Move o personagem
        Vector3 velocidadeFinal = movimento * moveSpeed;

        rb.linearVelocity = new Vector3(velocidadeFinal.x, rb.linearVelocity.y, velocidadeFinal.z);

        // --- Pulo ---
        float jump = Input.GetAxis("Jump");

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)//--- Quando o chão for detectado e o jogador apertar espaço, ele irá pular
        {
            // Mais controlado que AddForce
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 6f, rb.linearVelocity.z);
        }
    }

    void FixedUpdate()
    {
        // --- Gravidade mais realista ---
        if (rb.linearVelocity.y < 0)
        {
            // Cai mais rápido
            rb.linearVelocity += Vector3.up * Physics.gravity.y * (multiplicadorQueda - 1) * Time.fixedDeltaTime;
        }
        else if (rb.linearVelocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            // Soltou o botão → pulo menor
            rb.linearVelocity += Vector3.up * Physics.gravity.y * (multiplicadorPulo - 1) * Time.fixedDeltaTime;
        }
    }


    // --- Detecção de Chão ---

    //---Qunando o jogador colidir com o chão, isGrounded se torna true
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
        }
    }

    //---Quando o jogador sair do chão, isGrounded se torna false
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = false;
        }
    }

}