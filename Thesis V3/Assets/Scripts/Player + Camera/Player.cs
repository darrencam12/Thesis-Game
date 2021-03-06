﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float walkSpeed = 2;
    public float runSpeed = 6;
    public float jumpHeight = 1;

    public float gravity = -12f;
    public bool respawn;
    float velocityY;
    
    public Vector3 respawnPosition;
    public Vector3 spawnPosition;

    public Transform playerModel;
    public GameObject groundCheck;

    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = gameObject.transform.position;
        respawn = false;
        //Debug.Log(defaultPosition);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = new Vector2(/* Input.GetAxisRaw ("Vertical")*/ 0f, Input.GetAxisRaw("Horizontal"));
        Vector2 inputDir = input.normalized;
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump ();
        }

        if(inputDir != Vector2.zero)
        {
            playerModel.eulerAngles = Vector3.up * Mathf.Atan2 (inputDir.y, 0f ) * Mathf.Rad2Deg;
        }

        bool running = Input.GetKey(KeyCode.LeftShift);
        float speed = ((running) ? runSpeed : walkSpeed) * inputDir.magnitude;

        //transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
        velocityY += Time.deltaTime * gravity;

        Vector3 velocity = transform.forward * speed + Vector3.up * velocityY;
        //controller.Move (velocity * Time.deltaTime);
        //if(controller.isGrounded)
        {
            velocityY = 0;
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

    void Jump(){
        // if(controller.isGrounded)
        // {
        //     float jumpVelocity = Mathf.Sqrt (-2 * gravity * jumpHeight);
        //     velocityY = jumpVelocity;
        // }
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
