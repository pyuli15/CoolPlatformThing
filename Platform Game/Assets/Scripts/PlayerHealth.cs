using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    //max health
    public float fullHealth;
    public GameObject bloodFX;
    float currentHealth;

    CharacterMovement controlMovement;

    //HUD Variables
    public Slider healthSlider;


	// Use this for initialization
	void Start ()
    {
        currentHealth = fullHealth;
        controlMovement = GetComponent<CharacterMovement>();

        //HUD Initialization
        healthSlider.maxValue = fullHealth;
        healthSlider.value = fullHealth;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void addDamage(float damage)
    {
        if (damage <= 0) return;
        currentHealth -= damage;
        healthSlider.value = currentHealth;

        if (currentHealth <= 0)
        {
            playerDead();
        }
    }

    public void playerDead()
    {
        Instantiate(bloodFX, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
