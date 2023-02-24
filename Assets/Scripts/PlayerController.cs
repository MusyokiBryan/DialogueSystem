using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    public LayerMask worldObjectsLayer;

    public LayerMask interactableLayer;

    private bool isMoving;

    private Vector2 input;
    private Animator animator;

    private void Update()
    {
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            // if (input.x != 0) input.y = 0;

            if (input != Vector2.zero)
            {
                var targetPosition = transform.position;
                targetPosition.x += input.x;
                targetPosition.y += input.y;
                if (IsWalkable(targetPosition))
                    StartCoroutine(Move(targetPosition));
            }
        }
        // if (Input.GetKeyDown(KeyCode.F))
        //     Interact();
    }

    // void Interact()
    // {
    //     var faceDirection = new Vector3(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
    //     var interactPosition = transform.position + faceDirection;

    //     var collider = Physics2D.OverlapCircle(interactPosition, 0.3f, interactableLayer);
    //     if (collider != null)
    //     {
    //         collider.GetComponent<NpcController>();
    //     }
    // }



    IEnumerator Move(Vector3 targetPosition)
    {
        isMoving = true;
        while ((targetPosition - transform.position).sqrMagnitude >
            Mathf.Epsilon
        )
        {
            transform.position =
                Vector3
                    .MoveTowards(transform.position,
                    targetPosition,
                    moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPosition;
        isMoving = false;
    }

    private bool IsWalkable(Vector3 targetPostion)
    {
        if (
            Physics2D
                .OverlapCircle(targetPostion,
                0.2f,
                worldObjectsLayer | interactableLayer) !=null)
        {
            return false;
        }
        return true;
    }
}
