using Metaverse;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour,IInteractable
{
    [SerializeField] private string targetSceneName; // 이동할 씬 이름

    public void Interact()
    {
        if (!string.IsNullOrEmpty(targetSceneName))
        {
            Debug.Log($"포탈 작동! '{targetSceneName}'로 이동합니다.");
            SceneManager.LoadScene(targetSceneName);
        }
        else
        {
            Debug.LogError("targetSceneName이 설정되지 않았습니다!");
        }
    }
}
