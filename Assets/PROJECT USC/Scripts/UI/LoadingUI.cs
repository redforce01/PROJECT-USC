using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace USC
{
    public class LoadingUI : MonoBehaviour
    {
        public static LoadingUI Instance { get; private set; }

        public Image loadingBar;
        public TextMeshProUGUI loadingText;

        private void Awake()
        {
            Instance = this;
            gameObject.SetActive(false);

            loadingBar.fillAmount = 0;
            loadingText.text = $"0 %";

            // DontDestroyOnLoad : 씬이 바뀌더라도 이 GameObject가 파괴되지 않도록 특수 처리
            DontDestroyOnLoad(gameObject);
        }

        public void SetProgress(float progress)
        {
            loadingBar.fillAmount = progress;
            loadingText.text = $"{progress * 100}%";
        }
    }
}
