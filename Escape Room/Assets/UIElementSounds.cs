using UnityEngine;
using UnityEngine.EventSystems;

public class UIElementSounds : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
	[SerializeField] private AudioClip _clickClip;
	[SerializeField] private AudioClip _enterClip;
	[SerializeField] private AudioSource _source;

	public void OnPointerClick(PointerEventData eventData)
	{
		_source.clip = _clickClip;
		_source.Play();
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		_source.clip = _enterClip;
		_source.Play();
	}
}
