using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : MonoBehaviour
{

	public Node node1;
	public Node node2;

	LineRenderer rend;

	[ExecuteInEditMode]
	void Start()
    {
		rend = GetComponent<LineRenderer>();
		node1.edges.Add(this);
		node2.edges.Add(this);
    }

	[ExecuteInEditMode]
	void Update()
    {
		rend.SetPositions(new Vector3[] { node1.transform.position, node2.transform.position });
	}

	void OnDestroy()
	{
		node1.edges.Remove(this);
		node2.edges.Remove(this);
	}
}
