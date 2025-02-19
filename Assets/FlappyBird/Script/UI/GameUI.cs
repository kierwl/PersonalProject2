using StackNamespace;
using System;
using TMPro;
using UnityEngine;

public class GameUI : BaseUI
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI BestScoreText;
     
    private int BestScore;

    private void Start()
    {
        BestScore = PlayerPrefs.GetInt("FlappyBestScore", 0); // �ְ� ���� �ҷ�����
        UpdateBestScoreText();
    }

    public void UpdateScoreText(int score)
    {
        
        scoreText.text = score.ToString();

        // �ְ� ���� ����
        if (score > BestScore)
        {
            BestScore = score;
            PlayerPrefs.SetInt("FlappyBestScore", BestScore);
            UpdateBestScoreText();
        }
    }

    private void UpdateBestScoreText()
    {
        BestScoreText.text = $"Best Score: {BestScore}";
    }


    protected override UIState GetUIState()
    {
        return UIState.Game;
    }
}
