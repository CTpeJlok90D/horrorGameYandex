using UnityEngine;

public class UnlockedDoor : Door
{
	[SerializeField] private Interacteble _doorHandle;

	private void OnEnable()
	{
		_doorHandle.Interacted.AddListener(OnInteract);
	}

	private void OnDisable()
	{
		_doorHandle.Interacted.RemoveListener(OnInteract);
	}

	private void OnInteract(Interacteble sender, PlayerInfo info)
	{
		if (IsOpen)
		{
			Close();
			return;
		}
		Open();
	}
}
