using UnityEngine;
public class ShipMovement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float verticalSpeed;
    [SerializeField]private float rotationSpeed;
    private Quaternion deltaRotation;
    private Vector3 dirRotation;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    private void FixedUpdate()
    {
       RotationMove();
       VerticalMove();

    }

    void VerticalMove()
    {
        if (Input.GetKey(KeyCode.Space))
            rb.AddForce(gameObject.transform.up * verticalSpeed * Time.deltaTime, ForceMode.Impulse);
    }

    void RotationMove()
    {
        dirRotation.z=Input.GetAxisRaw("Horizontal");
        dirRotation.x=Input.GetAxisRaw("Vertical");
        deltaRotation = Quaternion.Euler( dirRotation*rotationSpeed * Time.fixedDeltaTime);
        
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
    
    
}
