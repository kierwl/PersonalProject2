using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace StackNamespace
{
    public class HomeUI : BaseUI
    {
        Button startButton;
        Button exitButton;

        protected override UIState GetUIState()
        {
            return UIState.Home;
        }

        public override void Init(UIManager uiManager)
        {
            base.Init(uiManager);

            startButton = transform.Find("StartButton").GetComponent<Button>();
            exitButton = transform.Find("ExitButton").GetComponent<Button>();

            startButton.onClick.AddListener(OnClickStartButton);
            exitButton.onClick.AddListener(OnClickExitButton);
        }

        void OnClickStartButton()
        {
            uiManager.OnClickStart();
        }

        void OnClickExitButton()
        {
            SceneManager.LoadScene("MetaVerse");
        }

    }
}