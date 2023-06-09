using UnityEngine;

public class WorldItem : MonoBehaviour
{
	[SerializeField] private Item _source;
	[SerializeField] private Interacteble _interactZone;

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
		info.Container.AddItem(_source);
		Destroy(this.gameObject);
	}
}
