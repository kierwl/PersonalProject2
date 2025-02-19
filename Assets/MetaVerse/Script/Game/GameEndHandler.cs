using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameEndHandler : MonoBehaviour
{

    public LeaderBoard leaderboard;

    public void OnGameEnd(int finalScore)
    {
        //ScoreManager.SaveBestScore(finalScore);
        leaderboard.UpdateLeaderboard();
    }
}
