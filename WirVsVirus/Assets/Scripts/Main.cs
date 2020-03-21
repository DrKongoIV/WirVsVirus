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
		pointSpawn(speed, incubationTime, true);
		StartCoroutine(Spawner());
        setMap(); // TODO
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void pointSpawn(float speed, float incTime, bool infect)
	{
		Point p = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity).GetComponent<Point>();
		p.setIncubationTime(incTime);
		p.setSpeed(speed);
		p.infected = infect;
		Node[] nodes = FindObjectsOfType<Node>();
		p.goal = nodes[Random.Range(0, nodes.Length)];
		p.transform.position = p.goal.transform.position;
	}

	private IEnumerator Spawner()
	{
		for (int i = 0; i < numberOfPoints; i++)
		{
			pointSpawn(speed, incubationTime, false);
			yield return new WaitForSeconds(1/spawnFrequency);
		}
	}
}
