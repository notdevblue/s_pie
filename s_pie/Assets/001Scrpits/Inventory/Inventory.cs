using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    [SerializeField]
    private GameObject go_InventoryBase; // Inventory_Base 이미지
    [SerializeField]
    private GameObject go_SlotsParent;  // Slot들의 부모인 Grid Setting 
    [SerializeField]
    private Slot[] slots;  // 슬롯들 배열

    void Start()
    {
        slots = go_SlotsParent.GetComponentsInChildren<Slot>();
    }

    public bool UseItem(string _item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item != null) // slots[i].item == null일경우 에러 발생.
            {
                if (slots[i].item.itemName == _item)
                {
                    slots[i].ClearSlot();
                    return true;
                }
            }
        }
        return false;
    }

    public void AcquireItem(Item _item, int _count = 1)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == null)
            {
                slots[i].AddItem(_item, _count);
                return;
            }
        }
    }
}
