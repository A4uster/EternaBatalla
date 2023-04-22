using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float velocidadMoviento = 5.0f;
    public float velocidadRotacion = 200.0f;
    private Animator animPersonaje;
    public float x, y ;
    // Start is called before the first frame update
    void Start()
    {
        animPersonaje = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        //Linea de comando de personaje
        x= Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
        transform.Translate(0, 0, y * Time.deltaTime * velocidadMoviento);

        animPersonaje.SetFloat("VelX", x);
        animPersonaje.SetFloat("VelY", y);
    }
}
