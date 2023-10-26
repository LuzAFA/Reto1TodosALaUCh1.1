using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlayer : MonoBehaviour
{
    [SerializeField] float movimientoPlayer, fuerzaMovimiento=1, fuerzaEmpuje=8, fuerzaSalto=10;

    Rigidbody2D rigidbody;
    SpriteRenderer spriteRenderer;
    

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        movimientoPlayer = Input.GetAxisRaw("Horizontal");
        if (movimientoPlayer != 0) {
            MoverPlayer();
            GiroPlayer();
        }
        if (Input.GetKeyDown(KeyCode.Space)) { EmpujarPlayer(); }
        if (Input.GetKeyDown(KeyCode.UpArrow)) { SaltoPlayer(); }
    }

    public void MoverPlayer() {
        transform.position += Vector3.right * movimientoPlayer * Time.deltaTime * fuerzaMovimiento;
    }

    public void EmpujarPlayer() {
        rigidbody.AddForce(new Vector3(fuerzaEmpuje, 0,0), ForceMode2D.Impulse);
        print("");
    }

    public void SaltoPlayer() {
        rigidbody.AddForce(new Vector3(0, fuerzaSalto, 0), ForceMode2D.Impulse);

    }

    public void GiroPlayer() {
        if (movimientoPlayer > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (movimientoPlayer < 0){
            spriteRenderer.flipX = true;
        }
    }

            
}
