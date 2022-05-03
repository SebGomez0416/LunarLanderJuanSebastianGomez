using System;
using UnityEngine;

public class LandShip : MonoBehaviour
{
    [SerializeField]private float distance;
    [SerializeField] private LayerMask collider;    
    private Rigidbody rb;    
    [SerializeField] private float vel_Max;    
   
    public delegate void LandingEffects(bool isActive);
    public static LandingEffects OnLandingEffects;

    public delegate void CrashShip();
    public static CrashShip OnCrashShip;

    public delegate void ReFuel();
    public static ReFuel OnReFuel;

    private bool islanding;
    private Vector3 initPos;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        initPos=rb.position;
    }

    private void Update()
    {
       LandingVFX();
    }

    private void OnCollisionEnter(Collision c)
    {       
        if (c.collider.CompareTag("Ground"))
           Crash();
        if (c.collider.CompareTag("Lander"))        
            Landing(c);
        else Crash();
    }

    
    private void Landing(Collision c)
    {
        if (c.relativeVelocity.magnitude <= vel_Max)
        {
            OnReFuel?.Invoke();
        }
        else Crash(); 

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

    private void Crash()
    {
        rb.isKinematic=true;
        OnCrashShip?.Invoke();
        rb.position=initPos;
        rb.rotation=Quaternion.Euler(Vector3.zero);
        rb.isKinematic=false;
    }
}
