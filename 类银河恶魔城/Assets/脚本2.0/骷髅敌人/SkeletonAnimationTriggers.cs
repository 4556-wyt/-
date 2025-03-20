using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAnimationTriggers : MonoBehaviour
{
    private Enemy_Skeleton enemy => GetComponentInParent<Enemy_Skeleton>();

    private void AnimationFinshTrigger()
    {
        enemy.AnimationFinshTrigger();
    }
    public void AttackTrigger()
    {
        Collider2D[] colliders=Physics2D.OverlapCircleAll(enemy.attackCheck.position,enemy.attackCheckRadius);
        foreach(var hit in colliders)
        {
            if (hit.GetComponent<Player>() != null)
                hit.GetComponent<Player>().Damage();
        }
    }
}
