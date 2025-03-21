using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObstacle : MonoBehaviour
{
    public int obstacleHealth = 5;


    void Update()
    {
        if (obstacleHealth <= 0)
            Destruction();

    }

    void Destruction()
    {
        Destroy(gameObject);

    }

    void OnMouseDown()
    {
        obstacleHealth--;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.Instance.IsGameActive = false;
            GameManager.Instance.GameOver();
        }
    }
}
