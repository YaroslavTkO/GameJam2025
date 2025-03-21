using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationGenerator : MonoBehaviour
{
    public GameObject[] StationPrefabs;
    public Transform train;
    public float stationSpawnRate = 0.0005f;
    public GameObject currentStation;
    public float distanceToDelete;


    void SpawnStation()
    {
        if (currentStation == null)
        {
            if (Random.value < stationSpawnRate)
            {
                Vector3 stationPosition = new Vector3(-3.5f, train.position.y + 45, 0);
                GameObject station = Instantiate(StationPrefabs[Random.Range(0, StationPrefabs.Length)], stationPosition, Quaternion.identity);
                currentStation = station;
            }
        }
    }
    void DestroyStation()
    {
        if (currentStation != null)
        {
            if (train.position.y > currentStation.transform.position.y + distanceToDelete)
            {
                Destroy(currentStation);

            }
        }
    }
    void Update()
    {
        SpawnStation();
        DestroyStation();
    }
}
