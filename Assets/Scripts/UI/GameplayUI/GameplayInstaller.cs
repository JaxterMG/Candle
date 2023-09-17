using Player.Inventory;
using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
   public override void InstallBindings()
   {
        Container.Bind<CursorView>().FromComponentInHierarchy().AsSingle();
        Container.Bind<SimpleControls>().AsSingle();
        Container.Bind<IInventory>().To<HandInventory>().AsSingle();
        Container.Bind<InventoryController>().FromComponentInHierarchy().AsSingle();
   }
}