using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public int space = 20;

    public static Inventory instance;

    public List<Item.ItemType> itemsList;


    void Awake()
    {
        if(instance != null){
            Debug.LogWarning("More than one instance of Inventory found");
            return;
        }

        itemsList = new List<Item.ItemType>();
        instance = this;
    }

    public delegate void OnItemChanged();

    public OnItemChanged onItemChangedCallBack;


    public bool Add(Item.ItemType item)
    {
        if(itemsList.Count >= space)
            {
                Debug.Log("Not enough room");
                return false;
            }
        itemsList.Add(item);
        Debug.Log("Picked up: " + item);

        if (onItemChangedCallBack != null){
          onItemChangedCallBack.Invoke();
        }


        return true;

    }

    public void Remove(Item.ItemType item)
    {
        itemsList.Remove(item);

        if (onItemChangedCallBack != null){
          onItemChangedCallBack.Invoke();
        }
    }

    public bool ContainsKey(Item.ItemType test){
       return itemsList.Contains(test);
     }

    private void OnTriggerEnter2D(Collider2D collision){
       Item item = collision.GetComponent<Item>(); //Error on this row
       if (item != null){
          Add(item.GetItemType());
          Destroy(item.gameObject);
       }
       KeyDoor keyDoor = collision.GetComponent<KeyDoor>();
       if(keyDoor!=null){
          if(ContainsKey(keyDoor.GetKeyType())){
             keyDoor.OpenDoor();
          }
       }
    }
}
