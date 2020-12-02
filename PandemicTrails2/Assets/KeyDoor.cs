using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
      private Item keyType;

      public Item GetKeyType(){
         return keyType;
      }

      public void OpenDoor(){
         gameObject.SetActive(false);
      }
}
