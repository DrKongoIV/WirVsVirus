using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
	public List<Edge> edges;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public Edge getRandomEdge()
	{
		return edges[Random.Range(0, edges.Count)];
	}
}
