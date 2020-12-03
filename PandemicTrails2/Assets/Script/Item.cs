using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Sprite icon = null;
    
    public string itemType;

    public string GetItemType(){
        return itemType;
    }

    public virtual void Use()
    {


        Debug.Log("Using " + itemType);
    }
}
