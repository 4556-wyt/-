using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCounterAttackState : PlayerState
{
    public PlayerCounterAttackState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer=Player.counterAttackDuration;
        Player.anim.SetBool("SuccessfulCounterAttack",false);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        Player.SetZeroVelocity();

        Collider2D[] colliders = Physics2D.OverlapCircleAll(Player.attackCheck.position, Player.attackCheckRadius);
        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Enemy>() != null)
            {
                if (hit.GetComponent<Enemy>().CanBeStunned())
                {
                    stateTimer = 10;//大于1的值就行
                    Player.anim.SetBool("SuccessfulCounterAttack",true);
                }
            }
        }
        if(stateTimer < 0||triggerCalled) //反击结束后进入待机状态
            stateMachine.ChangeState(Player.idleState);
    }
}
