using UnityEngine;
using UnityEngine.AI;

public class StepSound : MonoBehaviour
{
	[SerializeField] private AudioSource _source;
	[SerializeField] private NavMeshAgent _agent;

	private void Update()
	{
		if (_agent.velocity == Vector3.zero && _source.isPlaying)
		{
			_source.Stop();
		}
		if (_agent.velocity != Vector3.zero && _source.isPlaying == false)
		{
			_source.Play();
		}
	}
}
