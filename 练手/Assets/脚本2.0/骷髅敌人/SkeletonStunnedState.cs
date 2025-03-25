using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonStunnedState : EnemyState
{
    private Enemy_Skeleton enemy;
    public SkeletonStunnedState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Skeleton enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();

        enemy.fX.InvokeRepeating("RedColorBlink", 0, .1f);//在enemy对象的fX组件上，立即开始并以每0.1秒的频率重复调用RedColorBlink方法，直到这个调用被取消。这通常用于实现敌人对象的某种周期性视觉效果，如红色闪烁。

        stateTimer = enemy.stunDuration;

        rb.velocity=new Vector2(-enemy.facingDir * enemy.stunDirection.x, enemy.stunDirection.y);
    }

    public override void Exit()
    {
        base.Exit();
        enemy.fX.Invoke("CancelRedBlink",0);enemy.fX.Invoke("CancelRedBlink",0);
    }

    public override void Update()
    {
        base.Update();

        if(stateTimer<0)
            stateMachine.ChangeState(enemy.idleState);
    }
}
