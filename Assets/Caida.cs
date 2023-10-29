using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Caida : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            MoverJugadorAPosicion();
        }
    }

    private void MoverJugadorAPosicion()
    {
        // Encuentra el objeto del jugador por su tag
        GameObject jugador = GameObject.FindGameObjectWithTag("Player");

        // Verifica si encontramos el objeto del jugador
        if (jugador != null)
        {
            // Cambia la posición del jugador a la posición deseada
            jugador.transform.position = new Vector3(-10.75f, -3.54699993f, 0);
        }
        else
        {
            Debug.LogWarning("No se encontró el objeto del jugador.");
        }
    }
}
