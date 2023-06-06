using UnityEngine;

public class FindItemQuest : Quest
{
	[SerializeField] private Container _playerInventory;
	[SerializeField] private Item _requestItem;

	private bool _itemIsFounded;

	private void OnEnable()
	{
		_playerInventory.AddedItem += OnItemAdded;
	}
	private void OnDisable()
	{
		_playerInventory.AddedItem -= OnItemAdded;
	}

	public override void OnBegin()
	{
		base.OnBegin();
		if (_itemIsFounded)
		{
			Complete();
		}
	}

	public void OnItemAdded(Item item)
	{
		if (item != _requestItem)
		{
			return;
		}

		_itemIsFounded = true;

		if (QuestIsStarted)
		{
			Complete();
		}
	}
}
