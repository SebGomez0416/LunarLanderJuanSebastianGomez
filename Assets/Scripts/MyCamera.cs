
using UnityEngine;

public class MyCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offSet;

    private void LateUpdate()
    {
      transform.position = target.position +offSet;
      transform.LookAt(target);
    }
}
