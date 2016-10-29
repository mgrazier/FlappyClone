using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstacleSpawner : MonoBehaviour {

    public GameObject obstacle;
    public GameObject obstacleSpawner;
    public GameObject flappy;

    public List<Transform> childObstacles;

    private float spawnDelay;   // Time between spawns
    private float nextSpawn;    
    private Vector3 newSpawnerPosition;

    private GameObject newObstacle;
    //TODO: randomize obstacle size/position
    private float bottomObstacleScaleY;
    private float topObstaclePositionY;
    private float topObstacleScaleY;
    private float bottomObstaclePositionY;

    // Use this for initialization
    void Start () {
        obstacleSpawner = GameObject.Find("ObstacleSpawner");
        Instantiate(obstacle, obstacleSpawner.transform.position, Quaternion.identity);

        spawnDelay = Random.Range(2f, 3.5f);
        nextSpawn = Time.time + spawnDelay;
	}
	
	// Update is called once per frame
	void Update () {
        // Get Flappy's position and set our obstacle spawner 12 units to the right so it is always offscreen.
        newSpawnerPosition = new Vector3(flappy.transform.position.x, 0f, 0f);
        newSpawnerPosition.x += 12;
        obstacleSpawner.transform.position = newSpawnerPosition;

        // If we've reached our nextSpawn time, spawn a new obstacle.
        if (nextSpawn - Time.time <= 0) {
            
            newObstacle = (GameObject)Instantiate(obstacle, obstacleSpawner.transform.position, Quaternion.identity);
            newObstacle.GetComponentsInChildren<Transform>(childObstacles);
            

            childObstacles[0].localScale.Set(1f, bottomObstacleScaleY, 1f);
            childObstacles[1].localScale.Set(1f, topObstacleScaleY, 1f);

            childObstacles[0].localPosition.Set(1, bottomObstaclePositionY, 1f);
            childObstacles[1].localPosition.Set(1, topObstaclePositionY, 1f);

            spawnDelay = Random.Range(2f, 3.5f);
            nextSpawn = Time.time + spawnDelay;
        }
	}
}
