using UnityEngine;

public class FinalQuest : Quest
{
	[SerializeField] private Interacteble _interacteble;
	[SerializeField] private QuestLine _line;
	[SerializeField] private Item _requestItem;

	private void OnEnable()
	{
		_interacteble.Interacted.AddListener(OnInteract);
	}

	private void OnDisable()
	{
		_interacteble.Interacted.RemoveListener(OnInteract);
	}

	private void OnInteract(Interacteble sender, InteractContext info)
	{
		if (info.Container.ContainItem(_requestItem))
		{
			_line.CompleteLine();
		}
	}
}
