using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour {
    public GameObject enemy;// the enemy.
    public float spawnTime = 3f;//time to spawn.
    public Transform[] spawnPoints;//the number of point at wich the zombies will spawn.
	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawn", spawnTime, spawnTime);//spawn the zombies every time spawnTime is up.
	}
    void Spawn()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);// make a zombie at the location and rotation of the spawnPoint.
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
