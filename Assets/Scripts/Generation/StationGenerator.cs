using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class StationGenerator : MonoBehaviour
{
    public GameObject[] StationPrefabs;
    public Transform train;
    public GameObject currentStation;
    public float distanceToDelete;

    private bool tutorialShowed = false;

    private void Start()
    {
        tutorialShowed = PlayerPrefs.GetInt("stationTutorial", 0) == 0 ? false : true;
        InvokeRepeating(nameof(SpawnStation), 1f, 3f);
    }

    void SpawnStation()
    {
        if (currentStation == null)
        {
            Vector3 stationPosition = new Vector3(-0.6f, train.position.y + 25 + Random.Range(-4f, 4f), 0);
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
        Tutorial();

        DestroyStation();
    }

    void Tutorial()
    {
        if (!tutorialShowed && currentStation != null)
        {
            if (currentStation.transform.position.y - train.transform.position.y < 2f)
            {
                train.GetComponent<TrainMovement>().currentSpeed = 0;
                TutorialManager.Instance.Show(2);
                tutorialShowed = true;

                PlayerPrefs.SetInt("stationTutorial", 1);
            }

        }

    }
}
