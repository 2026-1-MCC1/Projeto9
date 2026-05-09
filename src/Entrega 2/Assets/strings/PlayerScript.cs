using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Movimento")]
    public float velocidade = 12f;
    public float forcaPulo = 8f;

    [Header("Câmera")]
    public Transform cameraTransform;
    public float sensibilidadeMouse = 2f;
    public float limiteVertical = 80f;

    [Header("Detecção de Chão (Tag)")]
    public string tagChao = "ground"; // Define a tag aqui ou no Inspector

    private Rigidbody rb;
    private Animator anim; // Referência para o Animator
    private float rotacaoX = 0f;
    private bool estaNoChao;

    void Start()
    {
       

        rb = GetComponent<Rigidbody>();

        anim = GetComponent<Animator>();
        rb.freezeRotation = true;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        rb.interpolation = RigidbodyInterpolation.Interpolate;

        if (rb == null)
            Debug.LogError("ERRO: Rigidbody não encontrado!");
        if (cameraTransform == null)
            Debug.LogError("ERRO: Arraste a Main Camera!");

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Time.timeScale == 0f)
        {
            return;
        }

        ControleMouse();

        // Pulo
        if (Input.GetButtonDown("Jump") && estaNoChao)
            Pular();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void FixedUpdate()
    {
        Movimentar();
    }

    // --- DETECÇÃO POR TAG ---
    private void OnCollisionStay(Collision collision)
    {
        // Se estiver colidindo com algo que tenha a tag configurada
        if (collision.gameObject.CompareTag(tagChao))
        {
            estaNoChao = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Ao sair do contato com o objeto da tag
        if (collision.gameObject.CompareTag(tagChao))
        {
            estaNoChao = false;
        }
    }

    void ControleMouse()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadeMouse;
        transform.Rotate(Vector3.up * mouseX);

        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadeMouse;
        rotacaoX -= mouseY;
        rotacaoX = Mathf.Clamp(rotacaoX, -limiteVertical, limiteVertical);

        if (cameraTransform != null)
            cameraTransform.localRotation = Quaternion.Euler(rotacaoX, 0f, 0f);
    }

    void Movimentar()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 direcao = (transform.forward * moveZ + transform.right * moveX).normalized;
        Vector3 velocidadeAlvo = direcao * velocidade;

        // Mantém a movimentação original solicitada
        rb.linearVelocity = new Vector3(velocidadeAlvo.x, rb.linearVelocity.y, velocidadeAlvo.z);

        // --- LÓGICA DE ANIMAÇÃO ---
        if (anim != null)
        {
            // Calcula a intensidade do movimento (0 parado, 1 em movimento)
            float magnitudeMovimento = new Vector2(moveX, moveZ).sqrMagnitude;
            
            // Define o parâmetro "Velocidade" no Animator
            // Certifique-se de que o nome do parâmetro no Animator seja exatamente "Velocidade"
            anim.SetFloat("Velocidade", magnitudeMovimento);
        }

    }

    void Pular()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        rb.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);

        // Opcional: Força o falso aqui para evitar pulos múltiplos no mesmo frame
        estaNoChao = false;
    }
}