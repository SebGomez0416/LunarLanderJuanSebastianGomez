using UnityEngine;
public class MoveShip : MonoBehaviour
{
    private Rigidbody rb;
    private ParticleSystem fire;
    [SerializeField] private float verticalSpeed;
    [SerializeField]private float rotationSpeed;    
    private Vector3 dirRotation;
    [SerializeField] private float limitRotation;
    public delegate void UseFuel();
    public static UseFuel OnUseFuel;
    private bool outFull;
    private Quaternion deltaRotation;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        fire = GetComponentInChildren<ParticleSystem>();
        Physics.gravity = new Vector3(0, -5f, 0);
    }

    private void OnEnable()
    {
        Fuel.OnOutFuel += OutFuel;
    }

    private void OnDisable()
    {
        Fuel.OnOutFuel -= OutFuel;
    }

    private void FixedUpdate()
    {
       RotationMove();
       VerticalMove();      
    }

    private void VerticalMove()
    {
        if (outFull) return;
        if (!Input.GetKey(KeyCode.Space)) return;
        rb.AddForce(gameObject.transform.up.normalized * verticalSpeed * Time.fixedDeltaTime,ForceMode.Impulse);
        fire.Play();        
        OnUseFuel?.Invoke();
    }

    private void RotationMove()
    {
        dirRotation.z = Input.GetAxisRaw("Horizontal");
        dirRotation.x = Input.GetAxisRaw("Vertical");
        
        deltaRotation=Quaternion.Euler(dirRotation* rotationSpeed * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation* deltaRotation);
        
        // rb.AddTorque(dirRotation* rotationSpeed * Time.fixedDeltaTime);
        
        if(Vector3.Angle(Vector3.up,transform.up)>= limitRotation)
            rb.angularVelocity = Vector3.zero;
    }
    private void OutFuel(bool fuel)
    {
        outFull = fuel;
    }

}
