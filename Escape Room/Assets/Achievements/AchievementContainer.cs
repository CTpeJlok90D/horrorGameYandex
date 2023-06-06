using UnityEngine;

public class AchievementContainer : MonoBehaviour
{
	[SerializeField] private Achievement _achievement;

	public Achievement Achievement => _achievement;

	public void GiveAchievement()
	{
		PlayerDataContainer.Instance.AddAchievement(_achievement);
	}
}
