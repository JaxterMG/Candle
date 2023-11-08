
using System.Collections.Generic;
using Extensions;
using Interactions;
using UnityEngine;

namespace Player.Inventory
{
    public class Inventory : IInventory
    {
        private List<Item> _pickedObjects = new List<Item>();
        public void TakeObject(IPickable pickableObject)
        {
            pickableObject?.OnPickUp();
            _pickedObjects.Add(pickableObject.GetSO());
            GameObject.Destroy(pickableObject.GetGO());
            
            Debug.Log($"Item {pickableObject.GetItemName()} added to Inventory");
        }

        public void RemoveObject(Item item)
        {
            _pickedObjects.Remove(item);
        }

        public void RemoveFirst(RaycastHit hit, Transform player)
        {
            if(_pickedObjects.Count > 0)
            {
                Rigidbody rb = GameObject.Instantiate(_pickedObjects[0].Prefab).GetComponent<Rigidbody>();

                rb.GetComponent<IPickable>().SetItemName(_pickedObjects[0].Name);

                if(hit.collider != null)
                {
                    rb.MovePosition(hit.point);
			
                    Quaternion rotation = Quaternion.FromToRotation(rb.transform.up, hit.normal);
                    
                    rb.MoveRotation(rotation * rb.transform.rotation);
                }
                else
                {
                    rb.MovePosition(player.transform.position + player.forward);
                }
                _pickedObjects.TryRemoveByIndex(0);
            }

            
        }

        public IPickable GetObject()
        {
            return GameObject.Instantiate(_pickedObjects[0].Prefab).GetComponent<IPickable>();
        }

    }
}
