using DG.Tweening;
using TMPro;
using UnityEngine;

public class QuestView : MonoBehaviour
{
	[SerializeField] private QuestLine _line;
	[SerializeField] private TitleView _titleView;
	[Header("QuestLineEnd")]
	[SerializeField] private bool _showFinelCaption = true;
	[SerializeField] private string _completeTitleCaption = "<Complete title caption>";
	[SerializeField] private string _completeSubtitleCaption = "<Complete hint caption>";


	private void OnEnable()
	{
		_line.QuestChanged.AddListener(OnQuestChanged);
		_line.Complited.AddListener(OnLineEnd);
	}

	private void OnDisable()
	{
		_line.QuestChanged.RemoveListener(OnQuestChanged);
		_line.Complited.RemoveListener(OnLineEnd);
	}

	private void OnQuestChanged(Quest quest)
	{
		AnnounceNewQuest(quest);
	}

	private void OnLineEnd()
	{
		_titleView.HideHint();
		if (_showFinelCaption)
		{
			_titleView.ShowTitle(_completeTitleCaption, _completeSubtitleCaption);
		}
	}

	private void AnnounceNewQuest(Quest quest)
	{
		_titleView.HideHint();
		_titleView.ShowTitle(quest.AnnounceTitle, quest.AnnounceSubtitle, () =>
		{
			_titleView.ShowHint(quest.Title, quest.Subtitle);
		});
	}
}
