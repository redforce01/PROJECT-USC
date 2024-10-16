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

            // DontDestroyOnLoad : ���� �ٲ���� �� GameObject�� �ı����� �ʵ��� Ư�� ó��
            DontDestroyOnLoad(gameObject);
        }

        public void SetProgress(float progress)
        {
            loadingBar.fillAmount = progress;
            loadingText.text = $"{progress * 100}%";
        }
    }
}
