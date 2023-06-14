using UnityEngine;

public class Lucky : MonoBehaviour
{
	[SerializeField] private Achievement _achievement;
	[SerializeField] private int _requestToAhievement = 2;
	[SerializeField] private DayCounter _dayCounter;
	[SerializeField] private Quest _firstQuests;
	[SerializeField] private QuestLine _line;
	private int _deaths = 0;

	private void OnEnable()
	{
		_dayCounter.DayEnded.AddListener(OnNewDay);
	}
	private void OnDisable()
	{
		_dayCounter.DayEnded.RemoveListener(OnNewDay);
	}

	private void OnNewDay()
	{
		_deaths++;
		if (_deaths >= _requestToAhievement && _line.CurrentQuest == _firstQuests)
		{
			PlayerDataContainer.Instance.AddAchievement(_achievement);
		}
	}
}
