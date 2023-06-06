using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public sealed class MoveQuest : Quest
{
	[SerializeField] private float _beginStunTime = 3;
	public override void OnBegin()
	{
		base.OnBegin();
		InputSingletone.Instance.PlayerMovement.Move.started += OnMoveStarted;
		StartCoroutine(DisableMoveOn(_beginStunTime));
	}

	private IEnumerator DisableMoveOn(float seconds)
	{
		InputSingletone.Instance.PlayerMovement.Disable();
		yield return new WaitForSeconds(seconds);
		InputSingletone.Instance.PlayerMovement.Enable();
	}

	private void OnMoveStarted(InputAction.CallbackContext obj)
	{
		InputSingletone.Instance.PlayerMovement.Move.started -= OnMoveStarted;
		Complete();
	}

	private void OnDisable()
	{
		InputSingletone.Instance.PlayerMovement.Move.started -= OnMoveStarted;
	}
}