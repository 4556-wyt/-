using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonBattleState : EnemyState
{
    private Transform player;
    private Enemy_Skeleton enemy;
    private int moveDir;
    public SkeletonBattleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Skeleton enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        player = GameObject.Find("Player").transform;
    }
    public override void Update()
    {
        base.Update();

        if(enemy.IsPlayerDelected())
        {
            stateTimer=enemy.battleTime;
            if(enemy.IsPlayerDelected().distance<enemy.attackDistance)
            {
                if(CanAttack())
               stateMachine.ChangeState(enemy.attackState);
            }
        }
        else
        {
            if(stateTimer<0||Vector2.Distance(player.transform.position,enemy.transform.position)>10)
                stateMachine.ChangeState(enemy.idleState);
        }


        if (player.position.x > enemy.transform.position.x)
            moveDir = 1;
        else if (player.position.x < enemy.transform.position.x)
            moveDir = -1;

        enemy.SetVelocity(enemy.moveSpeed* moveDir,rb.velocity.y);
    }

    public override void Exit()
    {
        base.Exit();
    }

    private bool CanAttack()
    {
        if(Time.time>=enemy.lastTimeAttacked+enemy.attackCooldown)
        {
            enemy.lastTimeAttacked= Time.time;
            return true;
        }
        return false;
    }

}
