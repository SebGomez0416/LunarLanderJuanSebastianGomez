
using UnityEngine;

public class Fuel : MonoBehaviour
{
    [SerializeField]private int fuel;

    public delegate void OutFuel(bool f);
    public static OutFuel OnOutFuel;

    private void OnEnable()
    {
        MoveShip.OnUseFuel += test;
    }
    private void OnDisable()
    {
        MoveShip.OnUseFuel -= test; 
    }

    private void test()
    {
        Debug.Log("entro");
        fuel--;
        if(fuel == 0)
        {
            OnOutFuel?.Invoke(true);
        }       
    }

    public void SetFuel(int f)
    {
        fuel = f;
    }

    public int GetFuel()
    {
         return fuel;
    }
}
