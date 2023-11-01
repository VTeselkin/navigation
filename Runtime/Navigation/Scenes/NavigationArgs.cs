namespace Assets.Scripts.Navigation.Scenes
{
    public abstract class NavigationArgs
    {
        /// <summary>
        /// Stores the scene type.
        /// </summary>
        public readonly SceneType SceneType;

        /// <summary>
        /// Stores the scene name.
        /// </summary>
        public readonly string SceneName;

        public readonly bool AsyncLoad;

        protected NavigationArgs(SceneType sceneType, string sceneName, bool asyncLoad)
        {
            SceneType = sceneType;
            SceneName = sceneName;
            AsyncLoad = asyncLoad;
        }

        protected NavigationArgs(SceneType sceneType, string sceneName)
        {
            SceneType = sceneType;
            SceneName = sceneName;
            AsyncLoad = false;
        }
    }
}