using UnityEngine;

public class PersistenciaAudio : MonoBehaviour
{
    private static PersistenciaAudio instancia;

    void Awake()
    {
        // Verifica se já existe uma música tocando (evita duplicar o som)
        if (instancia != null && instancia != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instancia = this;
        // Faz com que este objeto sobreviva à troca de cenas
        DontDestroyOnLoad(this.gameObject);
    }
}