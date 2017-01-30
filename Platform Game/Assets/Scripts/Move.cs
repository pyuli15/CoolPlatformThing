using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    //create a public variabe for the amount of spaces in which the character is going to move
    //public float space;

    //possibly make the character move using the direction of the mouse x?
    //public variable for the mouse x
    public bool jumping;
    public float curJumpvel;
    float startY;
    public float gravity;



    // Use this for initialization
    void Start ()
    {
		
	}

    // Update is called once per frame
    void Update()
    {
        //if statement to determine if a button has been pressed
        if (Input.GetKeyDown(KeyCode.LeftArrow))

        {
            //this refers to the object in which the current script is attatched to
            Vector3 position = this.transform.position;
            position.x--;
            this.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector3 position = this.transform.position;
            //by putting ++ after the position x, I am able to increment the position of x by one
            position.x++;
            //making the altered position the new position
            this.transform.position = position;
        }
    }
    void Jump()
    {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //adding to the y by the current jump velocity
                transform.position += new Vector3(0, curJumpvel, 0);
                //apply gravity to the situation by subtracting gravity from the speed
                //dynamic speed of the jumping man that we want to change, so we want to subtract the current by the gravity
                curJumpvel -= gravity;
                //seeing of the current position is lower than the start position
            }
            /*
            if (transform.position.y <= startY)
                {
                    jumping = false;
                    //move back up to the floor position so that we start back at the original position
                    transform.position = new Vector3(transform.position.x, startY, 0);

                    //transform.position = new Vector3(1, 0, 0);
                    //print(transform.position.x);

                }
                */

            }
        }

    