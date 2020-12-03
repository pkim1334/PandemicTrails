﻿using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;

    Inventory inventory;

    InventorySlot[] slots;
    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallBack += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void UpdateUI()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.itemsList.Count)
            {
              slots[i].AddItem(inventory.itemsList[i]);
            } else
            {
              slots[i].ClearSlot();
            }
        }
    }
}