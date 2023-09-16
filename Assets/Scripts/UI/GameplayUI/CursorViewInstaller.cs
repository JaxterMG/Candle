using Zenject;

public class CursorViewInstaller : MonoInstaller
{
   public override void InstallBindings()
   {
        //Container.Bind<CursorView>().AsSingle();
        Container.Bind<CursorView>().FromComponentInHierarchy().AsSingle();
   }
}