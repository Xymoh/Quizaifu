using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    
    public static SaveManager instance { get; private set; }
  


   
    //Things that are saved
    public int currentChair;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;
        DontDestroyOnLoad(gameObject);
        Load();
    }

 

    // Update is called once per frame

    public void Load()
    { 
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData_Storage data = (PlayerData_Storage)bf.Deserialize(file);
            currentChair = data.currentChair;
            file.Close();
        }
    }
    //Method for Saving data
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        PlayerData_Storage data = new PlayerData_Storage();

        data.currentChair = currentChair;

        bf.Serialize(file, data);
        file.Close();
    }
    //Class that stores 
[Serializable]
    class PlayerData_Storage
        {
        public int currentChair;

        }

}

//meble (chair,sofa,table)
//currency
//level
//4 potrzeby (helth, energia, jedzenie, szczescie)
