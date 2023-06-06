using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Collider))]
public class AIDoorOpener : MonoBehaviour
{
	public bool ClosingDoors = true;
	[SerializeField] private float _openTime;
	[SerializeField] private NavMeshAgent _agent;
	[SerializeField] private float _disableTriggerTime = 1.5f;
	private Collider _collider;

	private void Awake()
	{
		_collider = GetComponent<Collider>();
		_collider.isTrigger = true;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.TryGetComponent(out Door door) && door.CanBeOpenedByEnemy && door.IsOpen == false)
		{
			StartCoroutine(StopEnemy(door, true));
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.TryGetComponent(out Door door) && door.CanBeOpenedByEnemy && ClosingDoors && door.IsOpen)
		{
			StartCoroutine(StopEnemy(door, false));
		}
	}

	private IEnumerator StopEnemy(Door door, bool doorState)
	{
		_agent.isStopped = true;
		_agent.velocity = Vector3.zero;
		yield return new WaitForSeconds(_openTime);
		_agent.isStopped = false;
		door.IsOpen = doorState;

		_collider.enabled = false;
		yield return new WaitForSeconds(_disableTriggerTime);
		_collider.enabled = true;
	}
}
