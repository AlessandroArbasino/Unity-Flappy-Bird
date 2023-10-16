using JetBrains.Annotations;

[System.Serializable]
public class SaveData
{
	public GameData gameData;
	public PlayerSavingData playerData;

	public SaveData()
	{
		gameData = new GameData();
		playerData = new PlayerSavingData();
	}
}
