using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chaser : MonoBehaviour {
    public float turnSpeed = 30;//how fast we can turn. will increase throughout game.
    public float chaseSpeed = 100;//how fast we can chase the player. will increase throughout game.
    [Range(0f, 1f)] public float torqueDampen = 0.5f;
    private Rigidbody rb;//this is so we can use Rigidbody in the code.
	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();

	}
    void FixedUpdate()
    {
        var target = GameObject.FindGameObjectWithTag("Player");//chase the player.

        Vector3 relativePos = target.transform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(relativePos);
        rb.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.fixedDeltaTime);//turn towards him and start chasing!

        rb.velocity = transform.forward * chaseSpeed * Time.fixedDeltaTime;//move foward toward him
        rb.angularVelocity *= 1 - torqueDampen * Time.fixedDeltaTime;//if cuaght in a explosion, determine the affect.
    }
    // Update is called once per frame
    void Update () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Missle")
        {
            Destroy(gameObject);//if(hits missle) then explode.
        }
 
        if (collision.gameObject.tag == "Player")
        {
           SceneManager.LoadScene(SceneManager.GetActiveScene().name);//if(hits player) start the game again.
        }

    }
}
