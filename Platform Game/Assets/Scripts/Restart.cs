using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {
    

    public GameObject PauseUI;
    private bool paused = false;
	// Use this for initialization
	void Start ()
    {
        PauseUI.SetActive(false);
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetButtonDown("Pause"))
        {
            paused = !paused;
        }

        if (paused)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 1;
        }

        if (!paused)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1;
        }
	}

    public void resume()
    {
        paused = false;
    }

    public void restart()
    {
        if (GUILayout.Button("Restart"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void OnGUI()
    {
        restart();

    }
}
