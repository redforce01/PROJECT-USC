namespace USC
{
    public class TitleUI : UIBase
    {
        // Game Start Event
        public void OnClickGameStartButton()
        {
            Main.Singleton.ChangeScene(SceneType.Ingame);
        }

        // Game Exit Event
        public void OnClickExitButton()
        {
            Main.Singleton.SystemQuit();
        }
    }
}
