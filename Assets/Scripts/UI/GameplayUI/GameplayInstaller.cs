using Player.Inventory;
using Zenject;

namespace GameplayUI
{
   public class GameplayInstaller : MonoInstaller
   {
      public override void InstallBindings()
      {
         Container.Bind<CursorView>().FromComponentInHierarchy().AsSingle();
         Container.Bind<SimpleControls>().AsSingle();
         Container.Bind<IInventory>().To<Inventory>().AsSingle();
         Container.Bind<InventoryController>().FromComponentInHierarchy().AsSingle();
         Container.Bind<HandGrabber>().FromComponentInHierarchy().AsSingle();
      }
   }
}