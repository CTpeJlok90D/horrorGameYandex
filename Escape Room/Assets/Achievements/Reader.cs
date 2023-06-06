using System.Collections.Generic;
using UnityEngine;

public class Reader : MonoBehaviour
{
	[SerializeField] private List<Interacteble> _notes;
	[SerializeField] private Achievement _achievement;

	private void OnEnable()
	{
		foreach (Interacteble note in _notes)
		{
			note.Interacted.AddListener(OnInteract);
		}
	}

	private void OnDisable()
	{
		foreach (Interacteble note in _notes)
		{
			note.Interacted.RemoveListener(OnInteract);
		}
	}
	private void OnInteract(Interacteble sender, PlayerInfo info)
	{
		_notes.Remove(sender);
		if (_notes.Count == 0)
		{
			PlayerDataContainer.Instance.AddAchievement(_achievement);
		}
	}
}
