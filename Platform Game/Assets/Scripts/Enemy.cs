using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform player;
    public float MoveSpeed = 3.0f;
    public GameObject enemyPlatform;
    bool follow = false;
    public LayerMask platformLayer;

    // Use this for initialization
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;
        Debug.Log(player+"");
    }

    // Update is called once per frame
    void Update()
    {
        //supposed to make the enemy walk towards the character
        //transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        if (follow == true)
        {
            FollowPlayer();

        }
    }
    void FollowPlayer()
    {
        if (player != null)
        {
            Debug.Log("player is not null");
            Vector2 directionToPlayer = player.position - transform.position;
            directionToPlayer.y = 0;
            directionToPlayer.Normalize();

            bool willBeOnGround = Physics2D.Raycast((new Vector2(transform.position.x, transform.position.y) + (directionToPlayer * MoveSpeed)) * Time.deltaTime, Vector2.down, 10, platformLayer);

            Debug.Log(willBeOnGround + "");
            if (true)
            {
                
                //this can be made into its own vector
                transform.position += new Vector3(directionToPlayer.x, directionToPlayer.y, 0) * MoveSpeed * Time.deltaTime;
            }
        }
        if (player == null)
        {
            Debug.Log(player + "");
        }
    }

    public void toggleFollow()
    {      
        //follow = !follow;
        Debug.Log("following? " + follow);

        /*if (player == null)
        {
            follow = !follow;
        }
        */
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Platform")
        {
            if (coll.gameObject.GetComponent<platformScript>().playerOnPlatform)
            {
                follow = false;
                Debug.Log("On Platform");
            }
        }
        /*
        if (coll.gameObject.tag == "Enemy")
        {
            toggleFollow();
            
        }
        */
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Platform")
        {
            if (coll.gameObject.GetComponent<platformScript>().playerOnPlatform)
            {
                follow = true;
                Debug.Log("Enemy should be moving");
                
            }
            
        }
        if (coll.collider.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
            Debug.Log("Hit by Something");
        }
    }
   

}
