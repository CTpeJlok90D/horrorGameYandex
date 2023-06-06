using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementUIElement : MonoBehaviour
{
	[SerializeField] private Image _image;
	[SerializeField] private TMP_Text _achievementNameCaption;
	[SerializeField] private TMP_Text _achievementHintCaption;
	[SerializeField] private GameObject _unlockedMark;

	private Achievement _achievement;

	public void Init(Achievement achievement)
	{
		_achievement = achievement;

		_image.sprite = _achievement.Sprite;
		_achievementNameCaption.text = _achievement.ViewName;
		_achievementHintCaption.text = _achievement.Hint;
		_unlockedMark.SetActive(_achievement.IsUnlocked);
	}
}
