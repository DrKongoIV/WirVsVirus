#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class LineHelper : ScriptableObject
{
	[MenuItem("LineHelper/Create Edge #_E")]
	static void PlayGame()
	{
		GameObject[] objs = Selection.gameObjects;
		if (objs.Length == 2 && objs[0].GetComponent<Node>() != null && objs[1].GetComponent<Node>() != null)
		{
			Edge e = Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Edge.prefab")).GetComponent<Edge>();
			e.node1 = objs[0].GetComponent<Node>();
			e.node2 = objs[1].GetComponent<Node>();
		}
	}
}
#endif
