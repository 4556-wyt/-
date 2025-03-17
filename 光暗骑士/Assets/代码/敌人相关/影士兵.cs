using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 影士兵 : 敌人
{
    protected override void Awake()
    {
        base.Awake();
        巡逻状态 = new 巡逻状态();
    }
}
