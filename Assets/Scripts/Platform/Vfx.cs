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
      if (isActive)
         smoke.Play();
      else      
         smoke.Stop();    
      
     
      

   }
}
