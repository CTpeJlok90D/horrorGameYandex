using AI.Memory;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class AINoseMaker : MonoBehaviour
{
	[SerializeField] private FactorInfo _factor;
	[SerializeField] private SphereCollider _collider;

	public SphereCollider Collider => _collider;

	private void OnTriggerStay(Collider other)
	{
		if (other.TryGetComponent(out AIPawn brain))
		{
			brain.Brain.AddFactor(_factor);
		}
	}
}
