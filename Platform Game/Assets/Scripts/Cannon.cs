using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {
    public Transform Destination;
    public PathedProjectile Projectile;

    public float Speed;
    public float FireRate;

    private float nextShotInSeconds;

	// Use this for initialization
	void Start ()
    {
        nextShotInSeconds = FireRate;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if ((nextShotInSeconds -= Time.deltaTime) > 0)
            {
            nextShotInSeconds = FireRate;
            var projectile = (PathedProjectile) Instantiate(Projectile, transform.position, transform.rotation);
            projectile.Initialize(Destination, Speed);
            }
		
	}

    public void OnDrawGizmo()
    {
        if (Destination == null)
        {
            return;
        }

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, Destination.position);
    }
}
