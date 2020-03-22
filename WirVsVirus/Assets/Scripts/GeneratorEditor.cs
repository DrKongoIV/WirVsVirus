#if UNITY_EDITOR
using System.Collections;
using UnityEditor;
using UnityEngine;
using FullSerializer;

[CustomEditor(typeof(Generator))]
public class GeneratorEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		if(GUILayout.Button("Generate")) {

			Generator gen = (Generator)target;

			Data data = new Data();
			new fsSerializer().TryDeserialize<Data>(fsJsonParser.Parse(gen.text.text), ref data);

			foreach (string l in data.nodes.Keys)
			{
				GameObject go = Instantiate(gen.NodePrefab, new Vector3(data.nodes[l].x, data.nodes[l].y, 0), Quaternion.identity);
				go.name = l;
			}
			foreach (DataEdge n in data.edges)
			{
				Edge e = Instantiate(gen.EdgePrefab, new Vector3(0, 0, 0), Quaternion.identity).GetComponent<Edge>();
				Debug.Log(n.source);
				e.node1 = GameObject.Find(n.source+"").GetComponent<Node>();
				e.node2 = GameObject.Find(n.target+"").GetComponent<Node>();
			}
		}
	}
}
#endif