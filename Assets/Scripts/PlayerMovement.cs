using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{

    public float speed = 5000.0f;
    private bool isGrounded = true;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if(gameObject.name == GameObject.Find("Player1").name)
        {
            Vector3 hareketVektoru = new Vector3(Input.GetAxis("Player1_Horizontal"), 0, Input.GetAxis("Player1_Vertical"));
            rb.AddForce(hareketVektoru.normalized*speed*Time.deltaTime);
            if(rb.velocity.y == 0.0f  )
                {
                    isGrounded = true;
            
                }
                else
                {
                    isGrounded = false;
                }

            
            if(Input.GetAxis("Player1_Jump") > 0.0f && isGrounded)
            {
                rb.AddForce(new Vector3(0,800.0f,0), ForceMode.Force);
                
            }
        }

        if(gameObject.name == GameObject.Find("Player2").name)
        {
            Vector3 hareketVektoru = new Vector3(Input.GetAxis("Player2_Horizontal"), 0, Input.GetAxis("Player2_Vertical"));
            rb.AddForce(hareketVektoru.normalized*speed*Time.deltaTime);
            if(rb.velocity.y == 0.0f  )
                {
                    isGrounded = true;
            
                }
                else
                {
                    isGrounded = false;
                }

            
            if(Input.GetAxis("Player2_Jump") > 0.0f && isGrounded)
            {
                rb.AddForce(new Vector3(0,800.0f,0), ForceMode.Force);
            
            }
        }
    }

      
}
