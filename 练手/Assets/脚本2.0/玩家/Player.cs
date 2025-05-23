using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    [Header("Attack details")]
    public Vector2[] attackMovement;
    public float counterAttackDuration=.2f;


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
    public PlayerCounterAttackState counterAttack { get; private set; }

    #endregion

   protected override void Awake()
    {
        base.Awake();
        stateMachine = new PlayerStateMachine(); //将状态机等同于新玩家状态机
       idleState = new PlayerIdleState(this, stateMachine,"Idle");//通过我们创建的构造函数传递信息，当我们处于这个状态时可以访问一些不同的信息
       moveState = new PlayerMoveState(this, stateMachine, "Move");
       jumpState = new PlayerJumpState(this, stateMachine, "Jump");
       airState  = new PlayerAirState(this, stateMachine, "Jump");
       dashState = new PlayerDashState(this, stateMachine, "Dash");
       wallSlide=new PlayerWallSlideState(this, stateMachine, "wallSlide");
       wallJump = new PlayerWallJumpState(this, stateMachine, "Jump");
        primaryAttack = new PlayerPrimaryAttackState(this, stateMachine, "Attack");
        counterAttack = new PlayerCounterAttackState(this, stateMachine, "CounterAttack");
    }
    protected override void Start()
    {
       base.Start();
        stateMachine.Initiallize(idleState);//初始化函数调用是currentState=_statestate;当前状态是起始状态，起始状态为站立状态

    }
    protected override void Update()
    {
        base.Update();
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
