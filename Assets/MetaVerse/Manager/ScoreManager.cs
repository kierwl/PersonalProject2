using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int currentScore = 0;
    public int bestScore = 0;

    private string filePath;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        filePath = Application.persistentDataPath + "/score.json";
        LoadScore();
    }

    // ���� �߰�
    public void AddScore(int points)
    {
        currentScore += points;
        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            SaveScore();
        }
    }

    // ���� ���� (JSON ����)
    public void SaveScore()
    {
        ScoreData data = new ScoreData { bestScore = bestScore };
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(filePath, json);
    }

    // ���� �ҷ�����
    public void LoadScore()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            ScoreData data = JsonUtility.FromJson<ScoreData>(json);
            bestScore = data.bestScore;
        }
    }

    public void ResetScore()
    {
        currentScore = 0;
    }


    // ������ ������ Ŭ����
    [System.Serializable]
    public class ScoreData
    {
        public int bestScore;
    }
}   



