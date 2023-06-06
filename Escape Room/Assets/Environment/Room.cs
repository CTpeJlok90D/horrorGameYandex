using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Room : MonoBehaviour
{
	[SerializeField] private string Name = "Room name";

	private void OnTriggerEnter(Collider other)
	{
		if (other.TryGetComponent(out RoomNameShower shower))
		{
			shower.TMP_Text.text = Name;
		}
	}

#if UNITY_EDITOR
	private void OnValidate()
	{
		Collider collider = GetComponent<Collider>();
		collider.isTrigger = true;
	}
#endif
}
