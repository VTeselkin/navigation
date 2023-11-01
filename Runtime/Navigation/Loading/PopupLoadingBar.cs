using GameSoft.Windows;
using UnityEngine;
using UnityEngine.UI;

namespace GameSoft.Navigation.Loading
{
    internal class PopupLoadingBar : BaseWindow
    {
        [SerializeField] private Text progressBar;
        private const string ProgressFormat = "{0}%";

        public void SetProgressVisible(bool value)
        {
            progressBar.gameObject.SetActive(value);
        }

        public void SetProgress(int value)
        {
            progressBar.text = string.Format(ProgressFormat, value);
        }
    }
}