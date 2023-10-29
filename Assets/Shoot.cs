using System.Collections;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private void Update()
    {
        StartCoroutine(DestruirBala());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Obtener la referencia al script VidaPlayer en el objeto colisionado
        VidaPlayer vidaPlayer = collision.gameObject.GetComponent<VidaPlayer>();

        // Verificar si el script VidaPlayer existe antes de intentar usarlo
        if (vidaPlayer != null && collision.gameObject.CompareTag("Player"))
        {
            // Destruir la bala
            Destroy(gameObject);

            // Restar vida al jugador
            vidaPlayer.RestarVida(1);
        }
    }

    IEnumerator DestruirBala()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }    
}
