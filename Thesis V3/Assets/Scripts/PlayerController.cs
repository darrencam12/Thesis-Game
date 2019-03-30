using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
   // public Rigidbody theRB;
    public float jumpForce;
    public CharacterController controller;

    
    private Vector3 moveDirection;
    public float gravityScale;
    public bool isFacingRight;

    // Start is called before the first frame update
    void Start()
    {
        //controller = GetComponent<CharacterController>();
        
    }


    // Update is called once per frame
    void Update()
    {
        
         //moveDirection = new Vector3(Input.GetAxis("Horizontal")* moveSpeed, moveDirection.y ,0);

       
        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime); 

        //float moveHorizontal = Input.GetAxis("Horizontal");
 
         Vector3 newPosition = new Vector3(Input.GetAxis("Horizontal")* moveSpeed, moveDirection.y ,0);
         transform.LookAt(newPosition + transform.position);
         transform.Translate(newPosition * moveSpeed * Time.deltaTime, Space.World);

        if(controller.isGrounded)
        {
            if(Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }
            
        }

    }
    
}