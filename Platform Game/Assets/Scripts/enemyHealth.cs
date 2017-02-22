using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour {

    public float fullHealth;
    public float damage;
    float daEnemyHealth;

    // Use this for initialization
    void Start ()
    {

        //enemy health
        daEnemyHealth = fullHealth;

    }

    // Update is called once per frame
    void Update ()
    {
		
	}

    public void addDamage(float damage)
    {
        //controlling enemy damage
        daEnemyHealth -= damage;
        if (daEnemyHealth <= 0)
        {
            makeDead();
        }

    }

    void makeDead()
    {
        Destroy(gameObject);
    }
}
