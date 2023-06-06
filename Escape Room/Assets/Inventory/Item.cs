using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
	[SerializeField] private string _inGameName = "<item name>";

	public string InGameName => _inGameName;
}
