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
   [SerializeField] private Text Win;
   [SerializeField] private Text scoreText;
   private int score;
   [SerializeField]private int scoreToWin;

   public delegate void ShipDestroy();
   public static ShipDestroy OnShipDestroy;
   private int life=3;   

   private void OnEnable()
   {
       LandShip.OnCrashShip+=Life;
       LandShip.OnAddScore += Score;
   }      
   private void OnDisable()
   {
       LandShip.OnCrashShip-=Life;
        LandShip.OnAddScore -= Score;
   }

    private void Score(int sc)
    {
        score+=sc;
        scoreText.text ="Score:"+ score;
        if (score != scoreToWin) return;
        GameOver();
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
        gameOver.gameObject.SetActive(true);
        if (score != scoreToWin) return;
        Win.gameObject.SetActive(true);
        
   }
    
}
