using Assets.Scripts.Navigation.Scenes;
using Zenject;

namespace GameSoft.Navigation.Scenes.Menu
{
    internal class MenuScene : BaseScene
    {
        [Inject] private BackButtonManager _backButtonManager;
        public override SceneType SceneType => SceneType.Menu;

        public override void OnNavigatedTo(NavigationArgs args)
        {
            base.OnNavigatedTo(args);
        }
        
        public override void OnNavigatedFrom()
        {
            if (_backButtonManager.BackButtonAction != null)
                _backButtonManager.BackButtonAction -= BackButtonActions;
        }

        protected override void BackButtonActions()
        {
           
        }
    }
}