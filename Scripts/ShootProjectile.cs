using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShootProjectile : MonoBehaviour {
    public GameObject projectile;//our missle!
    public Transform shootSource;//where the missles come from.
    public int ammo = 5;//how many times we can shoot. will change if you pick up an ammo pack.
    public int score = 0;//your score.
    public Text ammoDisplay;//displays ammo
    public Text scoreDisplay;//displays score.
    public int HP = 1;

    // Use this for initialization
    private void Start() {
        UpdateDisplay();//check if ammo or score has changed.
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Fire1") && ammo > 0)// if I fire and ammo is greater than 0:
        {
            var myProjectile = Instantiate(projectile, shootSource.position, shootSource.rotation);//shoot a missle.
            ammo--;//subtract one from ammo.
            
            UpdateDisplay();//update the display.
        }
    }
    private void OnTriggerEnter(Collider other)// if is touching:
    {
        if (other.tag == "Ammo")// an object tagged ammo:
        {
            score++;// +1 to score.
            ammo += 5;// +5 to ammo
            other.gameObject.SetActive(false);// despawn the ammoPack.
            UpdateDisplay();
            StartCoroutine("ReaspawnAmmo", other.gameObject);//starts a coroutine to respawn a pack after a certain ammount of time.
            IncreaseDifficulty();

        }
        if (other.tag == "WIN!!")
        {
            ammo = ammo + 10;
            score += 20;
            Destroy(other.gameObject);
            IncreaseDifficulty();
            UpdateDisplay();

        }

    }
 IEnumerator ReaspawnAmmo(GameObject AmmoPack){
        yield return new WaitForSeconds(Random.Range(10, 20));//wait a random(10-20) seconds before spawning a new ammo pack.
        AmmoPack.SetActive(true);
    }
    private void IncreaseDifficulty()
    {
        
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");// for each enemy:
        for(var i = 0; i < enemies.Length; i++)
        {
            var myChaser = enemies[i].GetComponent<Chaser>();// access chaser script.
            myChaser.turnSpeed *= 1.1f;//up the turn speed.
            myChaser.chaseSpeed *= 1.1f;//up the chase speed.
        }
    }
    private void UpdateDisplay()
    {
        ammoDisplay.text = ammo.ToString();
        scoreDisplay.text = "Score: " + score;
    }

}
