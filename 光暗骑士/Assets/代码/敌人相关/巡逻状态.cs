using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 巡逻状态 : 基础状态
{
   
    public override void 进入(敌人 x敌人)
    {
        当前敌人 = x敌人;
        
    }

  
    public override void 逻辑判断()
    {
        if (当前敌人 != null)
        {
            if (!当前敌人.x物理检测.在地面 || 当前敌人.x物理检测.撞左墙 && 当前敌人.面朝方向.x == -1 || 当前敌人.x物理检测.撞右墙 && 当前敌人.面朝方向.x == 1)
            {
                当前敌人.等待状态 = true;

            }
        }
       
    }

    public override void 物理判断()
    {
        throw new System.NotImplementedException();
    }


    public override void 退出()
    {
        throw new System.NotImplementedException();
    }

   
}
