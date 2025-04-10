using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class 玩家 : 实体
{

    [Header("Move info")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;

    [Header("Dash info")]
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashDuration;//冲刺持续时间
     private float dashTime;//冲刺计时器
    [SerializeField] private float dashCooldown;//冲刺cd
    private float dashCooldownTimer;//cd计时器

    [Header("Attack info")]
    [SerializeField] private float comboTime = 0.3f;
    private float comboTimrWindow;
    private bool isAttacking;
    private int comboCounter;

    private float xInput;


    protected override void Start()
    {
        base.Start();
    }


    protected override void Update()
    {
        base.Update();

        Movement();
        CheckInput();
        AnimatorControllers();
        FlipController();
        

        dashTime -= Time.deltaTime;
        dashCooldownTimer -= Time.deltaTime;

        comboTimrWindow -=Time.deltaTime;
        
    }

    public void AttackOver()
    {
        isAttacking = false;
        comboCounter++;

        if(comboCounter > 2)
            comboCounter = 0;

      
    }

    private void DashAbility()
    {
        if(dashCooldownTimer<0 && !isAttacking)
        {
            dashCooldownTimer = dashCooldown;
            dashTime = dashDuration;
        }
        
    }

    

    private void CheckInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartAttackEvent();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
                Jump();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            DashAbility();
        }
    }

    private void StartAttackEvent()
    {
        if (!isGrounded)
            return;
        if (comboTimrWindow < 0)
            comboCounter = 0;
        isAttacking = true;
        comboTimrWindow = comboTime;
    }

    private void Movement()
    {
        if(isAttacking)
        {
            rb.velocity = new Vector2(0, 0);
        }
        else if (dashTime > 0)
        {
            rb.velocity = new Vector2(facingDir * dashSpeed, 0);
        }
        else
        {
            rb.velocity = new Vector2(xInput * moveSpeed, rb.velocity.y);
        }
    }

    private void Jump()
    {
        if (isGrounded)
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void AnimatorControllers()
    {
        bool isMoving = rb.velocity.x != 0;
        anim.SetFloat("yveiocity",rb.velocity.y);
        anim.SetBool("isMoving",isMoving);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isDashing",dashTime > 0);
        anim.SetBool("isAttacking", isAttacking);
        anim.SetInteger("comboCounter",comboCounter);

    }
    private void FlipController()
    {
        if(rb.velocity.x > 0&&!facingRight)
            Flip();
        if (rb.velocity.x < 0 && facingRight)
            Flip();
    }
    
}
