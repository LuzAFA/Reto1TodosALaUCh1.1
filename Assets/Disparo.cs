using System.Collections;
using UnityEngine;

public class Disparo: MonoBehaviour
{
    public GameObject proyectilPrefab; // Prefab del proyectil que dispara el enemigo
    public Transform puntoDisparo; // Punto desde donde se dispara el proyectil
    public float tiempoEntreDisparos = 5f;
    public float tiempoDeVida = 1f;
    public float velocidadBala = 10f; // Nueva: velocidad de la bala

    //bool disparando;

    private void Start()
    {
        // Comienza a disparar después de un breve retraso (por ejemplo, 2 segundos)
        InvokeRepeating("Disparar", 2f, tiempoEntreDisparos);
    }

    private void Update()
    {
        //if (disparando)
        //{

        //}
    }
    private void Disparar()
    {
        //disparando = true;
        // Crea el proyectil en el punto de disparo
        GameObject nuevaBala = Instantiate(proyectilPrefab, puntoDisparo.position, puntoDisparo.rotation);

        // Obtiene el Rigidbody del proyectil
        Rigidbody2D rigidbodyBala = nuevaBala.GetComponent<Rigidbody2D>();

        // Aplica la velocidad inicial al proyectil
        rigidbodyBala.velocity = (puntoDisparo.right *-1) * velocidadBala;

        // Destruye la bala después de tiempoDeVida segundos
        Destroy(nuevaBala, tiempoDeVida);
    }

    //private IEnumerator ShootDestroy()
    //{
    //    yield return new WaitForSeconds(4f);
    //    disparando = false;
    //    Destroy(GameObject.nuevaBala);
    //}
}
