using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementAnnounce : MonoBehaviour
{
	[SerializeField] private Image _achievementImage;
	[SerializeField] private TMP_Text _achievementCaption;
	[SerializeField] private TMP_Text _gotAchievementCaption;
	[SerializeField] private Color _showColor;
	[SerializeField] private Color _hideColor;
	[SerializeField] private float _announceTime = 5;
	[SerializeField] private float _interval = 1;

#if UNITY_EDITOR
	[SerializeField] private Achievement _announcedAchievement;

	[ContextMenu("Announce achivement")]
	private void Announce()
	{
		if (Application.isPlaying)
		{
			AnnounceAchivement(_announcedAchievement);
		}
	}
#endif

	private Sequence _imageSequence;

	private void OnEnable()
	{
		PlayerDataContainer.Instance.AchievementAdded.AddListener(AnnounceAchivement);
	}

	private void OnDisable()
	{
		if (PlayerDataContainer.HaveInstance())
			PlayerDataContainer.Instance.AchievementAdded.RemoveListener(AnnounceAchivement);
	}

	private void Awake()
	{
		_achievementImage.color = _hideColor;
		_achievementCaption.color = _hideColor;
		_gotAchievementCaption.color = _hideColor;
	}

	public void AnnounceAchivement(Achievement achievement)
	{
		_achievementImage.sprite = achievement.Sprite;
		_achievementCaption.text = achievement.ViewName;

		_imageSequence.Kill();

		_imageSequence = DOTween.Sequence().
			Append(_achievementImage.DOColor(_showColor, _announceTime)).
			Join(_achievementCaption.DOColor(_showColor, _announceTime)).
			Join(_gotAchievementCaption.DOColor(_showColor, _announceTime)).
			AppendInterval(_interval).
			Append(_achievementImage.DOColor(_hideColor, _announceTime)).
			Join(_achievementCaption.DOColor(_hideColor, _announceTime)).
			Join(_gotAchievementCaption.DOColor(_hideColor, _announceTime));
	}

	private void OnDestroy()
	{
		_imageSequence.Kill();
	}
}
