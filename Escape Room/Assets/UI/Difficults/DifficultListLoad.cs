using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DifficultListLoad : MonoBehaviour
{
	[SerializeField] private DifficultListElement _elementPrefab;
	[SerializeField] private UnityDictionarity<PlayerData.Difficult, string> _difficultName;
	[SerializeField] private LoadType _loadType = LoadType.Unlocked;

	private void Awake()
	{
		UpdateDifficultList();
	}

	private void OnEnable()
	{
		PlayerDataContainer.Instance.UnlockedDifficult.AddListener(UpdateDifficultList);
		UpdateDifficultList();
	}

	private void OnDisable()
	{
		if (PlayerDataContainer.HaveInstance())
		{
			PlayerDataContainer.Instance.UnlockedDifficult.RemoveListener(UpdateDifficultList);
		}
	}

	private void UpdateDifficultList(PlayerData.Difficult value) => UpdateDifficultList();
	private void UpdateDifficultList()
	{
		foreach (Transform child in transform)
		{
			Destroy(child.gameObject);
		}

		List<PlayerData.Difficult> difficults = GetDifficults();

		foreach (PlayerData.Difficult difficult in difficults)
		{
			Instantiate(_elementPrefab, transform).Init(_difficultName[difficult], difficult);
		}
	}

	private List<PlayerData.Difficult> GetDifficults()
	{
		List<PlayerData.Difficult> difficults = new();

		switch (_loadType)
		{
			case LoadType.Unlocked:
			{
				difficults = PlayerDataContainer.Instance.UnlockedDifficultsArray.ToList();
				break;
			}

			case LoadType.Locked:
			{
				difficults = Enum.GetValues(typeof(PlayerData.Difficult)).Cast<PlayerData.Difficult>().ToList();
				foreach (PlayerData.Difficult difficult in difficults.ToArray())
				{
					if (PlayerDataContainer.Instance.UnlockedDifficultsArray.Contains(difficult))
					{
						difficults.Remove(difficult);
					}
				}
				break;
			}

			case LoadType.All:
			{
				difficults = Enum.GetValues(typeof(PlayerData.Difficult)).Cast<PlayerData.Difficult>().ToList();
				break;
			}	
		}

		return difficults;
	}

	private enum LoadType
	{
		Unlocked,
		Locked,
		All
	}
}
