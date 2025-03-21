using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationStats : MonoBehaviour
{

    public float fuel;
    public int passengers;

    // Start is called before the first frame update
    void Start()
    {
        fuel = Random.Range(50f, 100f);
        passengers = Random.Range(5, 10);
        
    }

}
