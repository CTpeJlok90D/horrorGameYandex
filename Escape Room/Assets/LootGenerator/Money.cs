using UnityEngine;

public class Money : MonoBehaviour
{
	[SerializeField] private Interacteble _interacteble;
	[SerializeField] private Vector2Int _amoutRange;
	[SerializeField] private string _pickUpMessage = "You picked up {0} moneny";

	private void OnEnable()
	{
		_interacteble.Interacted.AddListener(OnInteract);
	}

	private void OnDisable()
	{
		_interacteble.Interacted.RemoveListener(OnInteract);
	}

	private void OnInteract(Interacteble sender, InteractContext info)
	{
		int amout = Random.Range(_amoutRange[0], _amoutRange[1] + 1);
		PlayerDataContainer.Instance.CoinCount.Value += amout;
		info.PlayerMessageView.ShowMessage(string.Format(_pickUpMessage, amout));
		Destroy(this.gameObject);
	}

	private void OnValidate()
	{
		if (_amoutRange[0] > _amoutRange[1])
		{
			(_amoutRange[0], _amoutRange[1]) = (_amoutRange[1], _amoutRange[0]);
		}
	}
}
