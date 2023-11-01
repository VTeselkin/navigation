using GameSoft.Navigation;
using Zenject;

namespace GameSoft
{
    public class NavigationInstaller : MonoInstaller<NavigationInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<NavigationService>().FromNewComponentOnNewGameObject()
                .AsSingle();
            Container.BindInterfacesAndSelfTo<BackButtonManager>().FromNewComponentOnNewGameObject()
                .AsSingle();
        }

    }
}
