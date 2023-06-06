using System.Linq;
using UnityEngine;

[CreateAssetMenu()]
public class Achievement : ScriptableObject
{
	[SerializeField] private Sprite _sprite;
	[SerializeField] private string _viewName;
	[SerializeField] private string _hint;

	public Sprite Sprite => _sprite;
	public string ViewName => _viewName;
	public string Hint => _hint;
	public bool IsUnlocked => PlayerDataContainer.Instance.UnlockedAchievemetns.Contains(name);
}
