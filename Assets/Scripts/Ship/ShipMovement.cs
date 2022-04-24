using UnityEngine;
public class ShipMovement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float verticalSpeed;
    [SerializeField]private float rotationSpeed;
    private Quaternion deltaRotation;
    private Vector3 dirRotation;

    [SerializeField] private float max;
    [SerializeField] private float min;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
       RotationMove();
       VerticalMove();
       Debug.Log(rb.velocity.y);
    }

    void VerticalMove()
    {
        if (Input.GetKey(KeyCode.Space))
            rb.AddForce(gameObject.transform.up * verticalSpeed * Time.fixedDeltaTime, ForceMode.Impulse);
    }

    void RotationMove()
    {
        dirRotation.z = Input.GetAxisRaw("Horizontal");
        dirRotation.x = Input.GetAxisRaw("Vertical");
        deltaRotation= Quaternion.Euler(dirRotation* rotationSpeed * Time.fixedDeltaTime);
        
        rb.MoveRotation(rb.rotation * deltaRotation);
        
        //rb.rotation=Quaternion.Euler(Mathf.Clamp(rb.rotation.eulerAngles.x,min,max), rb.rotation.eulerAngles.y, rb.rotation.eulerAngles.z);
        
        
        /*rb.rotation= Quaternion.Euler(Mathf.Clamp(rb.rotation.eulerAngles.x,min,max),
            rb.rotation.eulerAngles.y,Mathf.Clamp(rb.rotation.eulerAngles.z,min,max));*/

    }

}
