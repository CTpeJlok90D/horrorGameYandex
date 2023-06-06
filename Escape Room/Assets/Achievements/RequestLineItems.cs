using System.Collections.Generic;
using UnityEngine;

public class RequestLineItems : MonoBehaviour
{
	[SerializeField] private List<Item> _items;
	[SerializeField] private Container _playerInventory;
	[SerializeField] private Achievement _achievement;

	private void OnEnable()
	{
		_playerInventory.AddedItem += OnItemAdd;
	}

	private void OnDisable()
	{
		_playerInventory.AddedItem -= OnItemAdd;
	}

	public void RemoveItem(Item item)
	{
		_items.Remove(item);
	}

	private void OnItemAdd(Item item)
	{
		if (_items.Contains(item))
		{
			PlayerDataContainer.Instance.AddAchievement(_achievement);
		}
	}
}
