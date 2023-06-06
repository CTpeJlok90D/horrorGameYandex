using UnityEngine;
using UnityEngine.EventSystems;

public class LookZone : MonoBehaviour, IDragHandler, IPointerClickHandler
{
	private Vector2 _delta;

	public Vector2 Delta => _delta;

	public void OnDrag(PointerEventData eventData)
	{
		_delta = InputSingletone.Instance.PlayerMovement.TouchDelta.ReadValue<Vector2>();
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		_delta = Vector2.zero;
	}
}
