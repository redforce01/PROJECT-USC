using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


#if UNITY_EDITOR
using UnityEditor;
#endif

namespace USC
{
    public class TitleUI : MonoBehaviour
    {
        // Game Start Event
        public void OnClickGameStartButton()
        {
            //SceneManager.LoadScene("Game Scene");
            StartCoroutine(AsyncGameSceneLoad());
        }

        private IEnumerator AsyncGameSceneLoad()
        {
            LoadingUI.Instance.gameObject.SetActive(true);
            AsyncOperation operation = SceneManager.LoadSceneAsync("Game Scene", LoadSceneMode.Additive);
            while (!operation.isDone)
            {
                LoadingUI.Instance.SetProgress(operation.progress / 0.9f);
                yield return null;
            }
            SceneManager.UnloadSceneAsync("Title Scene");
            LoadingUI.Instance.gameObject.SetActive(false);

            //AsyncOperation operation = SceneManager.LoadSceneAsync("Game Scene", LoadSceneMode.Additive);
            //LoadingUI.Instance.gameObject.SetActive(true);
            //LoadingUI.Instance.SetProgress(0.3f);
            //yield return new WaitForSeconds(0.1f);
            //LoadingUI.Instance.SetProgress(0.45f);
            //yield return new WaitForSeconds(0.3f);
            //LoadingUI.Instance.SetProgress(0.8f);
            //yield return new WaitForSeconds(2f);
            //LoadingUI.Instance.SetProgress(1f);
            //yield return new WaitForSeconds(0.1f);

            //yield return new WaitUntil(() => { return operation.isDone; });
            //SceneManager.UnloadSceneAsync("Title Scene");
            //LoadingUI.Instance.gameObject.SetActive(false);
        }

        // Game Exit Event
        public void OnClickExitButton()
        {            
#if UNITY_EDITOR
            EditorApplication.isPlaying = false; // 에디터의 재생을 멈추는 코드
#else
            Application.Quit(); // 이렇게 함수 하나만 호출하면, 프로그램이 종료 된다.
#endif
        }
    }
}
