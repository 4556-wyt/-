using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class 属性 : MonoBehaviour
{
    [Header("基本属性")]
    public float 最大生命;

    public float 当前生命;

    [Header("受伤无敌")]
    public float 无敌时间;
    private float 计时;
    public bool 无敌状态;

    public UnityEvent<Transform> 受到伤害;

    public UnityEvent<属性> 血量变化;

    private void Start()
    {
        当前生命 = 最大生命;
        血量变化?.Invoke(this);
    }

    private void Update()
    {
        if(无敌状态)
        {
            计时-=Time.deltaTime;
            if (计时 <= 0)
            {
                无敌状态 = false;
            }
        }
    }

    public void 接受伤害(攻击 攻击者)
    {
        if (无敌状态)
            return;

        if(当前生命-攻击者.伤害>0)
        {
            当前生命 = 当前生命 - 攻击者.伤害;
            触发无敌();

            受到伤害?.Invoke(攻击者.transform);
        }
        else
        {
            当前生命 = 0;
            //触发死亡逻辑;
        }

        血量变化?.Invoke(this);
    }

    private void 触发无敌()
    {
        if(!无敌状态)
        {
            无敌状态 = true;

            计时 = 无敌时间;
        }
    }
}
