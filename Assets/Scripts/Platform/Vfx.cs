using System;
using UnityEngine;

public class Vfx : MonoBehaviour
{
   private ParticleSystem smoke;

   private void Awake()
   {
      smoke = GetComponentInChildren<ParticleSystem>();
   }

   private void OnEnable()
   {
      LandShip.OnLandingEffects += Smoke;
   }

   private void OnDisable()
   {
      LandShip.OnLandingEffects -= Smoke;
   }

   private void Smoke(bool isActive)
   {
      
      Debug.Log("particvulas");
      if (isActive)
      {
         smoke.Play();
      }
      else
      {
        // smoke.Stop(); // revisar 
         smoke.Clear();
         smoke.Pause(); 
      }
     
      

   }
}
