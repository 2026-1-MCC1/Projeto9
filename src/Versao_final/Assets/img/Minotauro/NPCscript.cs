using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NPCscript : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;
    private Animator animator;

    [Header("Ativação")]
    public bool ativo = false;

    [Header("Movimento")]
    public float velocidadeRotacao = 10f;
    public float suavizacaoRotacao = 5f;

    [Header("Ataque")]
    public float distanciaAtaque = 2f;
    public float distanciaAnimacaoAtaque = 4f; // começa a animação antes de chegar perto
    public float danoAtaque = 10f;
    public float intervaloAtaque = 1.5f;
    private float timerAtaque = 0f;

    private Vector3 velocidadeAnterior;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();

        if (animator != null)
            animator.applyRootMotion = false;

        // ESSENCIAL: desativa rotação automática do NavMesh Agent
        // para a gente controlar manualmente com mais precisão
        agent.updateRotation = false;

        // Começa parado
        agent.isStopped = true;
    }

    void Update()
    {
        if (!ativo || player == null) return;

        float distancia = Vector3.Distance(transform.position, player.position);
        timerAtaque -= Time.deltaTime;

        if (distancia <= distanciaAtaque)
        {
            agent.isStopped = true;

            // Vira para o player ao atacar
            VirarPara(player.position);

            if (timerAtaque <= 0f)
            {
                Atacar();
                timerAtaque = intervaloAtaque;
            }
        }
        else if (distancia <= distanciaAnimacaoAtaque)
        {
            // Zona intermediária: caminha em direção ao player com animação de ataque ativa
            agent.isStopped = false;
            agent.SetDestination(player.position);
            RotacaoSuave();

            if (animator != null)
                animator.SetBool("IsAttacking", true);
        }
        else
        {
            agent.isStopped = false;
            agent.SetDestination(player.position);

            if (animator != null)
                animator.SetBool("IsAttacking", false);

            RotacaoSuave();
        }

        if (animator != null)
            animator.SetFloat("Speed", agent.velocity.magnitude);
    }

    public void Ativar()
    {
        ativo = true;
        agent.isStopped = false;
        Debug.Log("Minotauro ativado!");
    }

    void RotacaoSuave()
    {
        // Pega a direção real que o agente está indo
        Vector3 velocidade = agent.velocity;
        velocidade.y = 0f;

        if (velocidade.sqrMagnitude < 0.01f) return;

        // Suaviza a direção para não tremer
        Vector3 direcaoSuave = Vector3.Lerp(velocidadeAnterior, velocidade, Time.deltaTime * suavizacaoRotacao).normalized;
        velocidadeAnterior = direcaoSuave;

        // Aplica a rotação com velocidade controlada
        Quaternion rotacaoAlvo = Quaternion.LookRotation(direcaoSuave);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotacaoAlvo, velocidadeRotacao * 60f * Time.deltaTime); // graus por segundo
    }

    void VirarPara(Vector3 alvo)
    {
        Vector3 direcao = (alvo - transform.position);
        direcao.y = 0f;

        if (direcao.sqrMagnitude < 0.01f) return;

        Quaternion rotacaoAlvo = Quaternion.LookRotation(direcao);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotacaoAlvo, velocidadeRotacao * 60f * Time.deltaTime);
    }

    void Atacar()
    {
        if (animator != null)
            animator.SetBool("IsAttacking", true);
    }
}
