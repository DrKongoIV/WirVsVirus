using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Data 
{
	public Dictionary<string, DataNode> nodes;
	public DataEdge[] edges;
}

[Serializable]
public class DataNode
{
	public float x, y;
}

[Serializable]
public class DataEdge
{
	public long source, target;
}
