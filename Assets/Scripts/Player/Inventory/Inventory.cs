
using System.Collections.Generic;
using Extensions;
using Interactions;
using UnityEngine;

namespace Player.Inventory
{
    public class Inventory : IInventory
    {
        private List<IPickable> _pickedObjects = new List<IPickable>();
        public void TakeObject(IPickable pickableObject)
        {
            pickableObject?.OnPickUp();
            _pickedObjects.Add(pickableObject);
            pickableObject.GetGO().SetActive(false);
            
            Debug.Log($"Item {pickableObject.GetItemName()} add to Inventory");
        }

        public void RemoveObject(IPickable pickable)
        {
            _pickedObjects.Remove(pickable);
        }

        public void RemoveFirst()
        {
            if(_pickedObjects.Count > 0)
            {
                _pickedObjects[0].GetGO().SetActive(true);
            }

            _pickedObjects.TryRemoveByIndex(0);
        }

        public IPickable GetObject()
        {
            return _pickedObjects[0];
        }


    }
}
