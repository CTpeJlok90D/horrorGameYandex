using UnityEngine;

public class Waster : MonoBehaviour
{
	[SerializeField] private Achievement _achievement;
	[SerializeField] private int _requestToAhievement = 3;
	[SerializeField] private DayCounter _dayCounter;
	private int _hintUsedCount = 0;
	private int _previewCount;

	private void Awake()
	{
		_previewCount = PlayerDataContainer.Instance.HintCount.Value;
	}
	private void OnEnable()
	{
		PlayerDataContainer.Instance.HintCount.Changed.AddListener(OnValueChanged);
		_dayCounter.DayEnded.AddListener(ResetCounter);
	}
	private void OnDisable()
	{
		PlayerDataContainer.Instance.HintCount.Changed.RemoveListener(OnValueChanged);
		_dayCounter.DayEnded.RemoveListener(ResetCounter);
	}

	private void ResetCounter()
	{
		_hintUsedCount = 0;
	}

	private void OnValueChanged(int newValue)
	{
		if (_previewCount > newValue)
		{
			_hintUsedCount++;
		}
		_previewCount = newValue;
		if (_hintUsedCount == _requestToAhievement)
		{
			PlayerDataContainer.Instance.AddAchievement(_achievement);
		}
	}
}