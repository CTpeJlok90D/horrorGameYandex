using AI.Memory;
using UnityEngine;

public class AIDifficultLoader : MonoBehaviour
{
	[SerializeField] private UnityDictionarity<PlayerData.Difficult, Brain> _difficultObject = new();

	public Brain CurrentBrain => _difficultObject[CurrentDificult];

	PlayerData.Difficult CurrentDificult => PlayerDataContainer.Instance.SelectedDifficult.Value;

	private void Awake()
	{
		foreach (Brain brain in _difficultObject.Values)
		{
			brain.gameObject.SetActive(false);
		}
		CurrentBrain.gameObject.SetActive(true);
	}
}
