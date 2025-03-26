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
        if (Input.touchCount > 0)
        {
            // Отримуємо перший дотик
            Touch touch = Input.GetTouch(0);

            // Перевіряємо, чи це початковий дотик
            if (touch.phase == TouchPhase.Began)
            {
                // Отримуємо позицію дотику на екрані
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                touchPosition.z = 0;  // Встановлюємо Z координату на 0 для 2D

                // Використовуємо Raycast, щоб перевірити, чи був дотик на об'єкті з колайдером
                RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);

                if (hit.collider != null)
                {

                    obstacleHealth--;
                }
            }
        }
    }

    void OnMouseDown()
    {
        obstacleHealth--;
    }
    void Destruction()
    {
        Destroy(gameObject);

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
