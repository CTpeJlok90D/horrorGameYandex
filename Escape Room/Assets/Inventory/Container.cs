using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
	[SerializeField] private List<Item> _items = new();
	public delegate void AddedItemDelegate(Item item);
	private event AddedItemDelegate _addedItem;

	public event AddedItemDelegate AddedItem
	{
		add
		{
			_addedItem += value;
		}
		remove
		{
			_addedItem -= value;
		}
	} 

	public void AddItem(Item item)
	{
		_items.Add(item);
		_addedItem.Invoke(item);
	}

	public void RemoveItem(Item item)
	{
		_items.Remove(item);
	}

	public bool ContainItem(Item item)
	{
		return _items.Contains(item);
	}
}
