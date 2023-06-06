using UnityEngine;

public class AchievementUIListView : MonoBehaviour
{
	[SerializeField] private AchievementUIElement _elementPrefab;

	private void Awake()
	{
		Achievement[] allAchievements = Resources.LoadAll<Achievement>("");
		foreach (Achievement achievement in allAchievements)
		{
			Instantiate(_elementPrefab, transform).Init(achievement);
		}
	}
}