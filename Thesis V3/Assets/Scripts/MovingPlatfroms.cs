using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatfroms : InteractableObject
{

    public Transform movingPlatforms;

    public Transform position1;

    public Transform position2;

    private Vector3 targetPosition;

    public bool disableOnStart = false;

    public float speed;

    public float resetTime;
    
    // Start is called before the first frame update
    void Start()
    {
        targetPosition = position1.position;
        ChangeTarget();
        if (disableOnStart) Deactivate();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        movingPlatforms.position = Vector3.MoveTowards(movingPlatforms.position, targetPosition, speed * Time.deltaTime);

        if (Vector3.Distance(targetPosition, movingPlatforms.position) <= 0.1f)
        {
            ChangeTarget();
        }
    }

    public override void Activate()
    {
        enabled = true;
    }

    public override void Deactivate()
    {
        enabled = false;
    }

    void ChangeTarget()
    {
        if (targetPosition.Equals(position1.position))
        {
            targetPosition = position2.position;
        }
        else
        {
            targetPosition = position1.position;
        }
        // Invoke("ChangeTarget", resetTime);
    }     
    
    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 1f, 1f, 0.5f);

        if (position1 != null)
        {
            Gizmos.DrawWireCube(position1.position, Vector3.one * 1f);
        }

        if (position2 != null)
        {
            Gizmos.DrawWireCube(position2.position, Vector3.one * 1f);
        }

        if (position1 != null && position2 != null)
        {
            Gizmos.DrawLine(position1.position, position2.position);
        }
    }
}
