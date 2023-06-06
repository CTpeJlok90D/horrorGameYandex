using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider), typeof(Interacteble))]
public class WorldBookItems : MonoBehaviour
{
	[SerializeField] private Interacteble _interacteble;
	[SerializeField] private bool _removeAfterTake = true;
	[SerializeField] private List<Book> _bookVariants = new();

	private void OnEnable()
	{
		_interacteble.Interacted.AddListener(OnInteract);
	}

	private void OnDisable()
	{
		_interacteble.Interacted.AddListener(OnInteract);
	}

	public void OnInteract(Interacteble sender, PlayerInfo info)
	{
		info.BookThower.AddBook(_bookVariants[Random.Range(0, _bookVariants.Count)]);
		if (_removeAfterTake)
		{
			Destroy(gameObject);
		}
	}
}
