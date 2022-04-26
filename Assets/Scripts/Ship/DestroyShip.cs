
using UnityEngine;

public class DestroyShip : MonoBehaviour
{
    private void OnEnable()
    {
        Hud.OnShipDestroy += Destroy;
    }
    private void OnDisable()
    {
        Hud.OnShipDestroy-=Destroy;
    }
   
    private void Destroy()
    {
       gameObject.SetActive(false);
    }
}
