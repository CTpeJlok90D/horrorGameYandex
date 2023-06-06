using UnityEngine;
using AI.Tasks;
using UnityEngine.Events;

public class OpenCupboard : Task
{
	[SerializeField] private float _openDistance;
	[SerializeField] private UnityEvent _opened;
	[SerializeField] private PlayerCatcher _playerCather;
	public override void OnBegin()
	{
		base.OnBegin();
		Agent.destination = Info.PlaceForHide.transform.position;
	}

	public override void OnUpdate()
	{
		base.OnUpdate();
		if (Vector3.Distance(Info.PlaceForHide.transform.position, Agent.transform.position) >= _openDistance)
		{
			return;			
		}
		if (Info.PlaceForHide.PlayerMovement == null)
		{
			return;
		}
		_playerCather.AttackPlayer(Info.PlaceForHide.PlayerMovement.Character);
		Info.PlaceForHide.ThrowPlayer();
		_opened.Invoke();
	}
}
