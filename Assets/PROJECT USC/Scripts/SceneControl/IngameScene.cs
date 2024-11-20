using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace USC
{
    public class IngameScene : SceneBase
    {
        public override bool IsAdditiveScene => false;

        public override IEnumerator OnStart()
        {
            AsyncOperation async = SceneManager.LoadSceneAsync(SceneType.Ingame.ToString(), LoadSceneMode);
            while (!async.isDone)
            {
                yield return null;

                float progress = async.progress / 0.9f;
                LoadingUI.Instance.SetProgress(progress);
            }

            // TODO : Show Ingame UI
            UIManager.Show<IngameUI>(UIList.IngameUI);
            UIManager.Show<InteractionUI>(UIList.InteractionUI);
            UIManager.Show<MinimapUI>(UIList.MinimapUI);
            UIManager.Show<CrosshairUI>(UIList.CrosshairUI);
        }

        public override IEnumerator OnEnd()
        {
            // TODO : Hide Ingame UI
            UIManager.Hide<IngameUI>(UIList.IngameUI);
            UIManager.Hide<InteractionUI>(UIList.InteractionUI);
            UIManager.Hide<MinimapUI>(UIList.MinimapUI);
            UIManager.Hide<CrosshairUI>(UIList.CrosshairUI);

            yield return null;
        }
    }
}
