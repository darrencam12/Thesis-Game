using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttach : MonoBehaviour
{
    //public GameObject Player;
      public void OnTriggerEnter(Collider col)
    {   
       col.transform.parent = gameObject.transform;             
    }
    public void OnTriggerExit(Collider col)
    {
        col.transform.parent = null;
    }
}
