using UnityEngine;
using UnityEngine.Events;

public class ClosedDoor : MonoBehaviour
{
	[SerializeField] private Door _door;
	[SerializeField] private Interacteble _doorHandle;
	[SerializeField] private Item _key;
	[SerializeField] private string _lockedCaption = "You need a \"{0}\" to unlock this door";
	[SerializeField] private UnityEvent _closedInteract;

	private void OnEnable()
	{
		_doorHandle.Interacted.AddListener(OnInteract);
	}

	private void OnDisable()
	{
		_doorHandle.Interacted.RemoveListener(OnInteract);
	}

	private void OnInteract(Interacteble sender, InteractContext info)
	{
		if (info.Container.ContainItem(_key) == false)
		{
			info.PlayerMessageView.ShowMessage(string.Format(_lockedCaption, _key.InGameName));
			_closedInteract.Invoke();
			return;
		}
		if (_door.IsOpen)
		{
			_door.Close();
			return;
		}
		_door.Open();
	}
}
