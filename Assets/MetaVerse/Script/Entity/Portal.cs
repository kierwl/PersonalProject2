using Metaverse;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour,IInteractable
{
    [SerializeField] private string targetSceneName; // �̵��� �� �̸�

    public void Interact()
    {
        if (!string.IsNullOrEmpty(targetSceneName))
        {
            Debug.Log($"��Ż �۵�! '{targetSceneName}'�� �̵��մϴ�.");
            SceneManager.LoadScene(targetSceneName);
        }
        else
        {
            Debug.LogError("targetSceneName�� �������� �ʾҽ��ϴ�!");
        }
    }
}
