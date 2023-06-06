using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargePowerBox : Quest
{
	[SerializeField] private PowerBox _powerBox;
	private bool _isCharged;

	private void OnEnable()
	{
		_powerBox.PowerBoxIsCharged.AddListener(OnCharge);
	}

	private void OnDisable()
	{
		_powerBox.PowerBoxIsCharged.RemoveListener(OnCharge);
	}

	public override void OnBegin()
	{
		base.OnBegin();
		if (_isCharged)
		{
			Complete();
		}
	}

	private void OnCharge()
	{
		_isCharged = true;
		if (QuestIsStarted)
		{
			Complete();
		}
	}
}
