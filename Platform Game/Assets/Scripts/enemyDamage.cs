using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour {
    public float damage;
    public float damageRate;
    //public float pushBackForce;

    float nextDamage;

    // Use this for initialization
    void Start()
    {
        nextDamage = 0f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && nextDamage < Time.time)
        {
            PlayerHealth thePlayerHealth = other.gameObject.GetComponent<PlayerHealth>();
            thePlayerHealth.addDamage(damage);
            nextDamage = Time.time + damageRate;

            //pushBack();

        }
    }
    /*
    void pushBack()
        {
            Vector2 pushDirection = new Vector2(0, 1).normalized;
        pushDirection += pushBackForce;

        }
    */
    }
   









