using Newtonsoft.Json;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.Assertions.Must;

public static class IOUtils
{
	public static string PLAYERPREFSAVENAME = "PlayerDataSave";
	public static void DeserializeGameDataFromJSONResource(ref GameData returnObject, string resourceFilePath)
	{
		TextAsset targetFile = Resources.Load<TextAsset>(resourceFilePath);
		if (targetFile == null)
        {
			Debug.Log(resourceFilePath);
			throw new ApplicationException($"{resourceFilePath} is missing");
        }
		try
		{
			returnObject = JsonConvert.DeserializeObject<GameData>(targetFile.text);
		}
		catch (Exception ex)
		{
			Debug.LogError($"Error in GameData reading: {ex.Message}");
		}
	}

    

    //Used in tool
    public static void DeserializeGameDataFromJSONFile(ref GameData returnObject, string fullpath)
	{
		if (File.Exists(fullpath))
		{
			try
			{
				string rawData = "";
				using (FileStream stream = new FileStream(fullpath, FileMode.Open))
				{
					using (StreamReader reader = new StreamReader(stream))
					{
						rawData = reader.ReadToEnd();
					}
				}
				//saveData = JsonUtility.FromJson<SaveData>(rawData);
				returnObject = JsonConvert.DeserializeObject<GameData>(rawData);

			}
			catch (Exception ex)
			{
				Debug.LogError($"Exception in DeserializeGameDataFromJSONFile : {ex.Message} | {ex.StackTrace}");
			}
		}
		else
		{
			Debug.LogError($"Missing file {fullpath}");
		}
	}


	public static void DeserializePlayerDataFromJSON(ref PlayerSavingData returnObject, string fullPath)
	{
		if (File.Exists(fullPath))
		{
			try
			{
				string rawData = "";
				using (FileStream stream = new FileStream(fullPath, FileMode.Open))
				{
					using (StreamReader reader = new StreamReader(stream))
					{
						rawData = reader.ReadToEnd();
					}
				}
				//saveData = JsonUtility.FromJson<SaveData>(rawData);
				returnObject = JsonConvert.DeserializeObject<PlayerSavingData>(rawData);

			}
			catch (Exception ex)
			{
				Debug.LogWarning($"Exceptoin in reading {fullPath} : {ex.StackTrace}");
				returnObject = new PlayerSavingData();
				returnObject.SetupFirstSave();
			}
		}
		else
		{
			Debug.LogWarning($"{fullPath} is missing, no player data loaded");
			returnObject = new PlayerSavingData();
			returnObject.SetupFirstSave();
		}
	}

	public static void SerializeClassToFile(object serializableClass, string fullpath)
	{
		try
		{
			Directory.CreateDirectory(Path.GetDirectoryName(fullpath));

			string dataJsonString = JsonConvert.SerializeObject(serializableClass, Formatting.Indented);
			using (FileStream stream = new FileStream(fullpath, FileMode.Create))
			{
				using (StreamWriter writer = new StreamWriter(stream))
				{
					writer.Write(dataJsonString);
				}
			}

		}
		catch (Exception ex)
		{
			Debug.LogError($"Exception in SerializeClassToFile : {ex.Message} | {ex.StackTrace}");
			throw ex;
		}
	}
}

