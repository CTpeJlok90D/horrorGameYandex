using UnityEngine;

public class PlushkinSyndrome : MonoBehaviour
{
	[SerializeField] private Achievement _achievement;
	[SerializeField] private int _requestToAhievement = 100;
	private int _previewCount;

	private void Awake()
	{
		_previewCount = PlayerDataContainer.Instance.HintCount.Value;
	}
	private void OnEnable()
	{
		PlayerDataContainer.Instance.HintCount.Changed.AddListener(OnValueChanged);
	}
	private void OnDisable()
	{
		PlayerDataContainer.Instance.HintCount.Changed.RemoveListener(OnValueChanged);
	}

	private void OnValueChanged(int newValue)
	{
		if (newValue - _previewCount >= _requestToAhievement)
		{
			PlayerDataContainer.Instance.AddAchievement(_achievement);
		}
	}
}
