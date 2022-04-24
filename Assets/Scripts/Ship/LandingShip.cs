using System;
using UnityEngine;

public class LandingShip : MonoBehaviour
{
    private Rigidbody rb;
    public delegate void ShipDestroy();
    public static ShipDestroy OnShipDestroy;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision c)
    {
        if (c.collider.CompareTag("Ground"))
            OnShipDestroy?.Invoke(); 
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.CompareTag("Lander"))
        {
            Debug.Log(rb.velocity.y);
            Landing();
        }
        else OnShipDestroy?.Invoke(); 
    }

    private void Landing()
    {
        if (rb.velocity.y <= 2 && rb.velocity.y >=-2 )
        {
            //exitoso  sumar puntaje /cargar gasolina 
            Debug.Log("exitoso");
        }
        else OnShipDestroy?.Invoke();
    }
}
