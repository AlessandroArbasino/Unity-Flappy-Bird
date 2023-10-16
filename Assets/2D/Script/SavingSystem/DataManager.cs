using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Saves and load all permanent informations
/// </summary>
public class DataManager : MonoBehaviour
{
	private static DataManager _instance = null;
	public static DataManager Instance { get => _instance; }

	public event Action OnDataChanged;
	void Awake()
	{
		DontDestroyOnLoad(gameObject);

		if (_instance == null)
		{
			_instance = this;
			SceneManager.activeSceneChanged += LoadGameDataInInterfaces;
			Debug.Log("LoadSaveDataFromJson");
			LoadSaveDataFromJson();
			LoadGameDataInInterfaces(SceneManager.GetActiveScene(), SceneManager.GetActiveScene());
		}

		else if (_instance != this)
			Destroy(gameObject);

	}

	public SaveData saveData;
	private List<ISaveable> SaveableObjects;

	private static string GAME_DATA_FILE_NAME = "GameData";//no extensin because it's in resources
    private static string PLAYER_DATA_FILE_NAME = "PlayerData.json";
	private static string DATA_DIR_PATH = "SaveData";


	private void Start()
	{
		//LoadSaveDataFromJson();
		//LoadGameDataInInterfaces(SceneManager.GetActiveScene(), SceneManager.GetActiveScene());
		//SaveGame();
	}



	public void SaveGame()
	{
		SaveableObjects = FindObjectsOfType<MonoBehaviour>(true).OfType<ISaveable>().ToList();
		foreach (ISaveable saveableObject in SaveableObjects)
		{
			saveableObject.SaveData(ref saveData);
		}
		SavePlayerData();
	}
	public void LoadGameDataInInterfaces(Scene current, Scene next)
	{
		SaveableObjects = FindObjectsOfType<MonoBehaviour>(true).OfType<ISaveable>().ToList();
		foreach (ISaveable saveableObject in SaveableObjects)
		{
			saveableObject.LoadData(saveData);
		}
	}

	private void SavePlayerData()
	{
		IOUtils.SerializeClassToFile(saveData.playerData, Path.Combine(Application.persistentDataPath, DATA_DIR_PATH, PLAYER_DATA_FILE_NAME));
	}

	public void LoadSaveDataFromJson()
	{
		SaveData saveData = new SaveData();
		IOUtils.DeserializePlayerDataFromJSON(ref saveData.playerData, Path.Combine(Application.persistentDataPath, DATA_DIR_PATH, PLAYER_DATA_FILE_NAME));
		IOUtils.DeserializeGameDataFromJSONResource(ref saveData.gameData, Path.Combine(DATA_DIR_PATH, GAME_DATA_FILE_NAME));
        this.saveData = saveData;
	}

	private void OnApplicationQuit()
	{
		Debug.Log("OnApplicationQuit");
		SaveGame();
	}

	private void OnApplicationFocus(bool focus)
	{
		if (!focus)
		{
			Debug.Log($"OnApplicationFocus: {focus}");
			SaveGame();
		}
	}

	public void ChangeData()
	{
		OnDataChanged?.Invoke();
	}
}

