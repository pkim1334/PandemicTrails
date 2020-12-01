using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC_1_Dialog : MonoBehaviour {

    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    public bool playerInRange;

    void Start() {

    } // End of Start().

    // Update is called once per frame
    void Update() {

    if(Input.GetKeyDown(KeyCode.Space) && playerInRange) {

        if(dialogBox.activeInHierarchy) {

            dialogBox.SetActive(false);

        } // End of inner if-statement.

        else {

          dialogBox.SetActive(true);

          dialogText.text = dialog;

        } // End of else-statement.

      } // End of outer if-statement.

    } // End of Update().

    private void OnTriggerEnter2D(Collider2D other) {

      if(other.CompareTag("Player")) {

        playerInRange = true;

      } // End of if-statement.

    } // End of OnTriggerEnter2D().

    private void OnTriggerExit2D(Collider2D other) {

      if(other.CompareTag("Player")) {

        playerInRange = false;

        dialogBox.SetActive(false);

      } // End of if-statement.

    } // End of OnTriggerExit2D().

} // End of NPC class.
