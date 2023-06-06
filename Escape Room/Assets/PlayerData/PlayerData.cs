using System;
using System.Collections.Generic;

[Serializable]
public class PlayerData
{
	public Difficult SelectedDifficult = Difficult.Normal;
	public float MouseSensivity = 0.25f;
	public bool AudioIsEnabled = true;
	public int CoinCount = 0;
	public int HintCount = 0;
	public bool IsFirstPlay = true;
	public List<string> UnlockedAchievemetns = new();
	public List<Difficult> UnlockedDifficults = new() { Difficult.VeryEasy };

	[Serializable]
	public enum Difficult
	{
		VeryEasy,
		Easy,
		Normal,
		Hard
	}
}