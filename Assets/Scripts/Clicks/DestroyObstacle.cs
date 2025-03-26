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
            // �������� ������ �����
            Touch touch = Input.GetTouch(0);

            // ����������, �� �� ���������� �����
            if (touch.phase == TouchPhase.Began)
            {
                // �������� ������� ������ �� �����
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                touchPosition.z = 0;  // ������������ Z ���������� �� 0 ��� 2D

                // ������������� Raycast, ��� ���������, �� ��� ����� �� ��'��� � ����������
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
