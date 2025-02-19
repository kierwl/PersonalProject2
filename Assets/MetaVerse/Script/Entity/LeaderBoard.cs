using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Metaverse;
using UnityEngine.UI;
using TMPro;


public class LeaderBoard : MonoBehaviour, IInteractable
{
    private Animator animator;
    private bool isOpen = false;

    [SerializeField] private GameObject uiPanel; // 점수 UI 패널
    public TextMeshProUGUI StackbestScoreText;
    public TextMeshProUGUI FlappybestScoreText;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();

        if (uiPanel == null)
        {
            Debug.LogWarning("UI 패널이 설정되지 않았습니다!", this);
            return;
        }
        uiPanel.SetActive(false); // 처음엔 비활성화

        UpdateLeaderboard(); ; // 시작 시 점수 갱신
    }

    /// <summary>
    /// UI에 점수 업데이트
    /// </summary>
    public void UpdateLeaderboard()
    {
        int stackHighScore = ScoreManager.LoadStackBestScore();
        int flappyHighScore = ScoreManager.LoadFlappyBestScore();

        StackbestScoreText.text = $" : {stackHighScore}";
        FlappybestScoreText.text = $" : {flappyHighScore}";
    }

    /// <summary>
    /// 인터랙션 (UI 토글)
    /// </summary>
    public void Interact()
    {
        isOpen = !isOpen;

        if (animator != null)
            animator.SetBool("isOpen", isOpen);

        if (uiPanel != null)
        {
            uiPanel.SetActive(isOpen);

            if (isOpen)
                UpdateLeaderboard(); // UI 활성화 시 점수 갱신
        }

        Debug.Log(isOpen ? "리더보드 ON! UI 활성화" : " 리더보드 OFF! UI 비활성화");
    }
}




