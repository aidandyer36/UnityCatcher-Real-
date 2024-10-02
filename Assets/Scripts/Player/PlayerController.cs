using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float moveSpeed; //Changes speed of player movement

    private bool isMoving; //Checks if player is moving
    private Vector2 input; 

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>(); //get animated component attached to same object as script (Cache the animator)
    }
    private void Update()
    {
        //checks that the last coroutine is over before starting another
        if(!isMoving)
        {
            //get player inputs
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            //removes diagonal movement
            if(input.x != 0) 
                input.y = 0; 

            if(input != Vector2.zero)
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);
                //finds where the target position the player has to get to is
                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                //starts the coroutine for movement to resolve at the same time as other processes
                StartCoroutine(Move(targetPos));
            }
        }
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;
    
        while((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
    }
}
