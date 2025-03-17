using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 敌人 : MonoBehaviour
{
    Rigidbody2D 刚体;

    public Transform 光位置;
    public Transform 影位置;

    public 物理检测 x物理检测;

    [Header("基本参数")]

    public float 行走速度;

    public float 追击速度;

    public float 当前速度;

    public Vector3 面朝方向;

    [Header("计时器相关")]
    public float 等待时间;
    public float 等待计时;
    public bool 等待状态;

    protected 基础状态 巡逻状态;
    protected 基础状态 当前状态;
    protected 基础状态 追击状态;

    protected virtual void Awake()
    {
        刚体=GetComponent<Rigidbody2D>();
        x物理检测=GetComponent<物理检测>();
        当前速度 = 行走速度;
        等待计时 = 等待时间;
    }

    private void OnEnable()//物体被激活时触发
    {
        当前状态 = 巡逻状态;
        当前状态.进入(this);
    }

    private void Update()
    {
        面朝方向 = new Vector3(光位置.localScale.x, 0, 0); 
        当前状态.逻辑判断();
        计时();
        

        
    }

    private void FixedUpdate()
    {
        if(!等待状态)
          移动();
        当前状态.物理判断();
    }

    private void OnDisable()//在物体被关闭时执行
    {
        当前状态.退出();
    }

    public void 移动()
    {
        刚体.velocity=new Vector2(当前速度*面朝方向.x*Time.deltaTime,刚体.velocity.y);
    }

    public void 计时()
    {
        if (等待状态)
        {
            刚体.velocity = new Vector2(0,刚体.velocity.y);
            等待计时 -= Time.deltaTime;
            if(等待计时<=0)
            {
                等待状态 = false;
                等待计时 = 等待时间;
                x物理检测.偏移量 = new Vector3(x物理检测.偏移量.x*-1,x物理检测.偏移量.y,x物理检测.偏移量.z);
                光位置.localScale = new Vector3(-面朝方向.x, 1, 1);
                影位置.localScale = new Vector3(-面朝方向.x, 1, 1);
            }
        }
    }
}
