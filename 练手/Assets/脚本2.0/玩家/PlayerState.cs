using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState 
{
   protected PlayerStateMachine stateMachine;
   protected Player Player;
   protected Rigidbody2D rb;


    protected float xInput;
    protected float yInput;
    private string animBoolName;

    protected float stateTimer;
    protected bool triggerCalled;

    public PlayerState(Player _player,PlayerStateMachine _stateMachine,string _animBoolName)
    {
        this.Player = _player;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;  
    }

    public virtual void Enter()
    {
        Player.anim.SetBool(animBoolName, true);
        rb=Player.rb;
        triggerCalled = false;
    }
    public virtual void Update()
    {
        stateTimer-=Time.deltaTime;
        yInput = Input.GetAxisRaw("Vertical");
        xInput = Input.GetAxisRaw("Horizontal");
        Player.anim.SetFloat("yVelocity", rb.velocity.y);
    }
    public virtual void Exit()
    {
        Player.anim.SetBool(animBoolName, false);
    }
    public virtual void AnimationFinishTrigger()
    {
        triggerCalled = true;
    }

}
