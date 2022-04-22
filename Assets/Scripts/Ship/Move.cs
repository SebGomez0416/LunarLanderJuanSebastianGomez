using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
            rb.AddForce(Vector3.up * speed * Time.deltaTime, ForceMode.Impulse );

    }
    
    
}
