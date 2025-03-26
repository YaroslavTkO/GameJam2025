using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Station : MonoBehaviour
{
    public AudioSource source;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var stats = collision.gameObject.GetComponent<TrainStats>();
            if (stats != null)
            {
                stats.isOnStation = true;
                source.Play();
                stats.stationBonuses = GetComponent<StationStats>();

            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var stats = collision.gameObject.GetComponent<TrainStats>();
            if (stats != null)
            {
                stats.isOnStation = false;
                stats.stationBonuses = null;
            }
        }

    }
}
