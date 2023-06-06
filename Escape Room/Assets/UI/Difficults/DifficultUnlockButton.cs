using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DifficultUnlockButton : DifficultListElement
{
	[SerializeField] private TMP_Text _costCaption;
	[SerializeField] private Button _button;
	private static Dictionary<PlayerData.Difficult, int> _difficultCost = new()
	{
		[PlayerData.Difficult.VeryEasy] = 100,
		[PlayerData.Difficult.Easy] = 100,
		[PlayerData.Difficult.Normal] = 100,
		[PlayerData.Difficult.Hard] = 100,
	};

	private void OnEnable()
	{
		_button.onClick.AddListener(OnClick);
	}

	private void OnDisable()
	{
		_button.onClick.RemoveListener(OnClick);
	}

	public override void Init(string caption, PlayerData.Difficult difficult)
	{
		base.Init(caption, difficult);
		_costCaption.text = _difficultCost[difficult].ToString();
	}

	private void OnClick()
	{
		if (PlayerDataContainer.Instance.CoinCount.Value >= _difficultCost[Difficult])
		{
			PlayerDataContainer.Instance.CoinCount.Value -= _difficultCost[Difficult];
			PlayerDataContainer.Instance.AddDifficult(Difficult);
		}
	}
}
