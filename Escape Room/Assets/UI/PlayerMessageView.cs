using DG.Tweening;
using TMPro;
using UnityEngine;

public class PlayerMessageView : MonoBehaviour
{
	[SerializeField] private TMP_Text TMP_Text;
	[SerializeField] private Color _showColor = Color.white;
	[SerializeField] private Color _hideColor = new Color(1, 1, 1, 0);

	private Sequence _currentSequence;

	private void Awake()
	{
		TMP_Text.text = "";
	}

	public void ShowMessage(string message)
	{
		TMP_Text.text = message;
		_currentSequence.Kill();
		_currentSequence = DOTween.Sequence().
		   Append(TMP_Text.DOColor(_showColor, 1.5f)).
		   Append(TMP_Text.DOColor(_hideColor, 1.5f));
		_currentSequence.AppendInterval(1f);
		_currentSequence.Play();
	}
}
