using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    // Start is called before the first frame update
   public GameObject player;
   [SerializeField] Transform respawnPoint;

   void OnTriggerEnter(Collider Col)
   {
      // Debug.Log(respawnPoint.transform.position);
       //player.transform.position = respawnPoint.transform.position;
       //Debug.Log( player.transform.position);
       if(Col.transform.CompareTag("Player"))
       {
           //Debug.Log( respawnPoint.position);
           player.transform.position = respawnPoint.transform.position;
       }
   } 

    
}   
