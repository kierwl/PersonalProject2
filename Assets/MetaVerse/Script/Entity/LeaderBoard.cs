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

    [SerializeField] private GameObject uiPanel; // ���� UI �г�
    public TextMeshProUGUI StackbestScoreText;
    public TextMeshProUGUI FlappybestScoreText;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();

        if (uiPanel == null)
        {
            Debug.LogWarning("UI �г��� �������� �ʾҽ��ϴ�!", this);
            return;
        }
        uiPanel.SetActive(false); // ó���� ��Ȱ��ȭ

        UpdateLeaderboard(); ; // ���� �� ���� ����
    }

    /// <summary>
    /// UI�� ���� ������Ʈ
    /// </summary>
    public void UpdateLeaderboard()
    {
        int stackHighScore = ScoreManager.LoadStackBestScore();
        int flappyHighScore = ScoreManager.LoadFlappyBestScore();

        StackbestScoreText.text = $" : {stackHighScore}";
        FlappybestScoreText.text = $" : {flappyHighScore}";
    }

    /// <summary>
    /// ���ͷ��� (UI ���)
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
                UpdateLeaderboard(); // UI Ȱ��ȭ �� ���� ����
        }

        Debug.Log(isOpen ? "�������� ON! UI Ȱ��ȭ" : " �������� OFF! UI ��Ȱ��ȭ");
    }
}




