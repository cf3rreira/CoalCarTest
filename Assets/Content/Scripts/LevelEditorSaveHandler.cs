using System.IO;
using UnityEngine;

/// <summary>
/// Handles saving and loading the current active level
/// </summary>
public static class LevelEditorSaveHandler
{
    /// <summary>
    /// Converts provided level data to JSON and saves to a file
    /// </summary>
    /// <param name="dataToSave"> The passed in data of all level objects</param>
     public static void SaveLevelData(LevelData dataToSave)
    {
		string dataAsJSON = JsonUtility.ToJson(dataToSave);
		File.WriteAllText(Application.dataPath  + "/level.json", dataAsJSON);
	}
    
    /// <summary>
    /// Loads the selected level data as JSON then converts back into LevelData so the level can be reassembled 
    /// </summary>
    public static LevelData LoadLevelData()
    {
        string dataAsJSON = File.ReadAllText(Application.dataPath + "/level.json");
        LevelData loadedData = null;
        
        if (!string.IsNullOrEmpty(dataAsJSON)) 
        {
			loadedData = JsonUtility.FromJson<LevelData>(dataAsJSON);
        }
        else
        {
            Debug.LogWarning("Failed to load level from file");
        }
        
        return loadedData;
	}
}
