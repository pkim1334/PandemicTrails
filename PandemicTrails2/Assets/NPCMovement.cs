using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{

  [SerializeField]
  Transform[] waypoints;

  [SerializeField]
  float moveSpeed = 2f;

  public Animator ani;
  private Vector3 movement;

  int waypointIndex = 0;

  void Start() {
	
	transform.position = waypoints [waypointIndex].transform.position;
  
  } // End of Start().

  void Update() {

	Move();

  } // End of Update().

  void Move() {

	transform.position = Vector3.MoveTowards (transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);

	if (transform.position == waypoints [waypointIndex].transform.position) {
			
		waypointIndex += 1;
			
      		updateAnimation();
			
	}

	if (waypointIndex == waypoints.Length)
		
		waypointIndex = 0;
      
      		updateAnimation();

  } // End of Move().

  void updateAnimation() {

    ani.SetFloat("move_x", movement.x);
    
    ani.SetFloat("move_y", movement.y);

  } // End of UpdateAnimation().

} // End of Movement Class.
