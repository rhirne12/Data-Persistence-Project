using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.LookDev;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string player;
    public int highScore;
    public string playerHighScore;

    // Start() and update() delete as we don't need them

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public string playerNameHigh;
        public int highScore;
    }

    public void SaveBestScore()
    {
        SaveData data = new SaveData();
        data.playerNameHigh = player;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerHighScore = data.playerNameHigh;
            highScore = data.highScore;
        }
    }
}


