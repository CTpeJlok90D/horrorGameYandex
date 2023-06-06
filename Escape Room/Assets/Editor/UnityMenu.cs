using System.IO;
using UnityEditor;
using UnityEngine;

public class UnityMenu
{
	[MenuItem("Tools/Take screenshot")]
	public static void TakeScreenshot()
	{
		string path = "Sceenshots";

		Directory.CreateDirectory(path);

		int i = 0;
		while (File.Exists($"{path}/{i}.png"))
		{
			i++;
		}

		ScreenCapture.CaptureScreenshot($"{path}/{i}.png");
	}
}
