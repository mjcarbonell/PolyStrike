using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun; 
public class PlayerSetup : MonoBehaviour
{
   [SerializeField]
   public Movement movement;
   public Look look;
   public Jump jump;
   public Crouch crouch;
   public Health health;
   public GameObject camera; 
   

   void Start(){
      IsLocalPlayer(); 
   }
   public void IsLocalPlayer(){
      if (GetComponent<PhotonView>().IsMine)  // Ensure this only runs for the local player
      {
         movement.enabled = true; look.enabled = true; jump.enabled = true; crouch.enabled = true; health.enabled = true; 
         camera.SetActive(true);
      }
      else
      {
         movement.enabled = false;
         look.enabled = false;
         jump.enabled = false;
         crouch.enabled = false;
         camera.SetActive(false);
      }
   //  movement.enabled = true ;
   //  look.enabled = true;
   //  jump.enabled = true;
   //  crouch.enabled = true;
   //  camera.SetActive(true);  
   }
}
