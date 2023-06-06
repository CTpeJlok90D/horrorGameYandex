using AI.Memory;
using UnityEngine;

public class Vision : MonoBehaviour
{
	[SerializeField] private Brain _brain;
	[SerializeField] private TriggerEvents _vision;
	[SerializeField] private LayerMask _visionLayerMask;

	private void OnEnable()
	{
		_vision.OnTriggerStayEvent.AddListener(OnVisionTriggerStay);
	}

	private void OnDisable()
	{
		_vision.OnTriggerStayEvent.RemoveListener(OnVisionTriggerStay);
	}
	
	private void OnVisionTriggerStay(Collider collider)
	{
		Physics.Raycast(_vision.transform.position, collider.transform.position - _vision.transform.position, out RaycastHit hit, Mathf.Infinity, _visionLayerMask);
		Debug.DrawRay(_vision.transform.position, collider.transform.position - _vision.transform.position);
		if (collider.TryGetComponent(out FactorContainer container) && hit.collider == collider)
		{
			_brain.AddFactor(container.Info);
		}
	}
}