using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace USC
{
    public class LoadingUI : MonoBehaviour
    {
        public Image loadingBar;
        public TextMeshProUGUI loadingText;

        public void SetProgress(float progress)
        {
            loadingBar.fillAmount = progress;
            loadingText.text = $"{progress * 100}%";
        }
    }
}
