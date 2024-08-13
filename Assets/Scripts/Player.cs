using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private ScenesLoader scenesLoader;


    [SerializeField] private float speed = 5f;

    private Animator playerAnimator;
    private Rigidbody2D playerRB;
    private SpriteRenderer spriteRenderer;
    private Vector2 moveInput;
    private bool canMove = true;
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");

            moveInput = new Vector2(moveX, moveY).normalized; // Input del jugador normalizado

            playerAnimator.SetFloat("Horizontal", moveX);
            playerAnimator.SetFloat("Vertical", moveY);
            playerAnimator.SetFloat("Speed", moveInput.sqrMagnitude);
        }
    }

    private void FixedUpdate() // Movimiento por RigidBody
    {
        if (canMove)
            playerRB.MovePosition(playerRB.position + moveInput * speed * Time.fixedDeltaTime);
    }

    public void PlayerCanMove(bool canMove) // Detener al jugador 
    {
        this.canMove = canMove;
    }
}
