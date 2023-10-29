using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MovimientoPlayer : MonoBehaviour
{
    [SerializeField] float movimientoPlayer, fuerzaMovimiento = 1, fuerzaSalto = 10;
    private bool enElSuelo = false;
    //private bool atacando = false;

    private Rigidbody2D myRigidBody;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        movimientoPlayer = Input.GetAxisRaw("Horizontal");

        if (movimientoPlayer != 0)
        {
            MoverPlayer();
            GiroPlayer();
            animator.SetBool("EstaCaminando", true);
        }
        else
        {
            animator.SetBool("EstaCaminando", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && enElSuelo)
        {
            Atacar();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && enElSuelo)
        {
            SaltoPlayer();
            enElSuelo = false;
        }

        // Resto del código
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enElSuelo = true;
            animator.SetBool("Atacando", false); // Resetea la animación de ataque al tocar el suelo
        }
    }

    public void MoverPlayer()
    {
        transform.position += Vector3.right * movimientoPlayer * Time.deltaTime * fuerzaMovimiento;
    }

    public void Atacar()
    {
        animator.SetTrigger("Atacando");
        // Puedes agregar lógica adicional aquí, como aplicar fuerzas al atacar
    }

    public void SaltoPlayer()
    {
        myRigidBody.AddForce(new Vector2(0, fuerzaSalto), ForceMode2D.Impulse);
        animator.SetTrigger("Salto");
    }

    public void GiroPlayer()
    {
        if (movimientoPlayer > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (movimientoPlayer < 0)
        {
            spriteRenderer.flipX = true;
        }
    }
}
