using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGeneration : MonoBehaviour
{
    public GameObject[] ObstaclePrefabs;
    public Transform train;
    public float obstacleSpawnChance = 0.0005f;
    public GameObject currentObstacle;

    // Start is called before the first frame update
    void Start()
    {

    }
    void SpawnObstacle()
    {
        if (currentObstacle == null)
        {
            if (Random.value < obstacleSpawnChance)
            {
                Vector3 obstaclePosition = new Vector3(0, train.position.y + 25, 0);
                GameObject obstacle = Instantiate(ObstaclePrefabs[Random.Range(0, ObstaclePrefabs.Length)], obstaclePosition, Quaternion.identity);
                currentObstacle = obstacle;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        SpawnObstacle();
    }
}
