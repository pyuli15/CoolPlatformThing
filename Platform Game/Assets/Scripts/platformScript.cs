using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformScript : MonoBehaviour {
    //public List<GameObject> enemiesOnPlatform = new List<GameObject>();

    public bool playerOnPlatform = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
               
            playerOnPlatform = true;
            
        }
        /*
        if (coll.gameObject.tag == "Enemy")
        {
            enemiesOnPlatform.Add(coll.gameObject);
            Debug.Log("enemies count: " + enemiesOnPlatform.Count);
            Debug.Log("Hitting Platform");

        }
        */
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
             playerOnPlatform = false;
        }
        /*
        if (coll.gameObject.tag == "Enemy")
        {
            enemiesOnPlatform.Remove(coll.gameObject);

        }
        */
    }
}

