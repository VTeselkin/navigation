using Assets.Scripts.Navigation.Scenes;

namespace GameSoft.Navigation.Scenes.Game
{
    internal class GameNavigationArgs : NavigationArgs
    {
        private const string GameSceneName = "Game";


        public GameNavigationArgs() : base(SceneType.Game, GameSceneName)
        {
        }

   
    }
}