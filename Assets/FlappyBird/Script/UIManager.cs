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
    public Button restartButton;  // ����� ��ư
    public Button exitButton;     // ���� ��ư �߰�

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

        restartButton.onClick.AddListener(RestartGame); // ����� ��ư �̺�Ʈ
        exitButton.onClick.AddListener(ExitGame);       // ���� ��ư �̺�Ʈ
    }

    public void SetRestart()
    {
        restartButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true); // ���� ���� �� ���� ��ư�� Ȱ��ȭ
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // ���� �� �ٽ� �ε�
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("MetaVerse");
    }
}
