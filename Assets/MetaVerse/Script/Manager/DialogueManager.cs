using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [System.Serializable]
    public class Dialogue
    {
        public string speakerName; // 화자 이름
        public string[] sentences; // 대사 배열
        public Sprite portrait;    // 화자 초상화
    }

    public TextMeshProUGUI nameText; // 화자 이름 UI
    public TextMeshProUGUI dialogueText; // 대사 텍스트 UI
    public Image portraitImage; // 캐릭터 초상화 UI
    public GameObject dialoguePanel; // 다이얼로그 패널
    public float typingSpeed = 0.05f; // 타이핑 효과 속도

    private Queue<string> sentences;
    private bool isTyping = false;

    void Start()
    {
        sentences = new Queue<string>();
        dialoguePanel.SetActive(false);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialoguePanel.SetActive(true);
        Time.timeScale = 0;
        nameText.text = dialogue.speakerName;
        portraitImage.sprite = dialogue.portrait;

        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (isTyping) return;

        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        isTyping = true;
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSecondsRealtime(typingSpeed);
        }
        isTyping = false;
    }

    void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        Time.timeScale = 1;
    }
}
