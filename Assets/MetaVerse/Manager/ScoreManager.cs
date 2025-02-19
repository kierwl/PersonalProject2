using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    private const string StackBestScoreKey = "StackBestScore";
    private const string FlappyBestScoreKey = "FlappyBestScore";
    // 스택 게임 최고 점수 저장
    public static void SaveStackBestScore(int score)
    {
        int currentBestScore = PlayerPrefs.GetInt(StackBestScoreKey, 0);
        if (score > currentBestScore)
        {
            PlayerPrefs.SetInt(StackBestScoreKey, score);
            PlayerPrefs.Save();
        }
    }

    // 플래피버드 최고 점수 저장
    public static void SaveFlappyBestScore(int score)
    {
        int currentBestScore = PlayerPrefs.GetInt(FlappyBestScoreKey, 0);
        if (score > currentBestScore)
        {
            PlayerPrefs.SetInt(FlappyBestScoreKey, score);
            PlayerPrefs.Save();
        }
    }
    // 최고 점수 불러오기
    public static int LoadStackBestScore()
    {
        return PlayerPrefs.GetInt(StackBestScoreKey, 0);
    }

    public static int LoadFlappyBestScore()
    {
        return PlayerPrefs.GetInt(FlappyBestScoreKey, 0);
    }

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



}   



