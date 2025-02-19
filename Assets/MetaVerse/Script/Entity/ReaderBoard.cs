using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Metaverse;
using UnityEngine.UI;
public class ReaderBoard : MonoBehaviour, IInteractable
{
    private Animator animator;
    private bool isOpen = false;

    [SerializeField] private GameObject uiPanel; // UI 패널
    [SerializeField] private Text scoreText;
    [SerializeField] private Text bestScoreText;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();

        if (uiPanel != null)
        {
            uiPanel.SetActive(false); // 처음에는 비활성화
        }
        else
        {
            Debug.LogWarning("UI 패널이 할당되지 않았습니다!", this);
        }

        UpdateScoreUI(); // 게임 시작 시 점수 갱신
    }

    // UI 점수 갱신
    private void UpdateScoreUI()
    {
        if (scoreText != null && bestScoreText != null)
        {
            scoreText.text = "Score: " + ScoreManager.instance.currentScore;
            bestScoreText.text = "Best: " + ScoreManager.instance.bestScore;
        }
    }

    public void Interact()
    {
        isOpen = !isOpen;
        animator.SetBool("isOpen", isOpen);

        Debug.Log(isOpen ? "리더보드 ON! UI 활성화" : "리더보드 OFF! UI 비활성화");

        if (uiPanel != null)
        {
            uiPanel.SetActive(isOpen);

            if (isOpen)
            {
                UpdateScoreUI(); // UI 활성화할 때만 점수 갱신
            }
        }
    }
}


