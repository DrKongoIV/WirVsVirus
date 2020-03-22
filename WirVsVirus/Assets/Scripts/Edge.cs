using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Edge : MonoBehaviour
{

	public Node node1;
	public Node node2;

	public Material active, inactive;

	public bool hover;
	public bool deactivated;

	LineRenderer rend;
	PolygonCollider2D polCollider;

	void Start()
    {
		rend = GetComponent<LineRenderer>();
		polCollider = GetComponent<PolygonCollider2D>();

		Vector2 offset = new Vector2(node1.transform.position.x - node2.transform.position.x, node1.transform.position.y - node2.transform.position.y);
		offset = Vector2.Perpendicular(offset);
		offset.Normalize();
		offset.Scale(new Vector2(0.05f, 0.05f));

		polCollider.points = new Vector2[] {	new Vector2(node1.transform.position.x + offset.x, node1.transform.position.y + offset.y),
											new Vector2(node1.transform.position.x - offset.x, node1.transform.position.y - offset.y),
											new Vector2(node2.transform.position.x - offset.x, node2.transform.position.y - offset.y),
											new Vector2(node2.transform.position.x + offset.x, node2.transform.position.y + offset.y)};
    }


	void Update()
    {
		transform.position = new Vector3(0, 0, -2);
		rend.SetPositions(new Vector3[] { node1.transform.position, node2.transform.position });
		if(Input.GetMouseButtonDown(0) && hover)
		{
			if(deactivated)
			{
				deactivated = false;
				node1.edges.Add(this);
				node2.edges.Add(this);
				rend.material = active;
			} else
			{
				deactivated = true;
				node1.edges.Remove(this);
				node2.edges.Remove(this);
				rend.material = inactive;
			}
		}
	}

	private void OnMouseEnter()
	{
		hover = true;
		rend.startWidth = 0.1f;
	}

	private void OnMouseExit()
	{
		hover = false;
		rend.startWidth = 0.05f;
	}
}
