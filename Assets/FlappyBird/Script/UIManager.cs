using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public Button restartButton;  // 재시작 버튼
    public Button exitButton;     // 종료 버튼 추가

    private void Start()
    {
        if (restartButton == null)
        {
            Debug.LogError("Restart Button is not assigned in the Inspector!");
        }
        if (exitButton == null)
        {
            Debug.LogError("Exit Button is not assigned in the Inspector!");
        }
        if (scoreText == null)
        {
            Debug.LogError("scoreText is null");
            return;
        }

        restartButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);

        restartButton.onClick.AddListener(RestartGame); // 재시작 버튼 이벤트
        exitButton.onClick.AddListener(ExitGame);       // 종료 버튼 이벤트
    }

    public void SetRestart()
    {
        restartButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true); // 게임 오버 시 종료 버튼도 활성화
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 현재 씬 다시 로드
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("MetaVerse");
    }
}
