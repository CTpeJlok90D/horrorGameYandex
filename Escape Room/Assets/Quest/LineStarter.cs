using System.Collections;
using UnityEngine;

public class LineStarter : MonoBehaviour
{
	[SerializeField] private QuestLine _pcQuestLine;
	[SerializeField] private QuestLine _mobileQuestLine;
	[SerializeField] private TitleView _titleView;
	[SerializeField] private float _delayBeforeHideBackGound = 0.5f;

	public IEnumerator Start()
	{
		if (PlayerDataContainer.Instance.IsMobileDevise)
		{
			_mobileQuestLine.StartLine();
		}
		else
		{
			_pcQuestLine.StartLine();
		}
		yield return new WaitForSeconds(_delayBeforeHideBackGound);
		_titleView.ShowBackgournd(0);
		_titleView.HideBackground();
	}
}