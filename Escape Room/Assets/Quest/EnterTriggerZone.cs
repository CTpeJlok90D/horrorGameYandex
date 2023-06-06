using UnityEngine;

public class EnterTriggerZone : Quest
{
	[SerializeField] private TriggerEvents _triggerEvents;

	private void OnEnable()
	{
		_triggerEvents.OnTriggerEnterEvent.AddListener(OnTriggerEnterEvent);
	}

	private void OnDisable()
	{
		_triggerEvents.OnTriggerEnterEvent.RemoveListener(OnTriggerEnterEvent);
	}

	private void OnTriggerEnterEvent(Collider other)
	{
		if (other.TryGetComponent(out PlayerMovement player))
		{
			Complete();
		}
	}
}
