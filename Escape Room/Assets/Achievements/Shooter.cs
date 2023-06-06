using UnityEngine;

public class Shooter : MonoBehaviour
{
	[SerializeField] private BookThrower _thrower;
	[SerializeField] private int _throwCount = 3;
	[SerializeField] private Achievement _achievement;

	private void OnEnable()
	{
		_thrower.Throwed.AddListener(OnBookThrow);
	}

	private void OnDisable()
	{
		_thrower.Throwed.RemoveListener(OnBookThrow);
	}

	private void OnBookThrow(Book book) => OnBookThrow();
	private void OnBookThrow()
	{
		_throwCount -= 1;
		if (_throwCount <= 0)
		{
			PlayerDataContainer.Instance.AddAchievement(_achievement);
		}
	}
}
