using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class VidaPlayer : MonoBehaviour
{
    public int vidaActual = 3;
    [SerializeField] int vidaTotal;
    [SerializeField] Text textoVida; // Cambiado a Text
    [SerializeField] GameObject panelPlayerMuerto;
    [SerializeField] Vector3 posicionInicial;

    // Start is called before the first frame update
    void Awake()
    {
        vidaActual = vidaTotal;
        posicionInicial = transform.position;
        ActualizarTextoVida();
        panelPlayerMuerto.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ActualizarTextoVida();

        if (vidaActual <= 0)
        {
            print("Murio");
            panelPlayerMuerto.SetActive(true);
            Time.timeScale = 0f;

        }
    }

    public void RestarVida(int restarVida)
    {
        vidaActual -= restarVida;
    }

    public void Reiniciar()
    {
        Debug.Log("Reiniciar llamado");
        Time.timeScale = 1f;
        panelPlayerMuerto.SetActive(false);
        vidaActual = vidaTotal;
        transform.position = posicionInicial;
    }

    private void ActualizarTextoVida()
    {
        textoVida.text = "X " + vidaActual;
    }
}
