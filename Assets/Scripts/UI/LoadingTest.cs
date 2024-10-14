using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace USC
{
    public class LoadingTest : MonoBehaviour
    {
        public LoadingUI loadingUI;

        [Range(0f, 1f)]
        public float progress = 0f;

        private void Update()
        {
            loadingUI.SetProgress(progress);
        }
    }
}
