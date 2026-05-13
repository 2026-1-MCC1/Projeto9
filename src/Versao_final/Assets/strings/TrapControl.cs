using UnityEngine;
using System.Collections;

public class TrapControl : MonoBehaviour
{
    public ProjectileArrow[] arrowsInScene; // Arraste as 4 flechas da Hierarchy para cá
    public float interval = 2f;

    void Start()
    {
        StartCoroutine(FireRoutine());
    }

    IEnumerator FireRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            foreach (var arrow in arrowsInScene)
            {
                arrow.Shoot();
            }
        }
    }
}
