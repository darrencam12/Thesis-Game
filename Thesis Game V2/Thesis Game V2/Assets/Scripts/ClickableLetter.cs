using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableLetter : MonoBehaviour
{

    public Transform cubePos;


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        Debug.Log("Clicked");
        gameObject.transform.position = new Vector3(cubePos.position.x, cubePos.position.y, cubePos.position.z);

    }


}
