using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Creates a list in which to drag the spawnable level editor prefabs
/// </summary>
[CreateAssetMenu(fileName = "LevelEditor_SpawnableObjectList", menuName = "CoalCarStudios/LevelEditorSpawnableObjectList", order = 1)]
public class LevelPrefabsSO : ScriptableObject
{
    public List<GameObject> LevelEditorSpawnableObjects = new List<GameObject>();
}
