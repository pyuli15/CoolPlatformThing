using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    Rigidbody2D rb;
    public float jumpForce;
    public float floorDrag;
    public float airDrag;
    public float floorForce;
    public float airForce;
    public float jumpAggro;
    bool jumpFlag;
    bool onFloor;
    int floorObjs;
    KeyCode jumpButton;
    KeyCode left;
    KeyCode right;

    //for shooting
    public Transform gunTip;
    public GameObject bullet;
    public ParticleSystem Dust;
    float fireRate = 0.5f;
    float nextFire = 0f;

    public AudioClip[] hitSnds;

    private bool facingRight;




    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Dust = GetComponent<ParticleSystem>();
        jumpButton = KeyCode.Z;
        left = KeyCode.LeftArrow;
        right = KeyCode.RightArrow;

        
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            jumpFlag = true;
        }

        //player shooting
        if (Input.GetAxisRaw("Fire1") > 0)
        {
            fireRocket();
        }
    }
    void FixedUpdate()
    {
        if (jumpFlag && onFloor)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if (!Input.GetKey(jumpButton) && rb.velocity.y >= 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Max(rb.velocity.y - jumpAggro, 0));
        }
        float goDir = 0;
        if (Input.GetKey(left)) { goDir--; }
        if (Input.GetKey(right)) { goDir++; }

        if (onFloor)
        {
            rb.AddForce(Vector2.right * floorForce * goDir);
            rb.AddForce(Vector2.left * floorDrag * Mathf.Sign(rb.velocity.x) * Mathf.Pow(rb.velocity.x, 2));
        }
        else
        {
            rb.AddForce(Vector2.right * airForce * goDir);
            rb.AddForce(Vector2.left * airDrag * Mathf.Sign(rb.velocity.x) * Mathf.Pow(rb.velocity.x, 2));
        }
        //drift prevention
        if (Mathf.Abs(rb.velocity.x) < .25f)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        jumpFlag = false;
    }
    void OnTriggerEnter2D(Collider2D c)
    {
        onFloor = true;
        floorObjs++;
    }
    private void OnTriggerExit2D(Collider2D c)
    {
        floorObjs--;
        if (floorObjs <= 0)
        {
            onFloor = false;
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("hitting something");
        if (coll.gameObject.tag == "Platform")
        {
            Debug.Log("hitting PLATFORM");
            Dust.Play();
           

        }
        if (coll.gameObject.tag == "Enemy")
        {
            Debug.Log("Hitting Enemy");
        }

        
    }

    void fireRocket()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
        }
    }

    public void PlayHitSound()
    {
        Sound.me.PlaySound(hitSnds[Random.Range(0, hitSnds.Length)], 1f);
        
    }
}



