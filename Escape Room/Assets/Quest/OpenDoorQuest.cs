using UnityEngine;

public class OpenDoorQuest : Quest
{
	[SerializeField] private Door _door;
	[SerializeField] private bool _doorIsOpened;

	private void OnEnable()
	{
		_door.Opened.AddListener(OnDoorOpen);
	}

	private void OnDisable()
	{
		_door.Opened.RemoveListener(OnDoorOpen);
	}

	public override void OnBegin()
	{
		if (_door.IsOpen)
		{
			Complete();
		}
	}

	private void OnDoorOpen()
	{
		if (QuestIsStarted)
		{
			Complete();
		}
	}
}
