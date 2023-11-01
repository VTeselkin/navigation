using System;
using System.Collections;
using Assets.Scripts.Navigation.Scenes;
using GameSoft.Navigation.Loading;
using GameSoft.Navigation.Scenes;
using GameSoft.Tools;
using GameSoft.Windows;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace GameSoft.Navigation
{
    public class NavigationService : MonoBehaviour, IInitializable
    {
        [Inject] private WindowsManager _windowsManager;
        private PopupLoadingBar _popupLoading;
        private BaseScene _currentScene;
        private NavigationArgs _navigationArgs;
        private int _sameProgressCounter;
        private float _previousProgress;
        private readonly int _maxProgress = 100;
        private readonly int _maxSameProgressCounter = 5;
        private const double TOLERANCE = 0.01f;

        public void Initialize()
        {
            DDebug.Log("NavigationService is initialize");
        }

        public SceneType CurrentSceneType => _currentScene != null ? _currentScene.SceneType : SceneType.Undefined;


        public void Navigate(NavigationArgs navigator)
        {
            if(_currentScene != null)
            {
                _currentScene.OnNavigatedFrom();
            }
            _navigationArgs = navigator;

            if (navigator.AsyncLoad)
            {
                LoadLevelAsynchronously(navigator.SceneName);
            }
            else
            {
                SceneManager.LoadScene(navigator.SceneName);
            }
        }

        public void LoadLevelAsynchronously(string sceneName)
        {
            _popupLoading = _windowsManager.OpenWindow<PopupLoadingBar>();
            if (!_popupLoading) return;
            _popupLoading.SetProgressVisible(true);
            _popupLoading.StartCoroutine(LoadLevelAsync(sceneName));
        }

        private IEnumerator LoadLevelAsync(string sceneName)
        {
            _previousProgress = 0;
            _sameProgressCounter = 0;

            var async = SceneManager.LoadSceneAsync(sceneName);
            async.allowSceneActivation = false;

            while (!async.isDone)
            {
                if (_popupLoading != null)
                {
                    int currentProgress = Mathf.FloorToInt(async.progress * 100.0f);
                    _popupLoading.SetProgress(currentProgress);

                    if (Math.Abs(_previousProgress - async.progress) < TOLERANCE)
                    {
                        _sameProgressCounter++;
                    }
                    else
                    {
                        _previousProgress = async.progress;
                        _sameProgressCounter = 0;
                    }

                    if (_sameProgressCounter > _maxSameProgressCounter)
                        break;
                }

                yield return null;
            }

            _popupLoading.SetProgress(_maxProgress);
            yield return new WaitForSeconds(0.2f);
            async.allowSceneActivation = true;
            yield return async;
        }


        public void SetCurrentScene(BaseScene scene)
        {
            _windowsManager.CloseAllFast();
            _currentScene = scene;
            _currentScene.OnNavigatedTo(_navigationArgs);
        }
        private void OnDestroy()
        {
            DDebug.Log("NavigationService is destroy");
        }
    }
}