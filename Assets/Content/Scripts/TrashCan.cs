using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Will delete objects in range of the trash can when empty trash is called
/// </summary>
public class TrashCan : MonoBehaviour
{
	private List<GameObject> _objectsToDelete = new List<GameObject>();

	/// <summary>
	/// Keep track of objects put in the trash can
	/// </summary>
	/// <param name="other"></param>
	private void OnTriggerEnter(Collider other)
	{
		//Only track draggable objects
		Draggable draggable = other.gameObject.GetComponent<Draggable>();
		if (draggable)
		{
			_objectsToDelete.Add(draggable.gameObject);
		}
	}

	/// <summary>
	/// Called from Gui and deletes all tracked objects in the trash
	/// </summary>
	public void EmptyTrash()
	{
		for (int i = 0; i < _objectsToDelete.Count; i++)
		{
			Destroy(_objectsToDelete[i]);
		}

		_objectsToDelete.Clear();
	}
}
