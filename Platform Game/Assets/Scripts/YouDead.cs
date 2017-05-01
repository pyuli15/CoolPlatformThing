using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouDead : MonoBehaviour {
    public AudioSource source;
    public AudioClip hover;
    public AudioClip click;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void BackToFirst()
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
