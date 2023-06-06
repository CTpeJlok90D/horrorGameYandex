using UnityEngine;
using UnityEngine.Events;

public class PlayerDataContainer : MonoBehaviour
{
	[SerializeField] private bool _isMobileDevice = true;
	private static PlayerDataContainer _instance;
	private UnityEvent<Achievement> _achievementAdded = new();
	private UnityEvent<PlayerData.Difficult> _unlockedDifficult = new();

	public bool IsMobileDevise => _isMobileDevice;
	public UnityEvent<Achievement> AchievementAdded => _achievementAdded;
	public UnityEvent<PlayerData.Difficult> UnlockedDifficult => _unlockedDifficult;
	public ReactiveVariable<PlayerData.Difficult> SelectedDifficult { get; private set; }
	public ReactiveVariable<float> MouseSensivity { get; private set; }
	public ReactiveVariable<bool> AudioIsEnabled { get; private set; }
	public ReactiveVariable<int> CoinCount { get; private set; }
	public ReactiveVariable<int> HintCount { get; private set; }
	public ReactiveVariable<bool> IsFirstPlay { get; private set; }

	public string[] UnlockedAchievemetns => _data.UnlockedAchievemetns.ToArray();
	public PlayerData.Difficult[] UnlockedDifficultsArray => _data.UnlockedDifficults.ToArray();
	

	[SerializeField] private PlayerData _data = new();

	public static bool HaveInstance() => _instance != null;
	public static PlayerDataContainer Instance => _instance;

	public void AddDifficult(PlayerData.Difficult difficult)
	{
		if (_data.UnlockedDifficults.Contains(difficult))
		{
			return;
		}

		_data.UnlockedDifficults.Add(difficult);
		_unlockedDifficult.Invoke(difficult);
	}

	public void AddAchievement(Achievement achievement)
	{
		if (_data.UnlockedAchievemetns.Contains(achievement.name))
		{
			return;
		}

		_data.UnlockedAchievemetns.Add(achievement.name);
		_achievementAdded.Invoke(achievement);
	}

	private void Awake()
	{
		if (_instance != null)
		{
			Destroy(gameObject);
			return;
		}
		_instance = this;
		LoadPlayerData();
		DontDestroyOnLoad(gameObject);
		IsMobileDeviceCheck();
	}
	private void IsMobileDeviceCheck()
	{
		Debug.Log("Проверка мобильного устройства");
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
		if (_data == null || SelectedDifficult == null || MouseSensivity == null || AudioIsEnabled == null || CoinCount == null || HintCount == null || IsFirstPlay == null)
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
		_data.SelectedDifficult =  SelectedDifficult.Value;
		_data.MouseSensivity = MouseSensivity.Value;
		_data.AudioIsEnabled = AudioIsEnabled.Value;
		_data.CoinCount = CoinCount.Value;
		_data.HintCount = HintCount.Value;
		_data.IsFirstPlay = IsFirstPlay.Value;

		SavePlayerData();
	}

	private void LoadPlayerData()
	{
		SelectedDifficult = new(_data.SelectedDifficult);
		MouseSensivity = new(_data.MouseSensivity);
		AudioIsEnabled = new(_data.AudioIsEnabled);
		CoinCount = new(_data.CoinCount);
		HintCount = new(_data.HintCount);
		IsFirstPlay = new(_data.IsFirstPlay);
		IsFirstPlay = new(_data.IsFirstPlay);

		Debug.Log("Загрузка данных игрока.");
	}

	public static void SavePlayerData()
	{
		Debug.Log("Сохранение данных игрока");
	}

#if UNITY_EDITOR

	private bool uploadData = true;

	private void OnValidate()
	{
		if (_data == null || SelectedDifficult == null || MouseSensivity == null || AudioIsEnabled == null || CoinCount == null || HintCount == null || IsFirstPlay == null)
		{
			return;
		}
		uploadData = false;
		SelectedDifficult.Value = _data.SelectedDifficult;
		MouseSensivity.Value = _data.MouseSensivity;
		AudioIsEnabled.Value = _data.AudioIsEnabled;
		CoinCount.Value = _data.CoinCount;
		HintCount.Value = _data.HintCount;
		IsFirstPlay.Value = _data.IsFirstPlay;
		uploadData = true;
	}
#endif
}