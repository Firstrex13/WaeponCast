
using Zenject;

public class BootstrapInstaller : MonoInstaller
{

    public override void InstallBindings()
    {

         Container.Bind<IProgressService>().To<ProgressService>().FromNew().AsSingle().NonLazy();
    }

}
