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
        Collider2D[] colliders=Physics2D.OverlapCircleAll(player.attackCheck.position,player.attackCheckRadius);//ʹ����Unity�е�Physics2D.OverlapCircleAll���������������Ǽ����ָ����Ϊ���ġ�ָ���뾶��Χ�ڵ�����2D��ײ�壨Collider2D��
        foreach(var hit in colliders)
        {
            if (hit.GetComponent<Enemy>() != null)
                hit.GetComponent<Enemy>().Damage();
        }
    }
}
