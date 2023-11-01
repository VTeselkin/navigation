using System;
using GameSoft.Windows;
using UnityEngine;
using Zenject;

namespace GameSoft.Navigation
{
    public class BackButtonManager : MonoBehaviour
    {
        [Inject] private WindowsManager _windowsManager;
        private bool _pause = false;
        public Action BackButtonAction;

        public void SetPause(bool value)
        {
            _pause = value;
        }

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        private void Update()
        {
            if (_pause)
                return;

            if (!Input.GetKeyDown(KeyCode.Escape)) return;
            if (_windowsManager != null && _windowsManager.IsOpenedAny())
            {
                var popup = _windowsManager.GetLastWindow();
                if (popup != null)
                    popup.Close(BackButtonAction);
            }
            else
            {
                BackButtonAction?.Invoke();
            }
        }
    }
}