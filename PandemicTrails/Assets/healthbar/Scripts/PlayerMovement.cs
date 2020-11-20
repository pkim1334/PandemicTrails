 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    public Animator animator;

    Camera cam;

    Vector2 movement;
    void Update()
    {
      //input

      if (Input.GetMouseButton(1))
      {
          Ray ray = cam.ScreenPointToRay(Input.mousePosition);
          RaycastHit hit;

          if(Physics.Raycast(ray, out hit))
          {
              Debug.Log("We hit " + hit.collider.name + " " + hit.point);
              // move our player to what we hit

              //stop focusing any object;
          }
      }

      movement.x = Input.GetAxisRaw("Horizontal");
      movement.y = Input.GetAxisRaw("Vertical");

      animator.SetFloat("Horizontal", movement.x);
      animator.SetFloat("Vertical", movement.y);
      animator.SetFloat("Speed", movement.sqrMagnitude);

      if(Input.GetKeyDown(KeyCode.Space))
      {

      }
    }

    void FixedUpdate()
    {
      //movement

      rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }



}
