using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {
    private Rigidbody rb;//make it a Ridgidbody.
    public GameObject explosion;//when this explodes, we need an explosion so this summons one.
    public float speed;// how fast we can fly.
    public float lifeTime;//how long this missle will stay alive before detonating.
    public float explodeLifeTime;//how long the explosion is.
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;//move
        Destroy(gameObject, lifeTime);//destroy if lifeTime is above value.
	}

    private void OnCollisionEnter(Collision collision)// if this collides with an object:
    {
        GameObject myExplode = Instantiate(explosion, transform.position, Quaternion.identity);//create an explosion
        Destroy(gameObject, t: explodeLifeTime);//destroy the explosion after the life time for it is up.
        Destroy(gameObject);//destroy the missle
    }



    // Update is called once per frame
    void Update () {
		
	}
}
