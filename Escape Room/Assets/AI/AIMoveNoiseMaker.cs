using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class AIMoveNoiseMaker : AINoseMaker
{
	[SerializeField] private PlayerMovement _movement;
	[SerializeField] private AnimationCurve _volumePerSpeed;
	private void OnEnable()
	{
		_movement.Moved.AddListener(OnMove);
	}

	private void OnDisable()
	{
		_movement.Moved.RemoveListener(OnMove);
	}

	private void OnMove(Vector3 direction)
	{
		float moveSpeed = direction.magnitude;

		Collider.radius = _volumePerSpeed.Evaluate(moveSpeed);
	}

	private void OnValidate()
	{
		SphereCollider collider = GetComponent<SphereCollider>();
		collider.radius = 0.1f;
		collider.isTrigger = true;
	}
}