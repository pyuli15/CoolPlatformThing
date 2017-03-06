﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    //create a public variabe for the amount of spaces in which the character is going to move
    //public float space;

    //possibly make the character move using the direction of the mouse x?
    //public variable for the mouse x
    public bool jumping;
    public Vector2 velocity;
    public float startY;
    public float gravity;
    public float speed;
    public float curJumpvel;
    public Rigidbody2D character;
    



    // Use this for initialization
    void Start ()
    {
        character = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update()
    {
        //if statement to determine if a button has been pressed
        if (Input.GetKeyDown(KeyCode.A))

        {
            //use rigid body 2d move position
            character.MovePosition(character.position * speed);
            //this refers to the object in which the current script is attatched to
            /*
            Vector3 position = this.transform.position;
            position.x--;
            this.transform.position = position;
            */
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            character.MovePosition(character.position + velocity);

            /*
            Vector3 position = this.transform.position;
            //by putting ++ after the position x, I am able to increment the position of x by one
            position.x++;
            //making the altered position the new position
            this.transform.position = position;
            */
        }
        if (Input.GetKeyDown(KeyCode.Space))
           {
            Jump();

           }
    }
    void Jump()
    {
            if (jumping == false)
            {
                //apply gravity to the situation by subtracting gravity from the speed
                //dynamic speed of the jumping man that we want to change, so we want to subtract the current by the gravity
                curJumpvel -= gravity;
                //seeing of the current position is lower than the start position
            }
            else
            {
            //adding to the y by the current jump velocity
            character.MovePosition(character.position * 3);

            }
            
            
            if (character.position.y <= startY)
                {
                    jumping = false;
                    //move back up to the floor position so that we start back at the original position
                    character.position = new Vector3(character.position.x, startY, 0);

                    //transform.position = new Vector3(1, 0, 0);
                    //print(transform.position.x);

                }
               

            }
    void OnCollisionEnter2D(Collision2D c)
    {
        Debug.Log("hitting something");
        if (c.gameObject.tag == "Platform")
        {
            Debug.Log("hitting PLATFORM");
           // c.gameObject.GetComponent<platformScript>().enemy.GetComponent<Enemy>().toggleFollow();
            
        }
    }


}

    