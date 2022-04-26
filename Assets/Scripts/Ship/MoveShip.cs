using UnityEngine;
public class MoveShip : MonoBehaviour
{
    private Rigidbody rb;
    private ParticleSystem fire;
    [SerializeField] private float verticalSpeed;
    [SerializeField]private float rotationSpeed;
    private Quaternion deltaRotation;
    private Vector3 dirRotation;
    [SerializeField] private float limitRotation;
    
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        fire = GetComponentInChildren<ParticleSystem>();
    }

    private void FixedUpdate()
    {
       RotationMove();
       VerticalMove();
    }

    void VerticalMove()
    {
        if (!Input.GetKey(KeyCode.Space)) return;
        rb.AddForce(gameObject.transform.up * verticalSpeed * Time.fixedDeltaTime, ForceMode.Impulse);
        fire.Play();
    }

    void RotationMove()
    {
        dirRotation.z = Input.GetAxisRaw("Horizontal");
        dirRotation.x = Input.GetAxisRaw("Vertical");
        
        //rotacion por quaterniones
        //deltaRotation= Quaternion.Euler(dirRotation* rotationSpeed * Time.fixedDeltaTime);
        //rb.MoveRotation(rb.rotation * deltaRotation);
        
        rb.AddTorque(dirRotation* rotationSpeed * Time.fixedDeltaTime);
        
        if(Vector3.Angle(Vector3.up,transform.up)>= limitRotation)
            rb.angularVelocity = Vector3.zero;         

    }

}
