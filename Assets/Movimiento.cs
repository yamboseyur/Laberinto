using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public String nombre;
    public float velocidad;

    public float rotacion;
    public Rigidbody fisicas;
    public float fuerzaSalto;
    // Start is called before the first frame update
    void Start()
    {
        fisicas = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal"); 
        var vertical = Input.GetAxis("Vertical");

        var movimiento = new Vector3(horizontal, 0, vertical).normalized *
                                (velocidad * Time.deltaTime);
        transform.Translate(movimiento);

        if (Input.GetKey(KeyCode.Space)) {
            var salto = new Vector3(0, fuerzaSalto, 0);
            fisicas.AddForce(salto);
        }

        var mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(new Vector3(0, mouseX * rotacion * Time.deltaTime, 0));   
    }
}
