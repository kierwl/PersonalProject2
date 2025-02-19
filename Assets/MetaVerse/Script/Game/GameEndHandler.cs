using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameEndHandler : MonoBehaviour
{
    private LeaderBoard leaderboard;

    void Start()
    {
        leaderboard = FindObjectOfType<LeaderBoard>();
        if (leaderboard == null)
        {
            Debug.LogError("LeaderBoard instance not found in the scene.");
        }
    }

    public void OnGameEnd(int finalScore)
    {
        ScoreManager.SaveStackBestScore(finalScore);
        ScoreManager.SaveFlappyBestScore(finalScore);
        if (leaderboard != null)
        {
            leaderboard.UpdateLeaderboard();
        }
        else
        {
            Debug.LogError("LeaderBoard instance is not assigned.");
        }
    }
}
