using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform player;
 

    //Update is called once per frame
    void Update()
    {
        // From actual position to destination with "constant" t
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
    /*
    void Update()
    {
        Vector2 pos = Vector2.Lerp((Vector2)transform.position, (Vector2)target.transform.position, Time.deltaTime);
        transform.position = new Vector3(pos.x, pos.y, transform.position.y);
    }
    */
}
