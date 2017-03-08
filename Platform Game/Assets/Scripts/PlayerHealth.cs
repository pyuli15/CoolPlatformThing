using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {
    //max health
    public float fullHealth;
    public GameObject bloodFX;
    public float damage;
    
 
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
        Instantiate(bloodFX, transform.position, transform.rotation);

        if (currentHealth <= 0)
        {
            playerDead();
        }
        

    }
    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Spike")
        {
            currentHealth -= damage;
            healthSlider.value = currentHealth;
            
        }
        //basically add the element that if the player touches the spike collider that is tagged with spike and remove health that way

        if (coll.tag == "Enemy")
        {
            currentHealth -= damage;
            healthSlider.value = currentHealth;
           

        }
    }



    public void playerDead()
    {
       
        gameOver();
    }

    void gameOver()
    {
        SceneManager.LoadScene(6);
    }
}
