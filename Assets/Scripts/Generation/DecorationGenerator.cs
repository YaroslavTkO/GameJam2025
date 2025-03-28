using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorationGenerator : MonoBehaviour
{
    public GameObject[] DecorationPrefabs;
    public Transform train;
    public List<GameObject> decorationsList;
    private float spawnPosition = -3f;
    public float decorationSpace;
    public int decorationCount;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnDecoration), 0f, 0.05f);
    }

    void SpawnDecoration()
    {
        if (train.position.y > spawnPosition + 3 * decorationSpace - decorationCount / 2 * decorationSpace)
        {
            float x = Random.Range(1, 5);
            GameObject DecorationRight = Instantiate(
                DecorationPrefabs[Random.Range(0, DecorationPrefabs.Length)], new Vector3(Random.Range(1f, 2f), spawnPosition - Random.Range(0f, 1f)), Quaternion.identity);
            decorationsList.Add(DecorationRight);
            GameObject DecorationLeft = Instantiate(
                DecorationPrefabs[Random.Range(0, DecorationPrefabs.Length)], new Vector3(-Random.Range(1f,2f), spawnPosition + Random.Range(0f, 1f)), Quaternion.identity);
            decorationsList.Add(DecorationLeft); 
            spawnPosition += decorationSpace;
        }

    }

    void RemoveOldDecoration()
    {
        if (decorationsList.Count > decorationCount)
        {
            Destroy(decorationsList[0]);
            decorationsList.RemoveAt(0);
        }
    }

    void Update()
    {

        RemoveOldDecoration();
    }
}