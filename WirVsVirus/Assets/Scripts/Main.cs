using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    float incubationTime = 6; // Incubation Time in Seconds
    float speed = 1; // Speed of Points - how much deltaTime
    int numberOfPoints = 100;
    float spawnFrequency = 1; // TODO fürs Warten
    Point p;

    void setMap() { } // TODO

    // Start is called before the first frame update
    void Start()
    {
        // Patient 0
        p.pointSpawn(speed, incubationTime, false);
        setMap(); // TODO
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < numberOfPoints; i++)
        {
            p.pointSpawn(speed, incubationTime, false);
            // TODO warten - siehe spawnFrequency
        }
    }
}
