using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour {

    Rigidbody2D rb;
    public AudioSource source;
    public AudioClip mural;
    public AudioClip roof;
    public AudioClip jump;
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
    //public Transform gunTip;
    public GameObject bullet;
    public GameObject Dust;
    public GameObject sparks;
    public Text countText;
    float fireRate = 0.5f;
    float nextFire = 0f;

    public AudioClip[] hitSnds;

    private bool facingRight;
    private int count;
    




    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpButton = KeyCode.Z;
        left = KeyCode.LeftArrow;
        right = KeyCode.RightArrow;
        count = 0;
        SetCountText();
        
        
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            jumpFlag = true;
        }
        /*
                //player shooting
                if (Input.GetAxisRaw("Fire1") > 0)
                {
                    fireRocket();
                }

        */
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

        if (c.gameObject.tag == "Mural")
        {
            source.PlayOneShot(mural);
            Instantiate(sparks, transform.position, transform.rotation);
            count = count + 1;
            SetCountText();
        }
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
            Instantiate(Dust, transform.position, transform.rotation);


        }
        if (coll.gameObject.tag == "Enemy")
        {
            Debug.Log("Hitting Enemy");
        }

        if (coll.gameObject.tag == "Metal")
        {
            source.PlayOneShot(roof);
        }

        if (coll.gameObject.tag == "Tramp")
        {
            source.PlayOneShot(jump);
        }


    }

    /*
    void fireRocket()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
        }
    }
    */

    public void PlayHitSound()
    {
        Sound.me.PlaySound(hitSnds[Random.Range(0, hitSnds.Length)], 1f);
        
    }

    void SetCountText()
    {
        countText.text = "Murals Found: " + count.ToString();
    }
}



