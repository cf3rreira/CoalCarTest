using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Holds object and transform data for levels
/// </summary>
[Serializable]
public class LevelData
{
	//Current objects ready for saving
	public List<ObjectData> ObjectsInLevel = new();
}

/// <summary>
/// Holds the data for the objects that build the level
/// </summary>
[Serializable]
public class ObjectData
{
	public int PrefabID;
	public Quaternion ObjectRotation;
	public Vector3 ObjectPosition;
}