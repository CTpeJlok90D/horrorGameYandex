using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
	public class TabButton : Button
	{
		[SerializeField] private UnityEvent<TabButton> _onTabClick = new();

		public UnityEvent<TabButton> OnTabClick => _onTabClick;

		protected override void OnEnable()
		{
			base.OnEnable();
			onClick.AddListener(OnClick);
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			onClick.RemoveListener(OnClick);
		}

		private void OnClick()
		{
			_onTabClick.Invoke(this);
		}
	}
}