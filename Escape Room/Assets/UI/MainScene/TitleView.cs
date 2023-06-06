using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TitleView : MonoBehaviour
{
	[Header("Hint")]
	[SerializeField] private TMP_Text _titleCaption;
	[SerializeField] private TMP_Text _hintCaption;
	[Header("Annonce")]
	[SerializeField] private TMP_Text _newQuestAnnonceTitle;
	[SerializeField] private TMP_Text _newQuestAnnonce;
	[SerializeField] private float _announceTime = 5;
	[Header("Black background")]
	[SerializeField] private Image _backgournd;
	[SerializeField] private float _backgroundShowTime;
	[SerializeField] private Color _defualtBackgroundColor;
	[SerializeField] private Color _hidenBackgroundColor;

	private Tween _titleTween;
	private Tween _subtitleTween;
	private Tween _backgroundTween;

	public void ShowHint(string title, string subtitle)
	{
		_titleCaption.gameObject.SetActive(true);
		_hintCaption.gameObject.SetActive(true);
		_titleCaption.text = title;
		_hintCaption.text = subtitle;
	}

	public void ShowHint()
	{
		_titleCaption.gameObject.SetActive(true);
		_hintCaption.gameObject.SetActive(true);
	}

	public delegate void OnAnimationEnd();
	public void ShowTitle(string title, string subTitle, OnAnimationEnd onOnimationEnd = null)
	{
		_newQuestAnnonceTitle.gameObject.SetActive(true);
		_newQuestAnnonce.gameObject.SetActive(true);

		_newQuestAnnonceTitle.color = Color.white;
		_newQuestAnnonce.color = Color.white;
		_newQuestAnnonceTitle.text = title;
		_newQuestAnnonce.text = subTitle;

		_titleTween.Kill();
		_subtitleTween.Kill();

		_titleTween = _newQuestAnnonceTitle.DOColor(new Color(1, 1, 1, 0), _announceTime);
		_subtitleTween = _newQuestAnnonce.DOColor(new Color(1, 1, 1, 0), _announceTime).OnComplete(() =>
		{
			_newQuestAnnonceTitle.gameObject.SetActive(false);
			_newQuestAnnonce.gameObject.SetActive(false);
			onOnimationEnd?.Invoke();
		});
	}

	public void HideHint()
	{
		_titleCaption.gameObject.SetActive(false);
		_hintCaption.gameObject.SetActive(false);
	}
	private void OnDisable()
	{
		_titleTween.Kill();
		_subtitleTween.Kill();
		_backgroundTween.Kill();
	}

	public void ShowBackgournd(float time = -1, OnAnimationEnd onEndfunc = null)
	{
		if (time == -1)
		{
			time = _backgroundShowTime;
		}
		_backgroundTween = _backgournd.DOColor(_defualtBackgroundColor, time).OnComplete(() => onEndfunc?.Invoke());
	}

	public void HideBackground(float time = -1, OnAnimationEnd onEndfunc = null)
	{
		if (time == -1)
		{
			time = _backgroundShowTime;
		}
		_backgroundTween = _backgournd.DOColor(_hidenBackgroundColor, time).OnComplete(() => onEndfunc?.Invoke());
	}
}
