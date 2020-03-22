using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
	public List<Edge> edges;


    void Start()
    {
		edges = new List<Edge>();
		foreach (Edge e in FindObjectsOfType<Edge>()) {
			if(e.node1  == this || e.node2 == this)
				edges.Add(e);
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public Edge getRandomEdge()
	{
		if (edges.Count > 0)
			return edges[Random.Range(0, edges.Count)];
		else
			return null;
	}
}
