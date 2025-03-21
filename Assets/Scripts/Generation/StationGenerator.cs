using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationGenerator : MonoBehaviour
{
    public GameObject[] StationPrefabs;
    public Transform train;
    public float stationSpawnRate = 0.0005f;
    public GameObject currentObstacle;

    // Start is called before the first frame update
    void Start()
    {

    }
    void SpawnObstacle()
    {
        if (currentObstacle == null)
        {
            if (Random.value < stationSpawnRate)
            {
                Vector3 obstaclePosition = new Vector3(0, train.position.y + 15, 0);
                GameObject obstacle = Instantiate(StationPrefabs[Random.Range(0, StationPrefabs.Length)], obstaclePosition, Quaternion.identity);
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
