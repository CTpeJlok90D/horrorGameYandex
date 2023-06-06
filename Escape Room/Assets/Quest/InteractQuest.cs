using UnityEngine;

public class InteractQuest : Quest
{
	[SerializeField] private Interacteble _interacteble;

	public override void OnBegin()
	{
		base.OnBegin();
		_interacteble.Interacted.AddListener(OnInteract);
	}

	public override void OnQuestFinish()
	{
		base.OnQuestFinish();
		_interacteble.Interacted.RemoveListener(OnInteract);
	}

	private void OnInteract(Interacteble sender, PlayerInfo info)
	{
		Complete();
	}
}