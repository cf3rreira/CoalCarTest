using UnityEngine;

/// <summary>
/// Placed on objects as they are added in scene for tracking purposes
/// </summary>
public class InSceneLevelObject : MonoBehaviour
{
	//Variables
	private ObjectData _storedData = null;

	/// <summary>
	/// When this object is first instantiated track what its prefab index is and create a <see cref="ObjectData"/> for it
	/// </summary>
	/// <param name="spawnableID"></param>
	public void SetUpLevelObject(int spawnableID)
	{
		if (_storedData == null)
		{
			_storedData = new ObjectData();
			_storedData.PrefabID = spawnableID;
		}
	}

	/// <summary>
	/// Polls the transform to get the relevant information and stores it in <see cref="_storedData"/>
	/// </summary>
	/// <returns> This objects stored data </returns>
	public ObjectData GetObjectData()
	{
		_storedData.ObjectPosition = transform.localPosition;
		_storedData.ObjectRotation = transform.localRotation;
		return _storedData;
	}
}
