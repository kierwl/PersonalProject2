using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Topdown
{
    public class HomeUI : BaseUI
    {
        [SerializeField] private Button startButton;
        [SerializeField] private Button exitButton;

        public override void Init(UIManager uiManager)
        {
            base.Init(uiManager);
            startButton.onClick.AddListener(OnClickStartButton);
            exitButton.onClick.AddListener(OnClickExitButton);
        }

        public void OnClickStartButton()
        {
            GameManager.instance.StartGame();
            Debug.Log("Click");
        }

        public void OnClickExitButton()
        {
            Application.Quit();
        }

        protected override UIState GetUIState()
        {
            return UIState.Home;
        }
    }
}