using Assets.Scripts.Navigation.Scenes;
using UnityEngine;
using Zenject;

namespace GameSoft.Navigation.Scenes
{
    public abstract class BaseScene : MonoBehaviour
    {
        [Inject] private NavigationService _navigationService;
        [Inject] private BackButtonManager _backButtonManager;
        public abstract SceneType SceneType { get; }

        public virtual void Start()
        {
            _navigationService.SetCurrentScene(this);
            _backButtonManager.BackButtonAction += BackButtonActions;
        }

        protected abstract void BackButtonActions();

        public virtual void OnNavigatedTo(NavigationArgs args)
        {
        }

        public abstract void OnNavigatedFrom();
    }
}