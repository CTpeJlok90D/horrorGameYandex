using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
	[SerializeField] private QuestLine _mainQuestLine;
	[SerializeField] private TMP_Text _timeTextPlace;
	[SerializeField] private string _timeSpannedCaption = "This run was take a {0} hours, {1} minuts, {2} seconds";
	private DateTime _startTime;

	public const string TIME_FORMAT = "";

	private void OnEnable()
	{
		_mainQuestLine.Started += OnLineStart;
		_mainQuestLine.Complited.AddListener(OnLineEnd);
	}
	private void OnDisable()
	{
		_mainQuestLine.Started -= OnLineStart;
		_mainQuestLine.Complited.RemoveListener(OnLineEnd);
	}

	public void OnLineStart()
	{
		_startTime = DateTime.UtcNow;
	}

	public void OnLineEnd()
	{
		TimeSpan span = (DateTime.UtcNow - _startTime);
		_timeTextPlace.text = String.Format(_timeSpannedCaption, span.Hours, span.Minutes, span.Seconds);
	}
}
