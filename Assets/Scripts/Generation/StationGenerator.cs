using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class StationGenerator : MonoBehaviour
{
    public GameObject[] StationPrefabs;
    public Transform train;
    public float stationSpawnRate = 1f;
    public GameObject currentStation;
    public float distanceToDelete;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnStation), 1f, 3f);
    }

    void SpawnStation()
    {
        if (currentStation == null)
        {
            Vector3 stationPosition = new Vector3(-0.6f, train.position.y + 25, 0);
            GameObject station = Instantiate(StationPrefabs[Random.Range(0, StationPrefabs.Length)], stationPosition, Quaternion.identity);
            currentStation = station;
            UnityEngine.Debug.Log(station == null);
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
        DestroyStation();
    }
}
