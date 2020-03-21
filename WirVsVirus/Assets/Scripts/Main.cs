using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public float incubationTime = 6; // Incubation Time in Seconds
	public float speed = 1; // Speed of Points - how much deltaTime
	public int numberOfPoints = 100;
	public float spawnFrequency = 1; // TODO fürs Warten

	public GameObject prefab;

    void setMap() { } // TODO

    // Start is called before the first frame update
    void Start()
    {
        // Patient 0
        pointSpawn(speed, incubationTime, false);
        setMap(); // TODO
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < numberOfPoints; i++)
        {
            pointSpawn(speed, incubationTime, false);
            // TODO warten - siehe spawnFrequency
        }
    }

	public void pointSpawn(float speed, float incTime, bool infect)
	{
		Point p = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity).GetComponent<Point>();
		p.setIncubationTime(incTime);
		p.setSpeed(speed);
		p.infected = infect;
	}
}
