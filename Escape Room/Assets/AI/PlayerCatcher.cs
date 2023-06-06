using Cinemachine;
using UnityEngine;
using UnityEngine.AI;

public class PlayerCatcher : MonoBehaviour
{
	[SerializeField] private TriggerEvents _trigger;
	[SerializeField] private NavMeshAgent _agent;
	[SerializeField] private Animator _animator;
	[SerializeField] private string _killAnimationName = "Attack";
	[SerializeField] private CinemachineVirtualCamera _killCamera;
	[SerializeField] private LayerMask _visionLayerMask;

	private void OnEnable()
	{
		_trigger.OnTriggerEnterEvent.AddListener(OnTriggerEnterEvent);
	}

	private void OnDisable()
	{
		_trigger.OnTriggerEnterEvent.RemoveListener(OnTriggerEnterEvent);
	}

	private void OnTriggerEnterEvent(Collider other)
	{
		if (other.TryGetComponent(out CharacterController player))
		{
			Physics.Raycast(_agent.transform.position, player.transform.position - _agent.transform.position, out RaycastHit hit, Mathf.Infinity, _visionLayerMask);
			if (hit.collider == other)
			{
				AttackPlayer(player);
			}
		}
	}

	public void AttackPlayer(CharacterController player)
	{
		_agent.velocity = Vector3.zero;
		_agent.isStopped = true;
		player.enabled = false;
		_animator.Play(_killAnimationName);
		_killCamera.Priority = 100;
	}
}
