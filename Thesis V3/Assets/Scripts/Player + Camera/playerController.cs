using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    
    public float speed;
    public float jumpForce;
    private float moveInput;
    private Rigidbody Rb;

    public bool isGrounded;
    public bool respawn;
    public Vector3 respawnPosition;
    public Vector3 spawnPosition;


    //public Transform groundCheck;
    //public float checkRaidus;
    //public LayerMask whatIsGround;

    //private int extraJumps;
    //public int extraJumpsValue;
    
    private bool facingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = gameObject.transform.position;
        isGrounded = false;
        //extraJumps = extraJumpsValue;
        Rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //isGrounded = Physics2D.OverlapCircle(groundCheck.position,checkRaidus,whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        Rb.velocity = new Vector2(moveInput * speed,Rb.velocity.y);
        if(facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if(facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }
    void Update()
    {
        /* if(isGrounded == true && Input.GetKeyDown(KeyCode.UpArrow))
        {
            extraJumps = extraJumpsValue;
            Rb.velocity = Vector2.up * jumpForce;
        }
         if(Input.GetKeyDown(KeyCode.UpArrow)&& extraJumps > 0)
        {
            
            extraJumps--;
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow)&& extraJumps == 0 && isGrounded == true)
        {
            Rb.velocity = Vector2.up * jumpForce;
        }*/
       
        if(Input.GetKeyDown(KeyCode.UpArrow)  && isGrounded == true)
        {
            Rb.velocity = Vector2.up * jumpForce;
        }
        if(Input.GetKeyDown(KeyCode.W)  && isGrounded == true)
        {
            Rb.velocity = Vector2.up * jumpForce;
        }
        if(Input.GetKeyDown(KeyCode.Space)  && isGrounded == true)
        {
            Rb.velocity = Vector2.up * jumpForce;
        }

        if (respawn)
        {
            if (respawnPosition == null)
            {
                transform.position = spawnPosition;
                respawn = false;
            }
            else
            {
                transform.position = new Vector3(respawnPosition.x,respawnPosition.y+3,respawnPosition.z);
                respawn = false;
            }
            
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
     void OnCollisionEnter(Collision col) 
    {
        if(col.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            //print("ground");
        }
    }
    void OnCollisionExit(Collision col) 
    {
        if(col.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            //print("notground");
        }
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Checkpoint")
        {
            respawnPosition = gameObject.transform.position;
            Debug.Log(respawnPosition);
        }
        if (other.tag == "Deathwall")
        {    
            respawn = true;
            Debug.Log("Respawned");
        }
        
    }
    
}
