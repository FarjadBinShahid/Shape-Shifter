using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] private GameObject[] obstacles; // array of obstaclesPRefabs

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnObstacles", 2f); //calls SpawnObstacles after 2 seconds
    }


    //spawns random obstacles on random interval of time
    void SpawnObstacles()
    {
        int obstacleIndex = Random.Range(0, obstacles.Length); 
        Instantiate(obstacles[obstacleIndex],  new Vector3(transform.position.x,obstacles[obstacleIndex].transform.position.y, transform.position.z), obstacles[obstacleIndex].transform.rotation);
        float spawnInterval = Random.Range(2f,3f); // random interval time
        Invoke("SpawnObstacles",spawnInterval); // call SpawnObstacles Recursively after spawninterval time
    }



}
