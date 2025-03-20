using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class °×÷¼÷Ã : ÊµÌå
{
    bool isAttacking;

    [Header("Move info")]
    [SerializeField] private float moveSpeed;

    [Header("Player delection")]
    [SerializeField] private float playerCheckDistance;
    [SerializeField] private LayerMask whatIsPlayer;

    private RaycastHit2D isPlayerDelected;
    protected  override void Start()
    {
        base.Start();
    }


    protected override void Update()
    {
        base.Update();
        if (isPlayerDelected.distance > 1)
        {
            rb.velocity = new Vector2(moveSpeed * 1.5f * facingDir, rb.velocity.y);
            isAttacking = false;
        }
        else
        {
            isAttacking = true;
        }
        if (!isGrounded || isWallDetected)
            Flip();

        Movement();
    }

    private void Movement()
    {
        if(!isAttacking)
        rb.velocity = new Vector2(moveSpeed * facingDir, rb.velocity.y);
    }

    protected override void CollisionCheck()
    {
        base.CollisionCheck();
        isPlayerDelected=Physics2D.Raycast(transform.position,Vector2.right,playerCheckDistance*facingDir,whatIsPlayer);
    }
    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position,new Vector3(transform.position.x+playerCheckDistance*facingDir,transform.position.y));
    }
}
