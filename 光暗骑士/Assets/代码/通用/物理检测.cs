using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 物理检测 : MonoBehaviour
{
    [Header("检测参数")]
   
    public float 检测范围;
    public Vector3 偏移量;
    public LayerMask 地面类;

    public float 撞墙检测范围;
    public Vector3 偏移量左墙;
    public Vector3 偏移量右墙;
    public LayerMask 墙壁类;

    [Header("状态")]
    public bool 在地面;

    public bool 撞左墙;

    public bool 撞右墙;

    private void Update()
    {
        检查();
    }
    public void 检查()
    {
        在地面=Physics2D.OverlapCircle(transform.position +偏移量, 检测范围, 地面类);

        撞左墙= Physics2D.OverlapCircle(transform.position + 偏移量左墙, 撞墙检测范围, 墙壁类);

        撞右墙 = Physics2D.OverlapCircle(transform.position + 偏移量右墙, 撞墙检测范围, 墙壁类);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position + 偏移量, 检测范围);

        Gizmos.DrawWireSphere(transform.position + 偏移量左墙, 撞墙检测范围);

        Gizmos.DrawWireSphere(transform.position + 偏移量右墙, 撞墙检测范围);
    }

}
