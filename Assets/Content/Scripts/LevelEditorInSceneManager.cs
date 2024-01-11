using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Manages the spawning and tracking of level objects
/// </summary>
public class LevelEditorInSceneManager : MonoBehaviour
{
	//Variables
	[SerializeField]
    private LevelPrefabsSO _levelPrefabsList = null;
	[SerializeField]
	private GameObject _defaultSpawnLocation = null;

	private LevelData _currentLevelData = null;
	private Vector3 _defaultSpawnVector = Vector3.zero;

	/// <summary>
	/// On start try and set the default spawn position
	/// </summary>
	private void Start()
	{
		if (_defaultSpawnLocation != null)
		{
			_defaultSpawnVector = _defaultSpawnLocation.transform.position;
		}
	}

	/// <summary>
	/// Called from the GUI to save the level
	/// </summary>
	public void SaveCurrentLevel()
    {
		List<InSceneLevelObject> levelObjects = GetComponentsInChildren<InSceneLevelObject>().ToList();
		
		if (_currentLevelData == null)
		{
			_currentLevelData = new LevelData();
		}
		else
		{
			_currentLevelData.ObjectsInLevel.Clear();
		}

		for (int i = 0; i < levelObjects.Count; i++)
		{
			_currentLevelData.ObjectsInLevel.Add(levelObjects[i].GetObjectData());
		}

		//Example TODO delete or ignore all objects currently in the trash can before saving

		LevelEditorSaveHandler.SaveLevelData(_currentLevelData);
	}

	/// <summary>
	/// Called from the GUI to load a saved level
	/// </summary>
    public void LoadLevel()
    {
		List<InSceneLevelObject> levelObjects = GetComponentsInChildren<InSceneLevelObject>().ToList();
		for (int i = 0; i < levelObjects.Count; i++)
		{
			Destroy(levelObjects[i].gameObject);
		}

		_currentLevelData = LevelEditorSaveHandler.LoadLevelData();
		for (int i = 0; i < _currentLevelData.ObjectsInLevel.Count; i++)
		{
			SpawnLevelObjectFromData(_currentLevelData.ObjectsInLevel[i]);
		}
	}

	/// <summary>
	/// Used to reload a level from a saved file
	/// Calls SpawnNewLevelObject to create the base object then updates the transform from the given objectData 
	/// </summary>
	/// <param name="objectData"></param>
	public void SpawnLevelObjectFromData(ObjectData objectData)
	{
		GameObject newObj = SpawnNewLevelObjectFromID(objectData.PrefabID);
		newObj.transform.localPosition = objectData.ObjectPosition;
		newObj.transform.rotation = objectData.ObjectRotation;
	}

	/// <summary>
	/// Called from an in game GUI with an object ID to spawn
	/// </summary>
	/// <param name="objectID"> The object ID from <see cref="LevelPrefabsSO"/></param>
	public GameObject SpawnNewLevelObjectFromID(int objectID)
    {
		GameObject spawnedObj = null;
		
		if (_levelPrefabsList.LevelEditorSpawnableObjects[objectID] != null)
        {
			spawnedObj = Instantiate(_levelPrefabsList.LevelEditorSpawnableObjects[objectID], _defaultSpawnVector, Quaternion.identity,gameObject.transform);
			spawnedObj.AddComponent<InSceneLevelObject>().SetUpLevelObject(objectID);
		}
		return spawnedObj;
	}
}
