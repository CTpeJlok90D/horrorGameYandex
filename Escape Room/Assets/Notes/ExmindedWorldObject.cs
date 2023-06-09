using UnityEngine;
using UnityEngine.Events;

public class ExmindedWorldObject : MonoBehaviour
{
	[SerializeField] private Interacteble _interactZone;
	[SerializeField] private ExmindedObject _exmindPefab;
	[SerializeField] private UnityEvent _lookStopped;

	public UnityEvent LookStopped => _lookStopped;

	private void OnEnable()
	{
		_interactZone.Interacted.AddListener(OnInteract);
	}
	private void OnDisable()
	{
		_interactZone.Interacted.RemoveListener(OnInteract);
	}

	private void OnInteract(Interacteble sender, InteractContext info)
	{
		info.NoteView.ShowNote(_exmindPefab, _lookStopped);
	}
}
