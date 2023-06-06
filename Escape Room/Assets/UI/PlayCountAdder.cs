using UnityEngine;

public class PlayCountAdder : MonoBehaviour
{
	public void OnPlay()
	{
		PlayerDataContainer.Instance.IsFirstPlay.Value = false;
	}
}
