using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationTriggers : MonoBehaviour
{
   private Player player => GetComponentInParent<Player>();

    private void AnimationTrigger()
    {
        player.AnimationTrigger();
    }
    private void AttackTrigger()
    {
        Collider2D[] colliders=Physics2D.OverlapCircleAll(player.attackCheck.position,player.attackCheckRadius);//使用了Unity中的Physics2D.OverlapCircleAll方法，它的作用是检测以指定点为中心、指定半径范围内的所有2D碰撞体（Collider2D）
        foreach(var hit in colliders)
        {
            if (hit.GetComponent<Enemy>() != null)
                hit.GetComponent<Enemy>().Damage();
        }
    }
}
