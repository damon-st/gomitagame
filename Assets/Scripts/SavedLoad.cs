using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class SavedLoad 
{

    public static SavedLoad saved;

    public static List<Game> savedGames = new List<Game>();



    public static void Save()
    {
        savedGames.Add(Game.current);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedGames.gd");
        bf.Serialize(file, SavedLoad.savedGames);
        file.Close();
    }
    public static void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/savedGames.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
            SavedLoad.savedGames = (List<Game>)bf.Deserialize(file);
            file.Close();

        }
    }
}
