using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logicaMovimiento : MonoBehaviour
{
    [SerializeField] public float velocidadMoviento = 10.0f;
    public float velocidadRotacion = 200.0f;
    private Animator animPersonaje;
    public float x, y;

    private Rigidbody rb;

    public bool estoyAtacando;
    public bool estoyAvanzando;
    public float movimientoAtacando = 1f;

    private Vector3 movimiento;
    private bool enSuelo;


    void Start()
    {
        animPersonaje = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        enSuelo = false;

    }
    void FixedUpdate()
    {
        MovimientoJugador();
    }
    void Update()
    {
        RotarPersonaje();
        AnimarPersonaje();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Atacar();
        }
    }


    void MovimientoJugador()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        movimiento = new Vector3(x, 0f, y);
        movimiento = movimiento.normalized * velocidadMoviento * Time.deltaTime;

        if (enSuelo)
        {
            rb.AddForce(movimiento, ForceMode.VelocityChange);
        }

    }

    void OnCollisionStay(Collision col)
    {
        VerificarSuelo(col);
    }

    void OnCollisionExit(Collision col)
    {
        VerificarSuelo(col);
    }

    void VerificarSuelo(Collision col)
    {
        if (col.gameObject.tag == "Suelo")
        {
            enSuelo = true;
        }
        else
        {
            enSuelo = false;
        }
    }

    void RotarPersonaje()
    {
        transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
        transform.Translate(0, 0, y * Time.deltaTime * velocidadMoviento);
    }

    void AnimarPersonaje()
    {
        animPersonaje.SetFloat("velocidadX", x);
        animPersonaje.SetFloat("velocidadY", y);
    }

    void Atacar()
    {
        animPersonaje.SetTrigger("ataque");
        estoyAtacando = true;
        Debug.Log("Funcion activa");
    }

    public void finAtaque()
    {
        estoyAtacando = false;
        //estoyAvanzando = false;
    }

    public void inicioAvanze()
    {
        estoyAvanzando = true;
    }

    public void finAvanze()
    {
        estoyAvanzando = false;
    }

}