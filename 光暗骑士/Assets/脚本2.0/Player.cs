using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Attack details")]
    public Vector2[] attackMovement;


    public bool isBusy {  get; private set; }

    [Header("Move info")]
    public float moveSpeed = 8f;
    public float jumpForce;

    [Header("Dash info")]
    [SerializeField] private float dashCooldown;
    private float dashUsageTimer;
    public float dashSpeed;
    public float dashDuration;
    public float dashDir {  get; private set; }


    [Header("Collision info")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private float wallCheckDistance;
    [SerializeField]private LayerMask whatIsGround;


    public int facingDir { get; private set; } = 1;
    private bool facingRight=true;

    #region Components
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }
    #endregion

    #region States
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerAirState airState { get; private set; }
    public PlayerDashState dashState { get; private set; }
    public PlayerWallSlideState wallSlide { get; private set; }
    public PlayerWallJumpState wallJump { get; private set; }
    public PlayerPrimaryAttackState primaryAttack {  get; private set; }

    #endregion

    public void Awake()
    {
        stateMachine = new PlayerStateMachine(); //将状态机等同于新玩家状态机
       idleState = new PlayerIdleState(this, stateMachine,"Idle");//通过我们创建的构造函数传递信息，当我们处于这个状态时可以访问一些不同的信息
       moveState = new PlayerMoveState(this, stateMachine, "Move");
       jumpState = new PlayerJumpState(this, stateMachine, "Jump");
       airState  = new PlayerAirState(this, stateMachine, "Jump");
       dashState = new PlayerDashState(this, stateMachine, "Dash");
       wallSlide=new PlayerWallSlideState(this, stateMachine, "wallSlide");
       wallJump = new PlayerWallJumpState(this, stateMachine, "Jump");
        primaryAttack = new PlayerPrimaryAttackState(this, stateMachine, "Attack");
    }
    private void Start()
    {
        rb=GetComponentInChildren<Rigidbody2D>();
        anim=GetComponentInChildren<Animator>();//组件函数必须在初始化函数Initiallize之前才能被调用
        stateMachine.Initiallize(idleState);//初始化函数调用是currentState=_statestate;当前状态是起始状态，起始状态为站立状态

    }
    private void Update()
    {
        stateMachine.currentState.Update();
        CheckForDashInput();
       
    }

    public IEnumerator BusyFor(float _seconds)
    {
        isBusy = true;

        yield return new WaitForSeconds(_seconds);

        isBusy = false;
    }
    public void AnimationTrigger() => stateMachine.currentState.AnimationFinishTrigger();

    #region Velocity
    public void ZeroVelocity() => rb.velocity = new Vector2(0, 0);
    public void SetVelocity(float _xVelocity,float _yVelocity)
    {
        FlipController(_xVelocity);
        rb.velocity=new Vector2(_xVelocity, _yVelocity);
    }
    #endregion

    #region Collision
    public bool IsGroundDelected()=>Physics2D.Raycast(groundCheck.position,Vector2.down,groundCheckDistance, whatIsGround);
    public bool IsWallDelected() => Physics2D.Raycast(wallCheck.position, Vector2.right*facingDir, wallCheckDistance, whatIsGround);
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance , wallCheck.position.y));
    }
    #endregion

    #region Flip
    private void Flip()
    {
        facingDir = facingDir * -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
    private void FlipController(float _x)
    {
        if (_x > 0 && !facingRight)
            Flip();
        else if (_x < 0 && facingRight)
            Flip();
    }
    #endregion
    private void CheckForDashInput()
    {
        if(IsWallDelected())
            return;

        dashUsageTimer-=Time.deltaTime; 

        if (Input.GetKey(KeyCode.LeftShift)&&dashUsageTimer < 0)
        {
            dashUsageTimer = dashCooldown;
            dashDir = Input.GetAxisRaw("Horizontal");
            if(dashDir == 0)
                dashDir=facingDir;
            stateMachine.ChangeState(dashState);
        }
    }
}
