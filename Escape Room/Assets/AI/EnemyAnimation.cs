using AI.Memory;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimation : MonoBehaviour
{
	[SerializeField] private NavMeshAgent _agent;
	[SerializeField] private Animator _animator;
	[SerializeField] private AIDifficultLoader _loader;

	private void Update()
	{
		_animator.SetFloat("Speed", _agent.velocity.magnitude);
		_animator.SetBool("Triggered", _loader.CurrentBrain.Triggered.Value);
	}
}
