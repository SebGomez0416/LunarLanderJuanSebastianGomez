using System;
using UnityEngine;

public class LandShip : MonoBehaviour
{
    [SerializeField]private float distance;
    [SerializeField] private LayerMask collider;
    
    private Rigidbody rb;
    [SerializeField] private float vel_Min;
    [SerializeField] private float vel_Max;
    
    public delegate void ShipDestroy();
    public static ShipDestroy OnShipDestroy;
    public delegate void LandingEffects(bool isActive);
    public static LandingEffects OnLandingEffects;
    [SerializeField]private bool islanding;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
       LandingVFX();
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
           // Debug.Log("exitoso");
        }
        else OnShipDestroy?.Invoke();

        OnLandingEffects?.Invoke(false);
    }

    private void LandingVFX()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, distance, collider))
        {
            
            if (islanding) return;
                islanding = true;
                OnLandingEffects?.Invoke(true);
        } 
        else
        {
            if (!islanding) return;
                islanding = false;
                OnLandingEffects?.Invoke(false);

        }
    }
}
