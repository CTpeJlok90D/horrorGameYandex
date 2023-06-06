using TMPro;
using UnityEngine;

public class HintCountView : MonoBehaviour
{
	[SerializeField] private TMP_Text _caption;

	private void OnEnable()
	{
		PlayerDataContainer.Instance.HintCount.Changed.AddListener(OnCountChanged);
		OnCountChanged(PlayerDataContainer.Instance.HintCount.Value);
	}

	private void OnDisable()
	{
		if (PlayerDataContainer.HaveInstance())
			PlayerDataContainer.Instance.HintCount.Changed.RemoveListener(OnCountChanged);
	}

	private void OnCountChanged(int newValue)
	{
		_caption.text = newValue.ToString();
	}
}
