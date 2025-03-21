using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGeneration : MonoBehaviour
{
    public GameObject[] ObstaclePrefabs;
    public Transform train;
    public float obstacleSpawnChance = 0.25f;
    public GameObject currentObstacle;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle), 1f, 2f);
    }
    void SpawnObstacle()
    {

        if (currentObstacle == null)
        {

            Debug.Log("Spawning Obstacle...");
            Vector3 obstaclePosition = new Vector3(0, train.position.y + 25, 0);
            GameObject obstacle = Instantiate(ObstaclePrefabs[Random.Range(0, ObstaclePrefabs.Length)], obstaclePosition, Quaternion.identity);
            currentObstacle = obstacle;
        }
    }
}
