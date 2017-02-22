using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {

    public float rocketSpeed;

    //calling our rigidbody
    Rigidbody2D rb;

	// Use this for initialization
	void Awake ()
    {
        //here we are getting the actual rigid body
        rb = GetComponent <Rigidbody2D>();

        rb.AddForce(new Vector2(1, 0) * rocketSpeed, ForceMode2D.Impulse);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void removeForce()
    {
        rb.velocity = new Vector2(0, 0);
    }
}
