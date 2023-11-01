using Assets.Scripts.Navigation.Scenes;
namespace GameSoft.Navigation.Scenes.Menu
{
    public class MenuNavigationArgs : NavigationArgs
    {
        private const string MenuSceneName = "Menu";

        public MenuNavigationArgs()
            : base(SceneType.Menu, MenuSceneName)
        {

        }

        public MenuNavigationArgs(SceneType sceneType, string sceneName) : base(sceneType, sceneName)
        {
        }
    }
}
