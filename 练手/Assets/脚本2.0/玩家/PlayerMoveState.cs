using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();


        Player.SetVelocity(xInput*Player.moveSpeed,rb.velocity.y);

        if (xInput == 0|| Player.IsWallDelected())
            stateMachine.ChangeState(Player.idleState);
    }
}
