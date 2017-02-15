using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviourSingleton<Global> {
    public static Global me;
    //you type in Global.me.name of variable in order to use it throughout other scripts
    //when you add this scrpt to a manager game object(create one in the hierarcy), you can acess all of the numbers for a 
    //specific variable
    public int numberOfSocks;
    

    private void Awake()
    {
        me = this;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
