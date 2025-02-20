using Metaverse;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCustomization : MonoBehaviour// IInteractable
{
    
    public Animator animator; // ĳ���� �ִϸ�����
    public AnimatorOverrideController[] skinOverrides; // ��Ų ����Ʈ
    public Image skinPreview; // UI���� �̸����� �̹���
    public Sprite[] skinSprites; // ��Ų �̸����� �̹��� ����Ʈ
    public TextMeshProUGUI skinNameText; // ��Ų �̸� ǥ�� (�ɼ�)

    private int currentSkinIndex = 0;

    public void Start()
    {
        LoadCustomization(); // ����� ������ �ҷ�����
    }

    public void ChangeSkin()
    {
        // ��Ų ����
        currentSkinIndex = (currentSkinIndex + 1) % skinOverrides.Length;
        animator.runtimeAnimatorController = skinOverrides[currentSkinIndex];

        // UI ������Ʈ
        if (skinPreview != null)
            skinPreview.sprite = skinSprites[currentSkinIndex];

        if (skinNameText != null)
            skinNameText.text = "Skin: " + (currentSkinIndex + 1);

        SaveCustomization();
    }

    private void SaveCustomization()
    {
        PlayerPrefs.SetInt("SelectedSkin", currentSkinIndex);
        PlayerPrefs.Save();

    }
    private void LoadCustomization()
    {
        if (PlayerPrefs.HasKey("SelectedSkin"))
        {
            currentSkinIndex = PlayerPrefs.GetInt("SelectedSkin");
            animator.runtimeAnimatorController = skinOverrides[currentSkinIndex];

        }
    }
}
