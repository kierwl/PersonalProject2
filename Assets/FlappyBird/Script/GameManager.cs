using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameEndHandler gameEndHandler;
    public static GameManager instance;
    private UIManager uiManager;
    private int currentScore = 0;
    private bool isGameOver = false;
    GameUI gameUI;
    public static GameManager Instance
    {
        get { return instance; }
    }
   

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        uiManager = FindObjectOfType<UIManager>();
    }

    private void Start()
    {
        Time.timeScale = 0; // 게임 시작 시 시간 정상화
        uiManager.UpdateScore(currentScore);
    }


    public void AddScore(int score)
    {
        currentScore += score;
        uiManager.UpdateScore(currentScore);
        Debug.Log("Score: " + currentScore);
    }
    public int GetCurrentScore()
    {
        return currentScore;
    }

    public void GameOver()
    {
        if (isGameOver) return;
        Debug.Log("Game Over");
        ScoreManager.SaveStackBestScore(currentScore);
        gameEndHandler.OnGameEnd(currentScore);

        Time.timeScale = 0; // 게임 정지
        uiManager.SetGameOver(); // UI 변경 (게임 오버 화면 활성화)
    }

    
    public void StartGame()
    {
        isGameOver = false;
        currentScore = 0; // 점수 초기화
        Time.timeScale = 1; // 게임 정상 속도로 진행
        uiManager.SetPlayGame(); // 게임 UI 활성화
        
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // 다시 게임 진행 가능하도록 설정
        SceneLoader.ReloadCurrentScene(); // 씬 리로드
    }

    public static class SceneLoader
    {
        public static void ReloadCurrentScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
