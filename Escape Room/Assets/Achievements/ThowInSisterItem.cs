using UnityEngine;

public class ThowInSisterItem : MonoBehaviour
{
	[SerializeField] private Achievement _achievement;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.TryGetComponent(out Book book))
		{
			PlayerDataContainer.Instance.AddAchievement(_achievement);
		}
	}
}
