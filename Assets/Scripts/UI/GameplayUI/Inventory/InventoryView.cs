using System.Collections.Generic;
using UnityEngine;

namespace GameplayUI.InventoryUI
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] InventorySlot _inventorySlot;
        private List<InventorySlot> _inventorySlots = new List<InventorySlot>();
        private int _slotsCount = 5;
        void Awake()
        {
            for (var i = 0; i < _slotsCount; i++)
            {
                InventorySlot slot = Instantiate(_inventorySlot, transform);
                _inventorySlots.Add(slot);
            }
        }

        public void SetIcon(int index, Sprite sprite)
        {
            _inventorySlots[index].Icon.sprite = sprite;
        }
        public void RemoveIcon(int index)
        {
            _inventorySlots[index].Icon.sprite = null;
        }

    }
}
