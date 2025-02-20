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
        public string speakerName; // ȭ�� �̸�
        public string[] sentences; // ��� �迭
        public Sprite portrait;    // ȭ�� �ʻ�ȭ
    }

    public TextMeshProUGUI nameText; // ȭ�� �̸� UI
    public TextMeshProUGUI dialogueText; // ��� �ؽ�Ʈ UI
    public Image portraitImage; // ĳ���� �ʻ�ȭ UI
    public GameObject dialoguePanel; // ���̾�α� �г�
    public float typingSpeed = 0.05f; // Ÿ���� ȿ�� �ӵ�

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
