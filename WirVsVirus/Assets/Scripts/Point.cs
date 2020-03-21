using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
	public bool infected;
	public bool visible;
	public float incubationTime;
	public float infectedTime;

	public float speed = 1;
    public float personalDeviation = 2;

	public Edge edge;
	public Node goal;

	SpriteRenderer render;

    public void setIncubationTime(float t)
    {
        incubationTime = Random.Range(t - personalDeviation, t + personalDeviation);
    }

    public float getIncubationTime()
    {
        return incubationTime;
    }

    public void setSpeed(float s)
    {
        speed = s;
    }

    // Start is called before the first frame update
    void Start()
    {
		render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(infected && !visible)
		{
			if(infectedTime > incubationTime)
			{
				visible = true;
				render.sprite = Resources.Load<Sprite>("Sprites/sick");
			}
			infectedTime += Time.deltaTime;
		}

		if(transform.position == goal.transform.position)
		{
			edge = goal.getRandomEdge();
			if (edge.node1 == goal)
				goal = edge.node2;
			else
				goal = edge.node1;
		}
		transform.position = Vector3.MoveTowards(transform.position, goal.transform.position, Time.deltaTime * speed);
    }

	private void OnTriggerEnter2D(Collider2D collider)
	{
		Point p = collider.GetComponent<Point>();
		if(p != null)
		{
			if (p.infected)
				infected = true;
		}
	}
}
