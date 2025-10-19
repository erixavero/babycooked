using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;
    [SerializeField] private GameObject[] noBabyObjects;
    [SerializeField] private GameObject[] withBabyObjects;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 movement;
    private Vector2 lastMove;

    public bool canMove = true;

    private void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        lastMove = new Vector2(0, -1);
    }

    private void Update()
    {
        if(PlayerInteraction.instance.isInteracting || !canMove)
        {
            rb.velocity = Vector2.zero;
            return;
        }
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
        if(PlayerInteraction.instance.isInteracting || !canMove)
        {
            rb.velocity = Vector2.zero;
            return;
        }
        rb.velocity = movement.normalized * moveSpeed;
    }

    private void Animate()
    {
    animator.SetBool("Carrying Baby", PlayerInteraction.instance.isCarryingBaby);
        animator.SetFloat("MoveX", movement.x);
        animator.SetFloat("MoveY", movement.y);
        animator.SetFloat("LastMoveX", lastMove.x);
        animator.SetFloat("LastMoveY", lastMove.y);
        animator.SetFloat("MoveMagnitude", rb.velocity.magnitude);
        foreach (var obj in noBabyObjects)
        {
            obj.SetActive(false);
        }
        foreach (var obj in withBabyObjects)
        {
            obj.SetActive(false);
        }
    if (!PlayerInteraction.instance.isCarryingBaby)
        {
            switch (lastMove.x, lastMove.y)
            {
                case (1, 0): // right
                    noBabyObjects[0].SetActive(true);
                    break;
                case (-1, 0): // left
                    noBabyObjects[1].SetActive(true);
                    break;
                case (1, 1): // up right
                case (-1, 1): // up left
                case (0, 1): // up
                    noBabyObjects[2].SetActive(true);
                    break;
                case (1, -1): // down right
                case (-1, -1): // down left
                case (0, -1): // down
                    noBabyObjects[3].SetActive(true);
                    break;
            }
        }
        else
        {
            switch (lastMove.x, lastMove.y)
            {
                case (1, 0): // right
                    withBabyObjects[0].SetActive(true);
                    break;
                case (-1, 0): // left
                    withBabyObjects[1].SetActive(true);
                    break;
                case (1, 1): // up right
                case (-1, 1): // up left
                case (0, 1): // up
                    withBabyObjects[2].SetActive(true);
                    break;
                case (1, -1): // down right
                case (-1, -1): // down left
                case (0, -1): // down
                    withBabyObjects[3].SetActive(true);
                    break;
            }
        }
    }
}
