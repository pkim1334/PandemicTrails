using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public int space = 20;

    public static Inventory instance;

    public List<Item> itemsList;


    void Awake()
    {
        if(instance != null){
            Debug.LogWarning("More than one instance of Inventory found");
            return;
        }

        itemsList = new List<Item>();
        instance = this;
    }

    public delegate void OnItemChanged();

    public OnItemChanged onItemChangedCallBack;


    public bool Add(Item item)
    {
        if(itemsList.Count >= space)
            {
                Debug.Log("Not enough room");
                return false;
            }
        itemsList.Add(item);
        Debug.Log("Picked up: " + item.GetItemType());

        if (onItemChangedCallBack != null){
          onItemChangedCallBack.Invoke();
        }


        return true;

    }

    public void Remove(Item item)
    {
        itemsList.Remove(item);

        if (onItemChangedCallBack != null){
          onItemChangedCallBack.Invoke();
        }
    }

    public bool ContainsKey(Item test){
        if (test.GetItemType().Equals("key")){
          return true;
        }else {
          return false;
        }
       //return itemsList.Contains(test);
     }

    private void OnTriggerEnter2D(Collider2D collision){
       Item item = collision.GetComponent<Item>(); //Error on this row
       if (item != null){
          Add(item);
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
