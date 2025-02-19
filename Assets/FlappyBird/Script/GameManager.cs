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
        Time.timeScale = 0; // ���� ���� �� �ð� ����ȭ
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

        Time.timeScale = 0; // ���� ����
        uiManager.SetGameOver(); // UI ���� (���� ���� ȭ�� Ȱ��ȭ)
    }

    
    public void StartGame()
    {
        isGameOver = false;
        currentScore = 0; // ���� �ʱ�ȭ
        Time.timeScale = 1; // ���� ���� �ӵ��� ����
        uiManager.SetPlayGame(); // ���� UI Ȱ��ȭ
        
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // �ٽ� ���� ���� �����ϵ��� ����
        SceneLoader.ReloadCurrentScene(); // �� ���ε�
    }

    public static class SceneLoader
    {
        public static void ReloadCurrentScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
