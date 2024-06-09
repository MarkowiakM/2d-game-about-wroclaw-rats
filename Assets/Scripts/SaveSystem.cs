using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem {
    public static void SavePlayer(LevelManager levelManager, int[] unlockedLevels, float[,] timeAndCoins)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.bin";
        FileStream stream = new FileStream(path, FileMode.Create);
    
        PlayerData data = new PlayerData(levelManager, unlockedLevels, timeAndCoins);
        Debug.Log("Saved to " + path);
        Debug.Log("Saved: Time and coins for 1st level: " + timeAndCoins[0, 0] + ", " + timeAndCoins[0, 1]);
        Debug.Log("Saved: Time and coins for 2nd level: " + timeAndCoins[1, 0] + ", " + timeAndCoins[1, 1]);
        Debug.Log("Saved: Time and coins for 3rd level: " + timeAndCoins[2, 0] + ", " + timeAndCoins[2, 1]);
        Debug.Log("Saved: Time and coins for 4th level: " + timeAndCoins[3, 0] + ", " + timeAndCoins[3, 1]);
        Debug.Log("Saved: Time and coins for 5th level: " + timeAndCoins[4, 0] + ", " + timeAndCoins[4, 1]);
        Debug.Log("Saved: Time and coins for 6th level: " + timeAndCoins[5, 0] + ", " + timeAndCoins[5, 1]);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.bin";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            Debug.Log("Loaded from " + path);
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
   
