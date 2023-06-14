using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class HintCountLoader : MonoBehaviour
{
	[SerializeField] private TMP_Text _text;
	[SerializeField] private QuestLine _line;
	[SerializeField] private Window _byhintsWindow;

	[SerializeField] private TitleView _titleView;
	[SerializeField] private string _hintUseTitle = "<Title>";
	[SerializeField] private string _hintUseSubtitle = "<Subtitle>";

	private void OnEnable()
	{
		InputSingletone.Instance.PlayerMovement.UseHint.started += UseHint;
		PlayerDataContainer.Instance.HintCount.Changed.AddListener(UpdateHintCount);
	}

	private void OnDisable()
	{
		InputSingletone.Instance.PlayerMovement.UseHint.started -= UseHint;
		PlayerDataContainer.Instance.HintCount.Changed.RemoveListener(UpdateHintCount);
	}

	private void Awake()
	{
		UpdateHintCount();
	}

	public void UpdateHintCount(int value) => UpdateHintCount();
	public void UpdateHintCount()
	{
		_text.text = PlayerDataContainer.Instance.HintCount.Value.ToString();
	}

	public void UseHint(InputAction.CallbackContext context)
	{
		UseHint();
	}

	public void UseHint()
	{
		if (PlayerDataContainer.Instance.HintCount.Value == 0)
		{
			_byhintsWindow.Open();
		}
		if (PlayerDataContainer.Instance.HintCount.Value > 0)
		{
			PlayerDataContainer.Instance.HintCount.Value--;
			_line.CurrentQuest.ShowHint();
			_titleView.ShowTitle(_hintUseTitle, _hintUseSubtitle);
			UpdateHintCount();
		}
	}
}
