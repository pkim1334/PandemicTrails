﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
      [SerializeField] private Item.ItemType keyType;

      public Item.ItemType GetKeyType(){
         return keyType;
      }
      public void OpenDoor(){
         gameObject.SetActive(false);
      }
}
