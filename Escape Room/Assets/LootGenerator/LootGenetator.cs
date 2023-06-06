using System.Collections.Generic;
using UnityEngine;

public class LootGenetator : MonoBehaviour
{
	[SerializeField] private List<Transform> _possiblePositions;
	[SerializeField] private List<GameObject> _objectsToGenerate;

	private void Awake()
	{
		int count = 0;
		while (count < _possiblePositions.Count && count < _objectsToGenerate.Count)
		{
			Transform position = _possiblePositions[Random.Range(0, _possiblePositions.Count)];
			GameObject selectedObject = _objectsToGenerate[count];

			_objectsToGenerate.Remove(selectedObject);
			_possiblePositions.Remove(position);

			Instantiate(selectedObject, position);
		}
	}
}
