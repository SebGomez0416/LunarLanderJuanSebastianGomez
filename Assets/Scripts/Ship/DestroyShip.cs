
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
       // Debug.Log("estas muerto");
    }
}
