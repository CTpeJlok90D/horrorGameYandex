using System.Collections.Generic;
using System.Linq;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DifficultChangePanel : MonoBehaviour
{
	[SerializeField] private Button _upDifficultButton;
	[SerializeField] private Button _downDifficultButton;
	[SerializeField] private TMP_Text _difficultNameCaption;
	[SerializeField] private TMP_Text _difficultDesciptionCaption;
	[SerializeField] private GameObject _lockImage;
	[SerializeField] private Button _playButton;
	[SerializeField] private UnityDictionarity<PlayerData.Difficult, string> _difficultNames;
	[SerializeField] private UnityDictionarity<PlayerData.Difficult, string> _difficultDescriptins;

	private List<PlayerData.Difficult> _diffficults = new();
	private int _currentDificultIndex;

	public PlayerData.Difficult CurrentDifficult => _diffficults[_currentDificultIndex];
	public int CurrentDificultIndex
	{
		get
		{
			return _currentDificultIndex;
		}
		set
		{
			_currentDificultIndex = value;

			if (_currentDificultIndex >= _diffficults.Count)
			{
				_currentDificultIndex = _diffficults.Count - 1;
			}

			if (_currentDificultIndex < 0)
			{
				_currentDificultIndex = 0;
			}

			_difficultNameCaption.text = _difficultNames[CurrentDifficult];
			_difficultDesciptionCaption.text = _difficultDescriptins[CurrentDifficult];

			bool condiction = PlayerDataContainer.Instance.UnlockedDifficultsArray.Contains(CurrentDifficult);
			_playButton.gameObject.SetActive(condiction);
			_lockImage.SetActive(condiction == false);
			if (condiction)
			{
				PlayerDataContainer.Instance.SelectedDifficult.Value = CurrentDifficult;
				return;
			}
		}
	}

	private void OnEnable()
	{
		CurrentDificultIndex = _currentDificultIndex;
		_upDifficultButton.onClick.AddListener(UpDifficult);
		_downDifficultButton.onClick.AddListener(DownDifficult);
	}

	private void OnDisable()
	{
		_upDifficultButton.onClick.RemoveListener(UpDifficult);
		_downDifficultButton.onClick.RemoveListener(DownDifficult);
	}

	private void UpDifficult()
	{
		CurrentDificultIndex++;
	}

	private void DownDifficult()
	{
		CurrentDificultIndex--;
	}

	private void Awake()
	{
		_diffficults = GetDifficults();
		CurrentDificultIndex = _diffficults.IndexOf(PlayerDataContainer.Instance.SelectedDifficult.Value);
	}

	private List<PlayerData.Difficult> GetDifficults()
	{
		return Enum.GetValues(typeof(PlayerData.Difficult)).Cast<PlayerData.Difficult>().ToList();
	}

}
