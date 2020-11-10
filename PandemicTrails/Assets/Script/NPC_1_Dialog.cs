using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC_1_Dialog : MonoBehaviour {

    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    public bool dialogActive;

    // Start is called before the first frame update
    void Start() {

    } // End of Start().

    // Update is called once per frame
    void Update() {

    } // End of Update().

    private void OnTriggerEnter2D(Collider2D other) {

      if(other.CompareTag("player")) {

        Debug.Log("Player in range.");

      } // End of if-statement.

    } // End of OnTriggerEnter2D().

    private void OnTriggerExit2D(Collider2D other) {

      if(other.CompareTag("player")) {

        Debug.Log("Player left range.");

      } // End of if-statement.

    } // End of OnTriggerExit2D().

} // End of NPC class.
