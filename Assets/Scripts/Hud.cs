using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
   [SerializeField] private RawImage life_One;
   [SerializeField] private RawImage life_Two;
   [SerializeField] private RawImage life_Three;
   [SerializeField] private Text gameOver;
   public delegate void ShipDestroy();
   public static ShipDestroy OnShipDestroy;
   private int life=3;


    void Awake()
    {
        //gameOver.enabled=false;
    }
   
   private void OnEnable()
   {
       LandShip.OnCrashShip+=Life;
   }      
   private void OnDisable()
   {
       LandShip.OnCrashShip-=Life;
   }

   private void Life()
   {
       life--;
        switch(life)
        { 
            case 0:
                life_One.enabled=false;
                OnShipDestroy?.Invoke();
                GameOver();
                break;
            case 1:
                life_Two.enabled=false;
                break;
            case 2:
                life_Three.enabled=false;
                break;           
        }

   }

   private void GameOver()
   {
       gameOver.enabled=true;
   }
    
}
