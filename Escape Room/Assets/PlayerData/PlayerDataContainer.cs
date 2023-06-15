using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDataContainer : Init
{
	private static PlayerDataContainer _instance;
	private UnityEvent<Achievement> _achievementAdded = new();
	private UnityEvent<PlayerData.Difficult> _unlockedDifficult = new();

	public bool IsMobileDevise => mobile;
	public UnityEvent<Achievement> AchievementAdded => _achievementAdded;
	public UnityEvent<PlayerData.Difficult> UnlockedDifficult => _unlockedDifficult;
	public ReactiveVariable<PlayerData.Difficult> SelectedDifficult { get; private set; }
	public ReactiveVariable<float> MouseSensivity { get; private set; }
	public ReactiveVariable<bool> AudioIsEnabled { get; private set; }
	public ReactiveVariable<int> CoinCount { get; private set; }
	public ReactiveVariable<int> HintCount { get; private set; }
	public ReactiveVariable<bool> IsFirstPlay { get; private set; }

	public string[] UnlockedAchievemetns => playerData.UnlockedAchievemetns.ToArray();
	public PlayerData.Difficult[] UnlockedDifficultsArray => playerData.UnlockedDifficults.ToArray();
	

	public static bool HaveInstance() => _instance != null;
	public static PlayerDataContainer Instance => _instance;

	public void AddDifficult(PlayerData.Difficult difficult)
	{
		if (playerData.UnlockedDifficults.Contains(difficult))
		{
			return;
		}

		playerData.UnlockedDifficults.Add(difficult);
		_unlockedDifficult.Invoke(difficult);
	}

	public void AddAchievement(Achievement achievement)
	{
		if (playerData.UnlockedAchievemetns.Contains(achievement.name))
		{
			return;
		}

		playerData.UnlockedAchievemetns.Add(achievement.name);
		_achievementAdded.Invoke(achievement);
	}

	protected new void Awake()
	{
		base.Awake();
		if (_instance != null)
		{
			Destroy(gameObject);
			return;
		}
		_instance = this;
		LoadPlayerData();
		DontDestroyOnLoad(gameObject);
	}

	private void OnEnable()
	{
		SelectedDifficult.Changed.AddListener(PlayerDataUpload);
		MouseSensivity.Changed.AddListener(PlayerDataUpload);
		AudioIsEnabled.Changed.AddListener(PlayerDataUpload);
		CoinCount.Changed.AddListener(PlayerDataUpload);
		HintCount.Changed.AddListener(PlayerDataUpload);
		IsFirstPlay.Changed.AddListener(PlayerDataUpload);
	}

	private void OnDisable()
	{
		if (playerData == null || SelectedDifficult == null || MouseSensivity == null || AudioIsEnabled == null || CoinCount == null || HintCount == null || IsFirstPlay == null)
		{
			return;
		}
		SelectedDifficult.Changed.RemoveListener(PlayerDataUpload);
		MouseSensivity.Changed.RemoveListener(PlayerDataUpload);
		AudioIsEnabled.Changed.RemoveListener(PlayerDataUpload);
		CoinCount.Changed.RemoveListener(PlayerDataUpload);
		HintCount.Changed.RemoveListener(PlayerDataUpload);
		IsFirstPlay.Changed.RemoveListener(PlayerDataUpload);
	}

	private void PlayerDataUpload(PlayerData.Difficult difficult) => PlayerDataUpload();
	private void PlayerDataUpload(int value) => PlayerDataUpload();
	private void PlayerDataUpload(bool value) => PlayerDataUpload();
	private void PlayerDataUpload(float value) => PlayerDataUpload();
	
	private void PlayerDataUpload()
	{
#if UNITY_EDITOR

		if (uploadData == false)
		{
			return;
		}
#endif
		playerData.SelectedDifficult =  SelectedDifficult.Value;
		playerData.MouseSensivity = MouseSensivity.Value;
		playerData.AudioIsEnabled = AudioIsEnabled.Value;
		playerData.CoinCount = CoinCount.Value;
		playerData.HintCount = HintCount.Value;
		playerData.IsFirstPlay = IsFirstPlay.Value;

		SavePlayerData();
	}

	public static void SavePlayerData()
	{
		_instance.Save();
	}

	private void LoadPlayerData()
	{
		Debug.Log("Загрузка данных игрока");

		SelectedDifficult = new(playerData.SelectedDifficult);
		MouseSensivity = new(playerData.MouseSensivity);
		AudioIsEnabled = new(playerData.AudioIsEnabled);
		CoinCount = new(playerData.CoinCount);
		HintCount = new(playerData.HintCount);
		IsFirstPlay = new(playerData.IsFirstPlay);
		IsFirstPlay = new(playerData.IsFirstPlay);
	}

#if UNITY_EDITOR

	private bool uploadData = true;

	private void OnValidate()
	{
		if (playerData == null || SelectedDifficult == null || MouseSensivity == null || AudioIsEnabled == null || CoinCount == null || HintCount == null || IsFirstPlay == null)
		{
			return;
		}
		uploadData = false;
		SelectedDifficult.Value = playerData.SelectedDifficult;
		MouseSensivity.Value = playerData.MouseSensivity;
		AudioIsEnabled.Value = playerData.AudioIsEnabled;
		CoinCount.Value = playerData.CoinCount;
		HintCount.Value = playerData.HintCount;
		IsFirstPlay.Value = playerData.IsFirstPlay;
		uploadData = true;
	}
#endif
}