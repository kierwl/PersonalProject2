using Metaverse;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCustomization : MonoBehaviour// IInteractable
{
    private Chest chest;
    public Animator animator; // 캐릭터 애니메이터
    public AnimatorOverrideController[] skinOverrides; // 스킨 리스트
    public Image skinPreview; // UI에서 미리보기 이미지
    public Sprite[] skinSprites; // 스킨 미리보기 이미지 리스트
    public TextMeshProUGUI skinNameText; // 스킨 이름 표시 (옵션)

    private int currentSkinIndex = 0;

    public void ChangeSkin()
    {
        // 스킨 변경
        currentSkinIndex = (currentSkinIndex + 1) % skinOverrides.Length;
        animator.runtimeAnimatorController = skinOverrides[currentSkinIndex];

        // UI 업데이트
        if (skinPreview != null)
            skinPreview.sprite = skinSprites[currentSkinIndex];

        if (skinNameText != null)
            skinNameText.text = "Skin: " + (currentSkinIndex + 1);


    }

}
