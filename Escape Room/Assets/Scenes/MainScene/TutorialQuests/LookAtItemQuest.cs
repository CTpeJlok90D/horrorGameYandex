using UnityEngine;

public sealed class LookAtItemQuest : Quest
{
	[SerializeField] private ExmindedWorldObject _paper;
	public override void OnBegin()
	{
		base.OnBegin();
		_paper.LookStopped.AddListener(OnPaperInteract);
	}

	private void OnPaperInteract()
	{
		_paper.LookStopped.RemoveListener(OnPaperInteract);
		Complete();
	}

	private void OnDisable()
	{
		_paper.LookStopped.RemoveListener(OnPaperInteract);
	}
}
