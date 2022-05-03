using UnityEngine;
using UnityEngine.UI;

public class Fuel : MonoBehaviour
{
    [SerializeField]private int fuel;
    [SerializeField] private int reFuel;
    public delegate void OutFuel(bool f);
    public static OutFuel OnOutFuel;
    private Slider fuelBar;

    private void Awake()
    {
        fuelBar = GetComponent<Slider>();        
    }

    private void OnEnable()
    {
        MoveShip.OnUseFuel += UseFuel;
        LandShip.OnReFuel += Reload;
            
    }
    private void OnDisable()
    {
        MoveShip.OnUseFuel -= UseFuel;
        LandShip.OnReFuel -= Reload;
    }

    public void UseFuel()
    {
        fuel++;
        fuelBar.value=fuel;
        if (fuel == fuelBar.maxValue)        
            OnOutFuel?.Invoke(true);               
    }
    public void Reload()
    {        
        fuel -= reFuel;
        if (fuel <= 0)        
            fuel = 0;        
    }    
}
