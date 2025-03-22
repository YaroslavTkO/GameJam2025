using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMovement : MonoBehaviour
{
    public float currentSpeed;
    
    public TrainStats stats;
    public AudioSource trainAudioSource;
    public AudioSource breaksAudio;


    private GameManager manager;

    private bool accelerating = false, decelerating = false;

    void Start()
    {
        manager = GameManager.Instance;
        trainAudioSource.volume = 0.4f;
        breaksAudio.volume = 0.4f;
        breaksAudio.loop = true;
    }

    public void ChangeAccelerationStatus(bool newStatus)
    {
        accelerating = newStatus;
       
    }
    public void ChangeDecelerationStatus(bool newStatus)
    {
        decelerating = newStatus;
    }

    void UserInput()
    {
        if (Input.GetKey(KeyCode.W) || accelerating)
        {
            currentSpeed += stats.accelerationSpeed * Time.deltaTime;
            if (currentSpeed > stats.maxSpeed)
            {
                currentSpeed = stats.maxSpeed;
            }

        }
        else if (Input.GetKey(KeyCode.S) || decelerating)
        {
            currentSpeed -= stats.deccelarationSpeed * Time.deltaTime;
            if (currentSpeed < 0)
                currentSpeed = 0;
        }


        Vector3 movement = currentSpeed * Time.deltaTime * transform.up;
        transform.position += movement;

        manager.Score = (int)transform.position.y;
    }

 
    void Update()
    {
        if (manager.IsGameActive)
        {
            
            UserInput();
            if (decelerating && currentSpeed > 0 && !breaksAudio.isPlaying)
            {
                breaksAudio.Play();
            }
            else if ((!decelerating || currentSpeed <= 0) && breaksAudio.isPlaying)
            {
                breaksAudio.Stop();
            }
            if (currentSpeed > 0 && !trainAudioSource.isPlaying)
            {
                trainAudioSource.Play();
            }
            else if (trainAudioSource.isPlaying && currentSpeed <= 0) {
                trainAudioSource.Stop();
            
            }
            if(stats.isOnStation && currentSpeed == 0) {
                stats.ClaimStationBonus();
                UiManager.Instance.ShopButtonChangeVisibility(true);
            }
            else
            {
                UiManager.Instance.ShopButtonChangeVisibility(false);
            }
        }
        
    }
}
