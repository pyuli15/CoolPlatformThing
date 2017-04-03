using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdsSounds : MonoBehaviour {

    public AudioClip[] animals;

	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayHitSound()
    {
        Sound.me.PlaySound(animals[Random.Range(0, animals.Length)], 1f);
    }
}
