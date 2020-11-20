using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Sprite icon = null;
    [SerializeField] private ItemType itemType;
    public enum ItemType{
      key,
      money
    }
    public ItemType GetItemType(){
        return itemType;
    }
}
