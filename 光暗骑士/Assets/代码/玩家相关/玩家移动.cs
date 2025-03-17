using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class 玩家移动 : MonoBehaviour
{
    public 玩家输入控制 输入控制;
    public Vector2 输入方向;
    public float 速度;
    public float 跳跃力;
    private 物理检测 x物理检测;

    public Transform 光位置;

    public Transform 影位置;
    
    public Rigidbody2D 刚体;

    private void Awake()
    {
        x物理检测 = GetComponent<物理检测>();
        输入控制=new 玩家输入控制();
    }

    private void OnEnable()
    {
        输入控制.Enable();
    }

    private void OnDisable()
    {
        输入控制.Disable();
    }

    private void Update()
    {
        输入方向=输入控制.玩家控制.移动.ReadValue<Vector2>();
       
    }

    private void FixedUpdate()//固定更新的值，在不同帧率设备上更新一致
    {
        移动();
    }

    public void 移动()
    {
        刚体.velocity = new Vector2(输入方向.x * 速度 * Time.deltaTime, 刚体.velocity.y);

        #region 翻转相关

        int 光面朝方向 = (int)光位置.localScale.x;

        if (输入方向.x > 0)
            光面朝方向 = 1;
        else if (输入方向.x < 0)
            光面朝方向 = -1;

        光位置.localScale = new Vector3(光面朝方向, 1, 1);

        int 影面朝方向 = (int)影位置.localScale.x;

        if (输入方向.x > 0)
            影面朝方向 = 1;
        else if (输入方向.x < 0)
            影面朝方向 = -1;

        影位置.localScale = new Vector3(影面朝方向, 1, 1);
        #endregion

    }

    public void 跳跃()
    {
        if (x物理检测.在地面)
        {
            刚体.AddForce(transform.up * 跳跃力, ForceMode2D.Impulse);
        }
         
    }

}
