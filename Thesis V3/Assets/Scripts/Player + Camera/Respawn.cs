using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    // Start is called before the first frame update
   //public GameObject player;
  /* [SerializeField] Transform respawnPoint;

   void OnTriggerEnter(Collider Col)
   {
      // Debug.Log(respawnPoint.transform.position);
       //player.transform.position = respawnPoint.transform.position;
       //Debug.Log( player.transform.position);
       if(Col.transform.CompareTag("Player"))
       {
           Debug.Log( respawnPoint.position);
           Col.transform.position = respawnPoint.position;
       }
   } */
     public Vector3 SpawnPoint;
     
     void OnTriggerEnter (Collider col)
     {
         if     (col.tag == "Player")
         {
             col.transform.position = SpawnPoint;
         }
     }

}
