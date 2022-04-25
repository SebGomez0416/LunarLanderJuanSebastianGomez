
using UnityEngine;

public class DestroyShip : MonoBehaviour
{
    private void OnEnable()
    {
        LandShip.OnShipDestroy += Destroy;
    }

    private void OnDisable()
    {
        LandShip.OnShipDestroy-=Destroy;
    }

    private void Destroy()
    {
       gameObject.SetActive(false);
    }
}
