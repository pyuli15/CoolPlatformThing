using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

    ProjectileController myPc;

    public float weaponDamage;

	// Use this for initialization
	void Start ()
    {
        myPc = GetComponentInParent<ProjectileController>();

	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    //creating a collider that tests to see if an enemy has been hit or not
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            myPc.removeForce();
            Destroy(gameObject);
        }
        
        if (coll.gameObject.tag == "Enemy")
        {
            enemyHealth hurtEnemy = coll.gameObject.GetComponent<enemyHealth>();
            hurtEnemy.addDamage(weaponDamage);
        }
        
    }
}
