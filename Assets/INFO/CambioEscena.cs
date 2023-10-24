using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Primerensayo : MonoBehaviour
{
    private Rigidbody2D rb2D;

    [Header("Movimiento")]

    private float movimientoHorizontal = 0f;
    [SerializeField] private float velocidadDeMovomiento;

    [Range(0, 0.5f)][SerializeField]private float suavizadoDeMovimiento; 
    private Vector3 velocidad = Vector3.zero;
    private bool mirandoDerecha = true;

    [Header("Salto")]
    [SerializeField] private float fuerzaDeSalto;
    [SerializeField] private LayerMask queesSuelo;
    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private Vector3 dimensionesCaja;
    [SerializeField] private bool enSuelo;

    private bool salto = false;

    [Header("Animacion")]
    private Animator animator;

    private void  Start() 
    {
        rb2D= GetComponent<Rigidbody2D>();    
        animator =GetComponent<Animator>();
    }
    private void Update() 
    {
        movimientoHorizontal = Input.GetAxisRaw("Horizontal") * velocidadDeMovomiento;

        animator.SetFloat("Horizontal", Mathf.Abs (movimientoHorizontal));

        if(Input.GetButtonDown("Jump")){
            salto = true;
        }
    }

    private void FixedUpdate() 
    {
        enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCaja, 0f, queesSuelo);
        animator.SetBool("enSuelo",enSuelo);
        //mover
        Mover(movimientoHorizontal * Time.fixedDeltaTime, salto);

        salto = false;
    }

    private void Mover(float mover, bool saltar)
    {
        Vector3 velocidadObjectivo = new Vector2(mover, rb2D.velocity.y);
        rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, velocidadObjectivo, ref velocidad, suavizadoDeMovimiento);

        if(mover>0 && !mirandoDerecha)
        {
            //Girar
            Girar();
        }
        else if(mover<0&&mirandoDerecha)
        {
            //Girar
            Girar();
        }

        if(enSuelo && saltar){
            enSuelo = false;
            rb2D.AddForce(new Vector2(0f, fuerzaDeSalto));
        }
    }

    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(controladorSuelo.position , dimensionesCaja);
    }
}
   
    