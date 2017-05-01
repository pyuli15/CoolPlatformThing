using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Begin : MonoBehaviour {
    public AudioSource source;
    public AudioClip hover;
    public AudioClip click; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartScreen()
    {
        SceneManager.LoadScene(1);
    }

    public void OnHover()
    {
        source.PlayOneShot(hover);
    }

    public void OnClick()
    {

        source.PlayOneShot(click);
    }

}
