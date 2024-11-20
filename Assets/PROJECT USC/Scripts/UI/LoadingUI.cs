using TMPro;
using UnityEngine.UI;

namespace USC
{
    public class LoadingUI : UIBase
    {
        public static LoadingUI Instance => UIManager.Singleton.GetUI<LoadingUI>(UIList.LoadingUI);

        public Image loadingBar;
        public TextMeshProUGUI loadingText;

        private void OnEnable()
        {
            loadingBar.fillAmount = 0;
            loadingText.text = $"0 %";            
        }

        public void SetProgress(float progress)
        {
            loadingBar.fillAmount = progress;
            loadingText.text = $"{progress * 100}%";
        }
    }
}
