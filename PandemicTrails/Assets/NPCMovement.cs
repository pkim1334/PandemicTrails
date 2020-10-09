using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
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
    }
}
