using UnityEngine;

/// <summary>
/// Sits on the UI prefab that represents a spawnable object.
/// When clicked it will spawn the prefab in front of the menu
/// If this was a complete system I would have these automatically populated by the LevelEditorSpawnList 
/// </summary>
public class SpawnSelectedPrefab : MonoBehaviour
{
	/// <summary>
	/// The id of the object in <see cref="LevelPrefabsSO"/>
	/// </summary>
	[SerializeField]
	private int _inSceneObjectToSpawnID;

	[SerializeField]
	private LevelEditorInSceneManager _levelManager = null;

	/// <summary>
	/// Called from a GUI button in the menu to spawn its given prefab based on ID
	/// </summary>
	public void SpawnObject()
	{
		_levelManager.SpawnNewLevelObjectFromID(_inSceneObjectToSpawnID);
	}
}
