using NUnit.Framework;
using UnityEditor.Build.Content;
using UnityEngine;
using System.Collections.Generic;


public class checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerRespawn player = other.GetComponent<PlayerRespawn>();

            if (player != null)
            {
                player.respawnPoint = transform;
                Debug.Log("Checkpoint atualizado!");
            }
        }
    }
}
