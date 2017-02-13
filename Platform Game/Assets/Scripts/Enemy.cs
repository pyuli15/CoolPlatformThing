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
    }

    // Update is called once per frame
    void Update()
    {
        //supposed to make the enemy walk towards the character
        //transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        if (follow == true)
        {
            followPlayer();

        }
    }
    void followPlayer()
    {
        Vector2 directionToPlayer = player.position - transform.position;
        directionToPlayer.y = 0;
        directionToPlayer.Normalize();

        bool willBeOnGround = Physics2D.Raycast((new Vector2(transform.position.x, transform.position.y) + (directionToPlayer * MoveSpeed)) * Time.deltaTime, Vector2.down, 10, platformLayer);
        if (willBeOnGround)
        {
            //this can be made into its own vector
            transform.position += new Vector3(directionToPlayer.x, directionToPlayer.y, 0) * MoveSpeed * Time.deltaTime;
        }
    }

    public void toggleFollow()
    {      
        follow = !follow;

        if (player == null)
        {
            follow = !follow;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Enemy")
        {
            toggleFollow();
        }
    }
   

}
