using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopmenu : MonoBehaviour
{
    public shop shopMenuOpen;

    void start () {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            shopMenuOpen.gameObject.SetActive(!shopMenuOpen.gameObject.activeSelf);
        }
    }
}
