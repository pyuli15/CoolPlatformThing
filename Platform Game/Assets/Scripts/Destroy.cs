using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //creating a collider that tests to see if an enemy has been hit or not
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "enemy")
        {
            Destroy(gameObject);
        }
    }
}
