using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {
    Animator anim;
    Rigidbody2D rb;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        anim.SetFloat("speed", Mathf.Abs(rb.velocity.x));
	}
}
