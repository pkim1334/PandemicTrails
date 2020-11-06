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
		transform.position = Vector3.MoveTowards (transform.position,
												waypoints[waypointIndex].transform.position,
												moveSpeed * Time.deltaTime);

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
    //ani.SetFloat("Speed", movement.sqrMagnitude);

  } // End of UpdateAnimation().



  /*
    private Vector3 directionVector;
    private Transform myTransform;
    public float speed;
    private Rigidbody2D rb;
    private Animator anim;
    public Collider2D bounds;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        myTransform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        changeDirection();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 temp = myTransform.position + directionVector * speed * Time.deltaTime;
        if(bounds.bounds.Contains(temp))
        {
            rb.MovePosition(temp);
        }
        else
        {
            changeDirection();
        }

    }

    void changeDirection()
    {
        int direction = Random.Range(0, 4);
        switch(direction)
        {
          case 0:
              //walking to the right
              directionVector = Vector3.right;
              break;
          case 1:
              //walking up
              directionVector = Vector3.up;
              break;
          case 2:
              //walking left
              directionVector = Vector3.left;
              break;
          case 3:
              //walking down
              directionVector = Vector3.down;
              break;
          default:
              break;
        }
        UpdateAnimation();
    }

    void UpdateAnimation()
    {
        anim.SetFloat("move_x", directionVector.x);
        anim.SetFloat("move_y", directionVector.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Vector3 temp = directionVector;
        changeDirection();
        int loops = 0;
        while(temp == directionVector && loops < 100)
        {
            loops++;
            changeDirection();
        }
    }*/
}
