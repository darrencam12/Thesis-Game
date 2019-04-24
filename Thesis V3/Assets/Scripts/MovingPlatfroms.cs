using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatfroms : MonoBehaviour
{

    public Transform movingPlatforms;
    public Transform position1;
    public Transform position2;
    public Vector3 newPosition;
    public string currentState;
    public float smooth;
    public float resetTime;

    public static bool paltformActivate = false;
    
    // Start is called before the first frame update
    void Start()
    {
        ChangeTarget();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(paltformActivate == true)
        {
            movingPlatforms.position = Vector3.Lerp(movingPlatforms.position, newPosition,smooth * Time.deltaTime);
        }
    }
    void ChangeTarget()
    {
        
            if(currentState == "Moving to Postion 1")
            {
                currentState = "Moving to Postion 2";
                newPosition = position2.position;
            }
            else if(currentState == "Moving to Postion 2")
            {
                currentState = "Moving to Postion 1";
                newPosition = position1.position;
            }
            else if(currentState == "")
            {
                currentState = "Moving to Postion 2";
                newPosition = position2.position;
            }
            Invoke("ChangeTarget", resetTime);
            }
        
}
