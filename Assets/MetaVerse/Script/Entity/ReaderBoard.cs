using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Metaverse;
using UnityEngine.UI;
public class ReaderBoard : MonoBehaviour, IInteractable
{
    private Animator animator;
    private bool isOpen = false;

    [SerializeField] private GameObject uiPanel; // UI �г�
    [SerializeField] private Text scoreText;
    [SerializeField] private Text bestScoreText;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();

        if (uiPanel != null)
        {
            uiPanel.SetActive(false); // ó������ ��Ȱ��ȭ
        }
        else
        {
            Debug.LogWarning("UI �г��� �Ҵ���� �ʾҽ��ϴ�!", this);
        }

        UpdateScoreUI(); // ���� ���� �� ���� ����
    }

    // UI ���� ����
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

        Debug.Log(isOpen ? "�������� ON! UI Ȱ��ȭ" : "�������� OFF! UI ��Ȱ��ȭ");

        if (uiPanel != null)
        {
            uiPanel.SetActive(isOpen);

            if (isOpen)
            {
                UpdateScoreUI(); // UI Ȱ��ȭ�� ���� ���� ����
            }
        }
    }
}


