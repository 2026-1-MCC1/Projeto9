using UnityEngine;

public class ZonaAtivacao : MonoBehaviour
{
    public NPCscript npc;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            npc.Ativar();
            Debug.Log("Player entrou na zona — minotauro ativado!");
        }
    }
}