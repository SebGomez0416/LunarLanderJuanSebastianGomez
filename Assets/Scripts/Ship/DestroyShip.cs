
using UnityEngine;

public class DestroyShip : MonoBehaviour
{
    private void OnEnable()
    {
        LandingShip.OnShipDestroy += Destroy;
    }

    private void OnDisable()
    {
        LandingShip.OnShipDestroy-=Destroy;
    }

    private void Destroy()
    {
        Debug.Log("estas muerto");
    }
}
