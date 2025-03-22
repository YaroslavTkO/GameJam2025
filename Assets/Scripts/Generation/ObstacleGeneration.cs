using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleGeneration : MonoBehaviour
{
    public GameObject[] ObstaclePrefabs;
    public Transform train;
    public float obstacleSpawnChance = 0.25f;
    public GameObject currentObstacle;

    public bool tutorialShowed = false;

    // Start is called before the first frame update
    void Start()
    {
        tutorialShowed = PlayerPrefs.GetInt("obstacleTutorial", 0) == 0 ? false : true;
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

    void Tutorial()
    {
        if (!tutorialShowed && currentObstacle != null)
        {
            if (currentObstacle.transform.position.y - train.transform.position.y < 3f)
            {
                train.GetComponent<TrainMovement>().currentSpeed = 0;
                TutorialManager.Instance.Show(1);
                tutorialShowed = true;

                PlayerPrefs.SetInt("obstacleTutorial", 1);
            }

        }
    }

    private void Update()
    {
        
        Tutorial();
    }

}
