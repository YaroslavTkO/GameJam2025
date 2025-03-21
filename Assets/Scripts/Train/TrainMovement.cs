using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMovement : MonoBehaviour
{
    public float currentSpeed;
    
    public TrainStats stats;


    private GameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameManager.Instance;
    }
    void UserInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            currentSpeed += stats.accelerationSpeed * Time.deltaTime;
            if (currentSpeed > stats.maxSpeed)
            {
                currentSpeed = stats.maxSpeed;
            }

        }
        else if (Input.GetKey(KeyCode.S))
        {
            currentSpeed -= stats.deccelarationSpeed * Time.deltaTime;
            if (currentSpeed < 0)
                currentSpeed = 0;
        }


        Vector3 movement = currentSpeed * Time.deltaTime * transform.up;
        transform.position += movement;

        manager.Score = (int)transform.position.y;
    }

 
    // Update is called once per frame
    void Update()
    {
        if (manager.IsGameActive)
        {
            UserInput();
            if(stats.isOnStation && currentSpeed == 0) {
                stats.ClaimStationBonus();
            }
        }
        
    }
}
