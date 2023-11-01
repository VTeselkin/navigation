using Assets.Scripts.Navigation.Scenes;
using GameSoft.Navigation.Scenes.Menu;
using Zenject;

namespace GameSoft.Navigation.Scenes.Game
{
    internal class GameScene : BaseScene
    {
        [Inject] private NavigationService _navigationService;
        [Inject] private BackButtonManager _backButtonManager;
        public override SceneType SceneType => SceneType.Game;

        public override void OnNavigatedTo(NavigationArgs args)
        {
            base.OnNavigatedTo(args);
        }

        public override void OnNavigatedFrom()
        {
            if (_backButtonManager.BackButtonAction != null)
                // ReSharper disable once DelegateSubtraction
                _backButtonManager.BackButtonAction -= BackButtonActions;
        }


        protected override void BackButtonActions()
        {
            _navigationService.Navigate(new MenuNavigationArgs());
        }
    }
}