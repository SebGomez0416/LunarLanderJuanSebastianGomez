using System;
using UnityEngine;

public class LandingShip : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float vel_Min;
    [SerializeField] private float vel_Max;
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
            Landing();
        }
        else OnShipDestroy?.Invoke(); 
    }

    private void Landing()
    {
        if (rb.velocity.y <= vel_Max && rb.velocity.y >= vel_Min )
        {
            //exitoso  sumar puntaje /cargar gasolina 
            Debug.Log("exitoso");
        }
        else OnShipDestroy?.Invoke();
    }
}
