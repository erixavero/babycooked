using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject[] playerDirectionObject;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 movement;
    private Vector2 lastMove;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        lastMove = new Vector2(0, -1);
    }

    private void Update()
    {
        if(PlayerInteraction.instance.isInteracting) return;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (movement != Vector2.zero)
        {
            lastMove = movement;
        }
        Animate();
    }

    private void FixedUpdate()
    {
        if (PlayerInteraction.instance.isInteracting) return;
        rb.velocity = movement.normalized * moveSpeed;
    }

    private void Animate()
    {
        animator.SetFloat("MoveX", movement.x);
        animator.SetFloat("MoveY", movement.y);
        animator.SetFloat("LastMoveX", lastMove.x);
        animator.SetFloat("LastMoveY", lastMove.y);
        animator.SetFloat("MoveMagnitude", rb.velocity.magnitude);
        
        foreach (var obj in playerDirectionObject)
        {
            obj.SetActive(false);
        }
        switch (lastMove.x, lastMove.y)
        {
            case (1, 0):
                playerDirectionObject[0].SetActive(true);
                break;
            case (-1, 0):
                playerDirectionObject[1].SetActive(true);
                break;
            case (1, 1):
            case (-1, 1):
            case (0, 1):
                playerDirectionObject[2].SetActive(true);
                break;
            case (1, -1):
            case (-1, -1):
            case (0, -1):
                playerDirectionObject[3].SetActive(true);
                break;
        }
    }
}
