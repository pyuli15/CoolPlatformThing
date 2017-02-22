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

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player" && nextDamage < Time.time)
        {
            PlayerHealth thePlayerHealth = coll.gameObject.GetComponent<PlayerHealth>();
            thePlayerHealth.addDamage(damage);
            nextDamage = Time.time + damageRate;

            //pushBack();

        }
    }

}
   









