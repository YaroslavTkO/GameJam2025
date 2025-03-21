using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailGenerator : MonoBehaviour
{
    public GameObject railPrefab;
    public Transform train;
    public int railCount;
    public float railLength;
    public List<GameObject> railList;

    private float spawnPosition = 0f;

    // Start is called before the first frame update
    void Start()
    {

        void Start()
        {
            for (int i = 0; i < railCount; i++)
            {
                SpawnRail();
            }
        }
    }

    void SpawnRail()
    {
        GameObject newRail = Instantiate(railPrefab, new Vector3(0.35f, spawnPosition), Quaternion.identity);
        railList.Add(newRail);
        spawnPosition += railLength; 
    }

    void RemoveOldRail()
    {
        if (railList.Count > railCount)
        {
            Destroy(railList[0]);
            railList.RemoveAt(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (train.position.y > spawnPosition + 3*railLength - railCount * railLength)
        {
            SpawnRail();
            RemoveOldRail();
        }
    }
}
