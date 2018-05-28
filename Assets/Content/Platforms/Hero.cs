﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour {

    public float speed = 1;
    Rigidbody2D myBody = null;
    // Use this for initialization
    void Start () {
        myBody = this.GetComponent<Rigidbody2D>();
        LevelController.current.setStartPosition(myBody.transform.position);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
    
        float value = Input.GetAxis("Horizontal");
        float valueY = Input.GetAxis("Vertical");
        Animator animator = GetComponent<Animator>();
        
        if ((valueY) > 0)
        {
            Vector2 vel = myBody.velocity;
            vel.y = valueY * speed;

            myBody.velocity = vel;
            animator.SetBool("jump", true);
           
        }
        else
        {
            
            animator.SetBool("jump", false);
        }
            if (Mathf.Abs(value) > 0)
        {
            Vector2 vel = myBody.velocity;
            vel.x = value * speed;
            
            
            myBody.velocity = vel;
           
            animator.SetBool("run", true);
        }
        else
        {
            animator.SetBool("run", false);
        }




        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (value < 0)
        {
            sr.flipX = true;
        }
        else if (value > 0)
        {
            sr.flipX = false;
        }




    }

}
