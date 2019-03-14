using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float movementSpeed;
    public Rigidbody theRB;
    public float JumpForce;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        theRB.velocity = new Vector3(Input.GetAxis("Horizontal") * movementSpeed, theRB.velocity.y, Input.GetAxis("Vertical") * movementSpeed);

        if(Input.GetButtonDown("Jump"))
        {
            theRB.velocity = new Vector3(theRB.velocity.x, JumpForce, theRB.velocity.z);
        }
    }
}
