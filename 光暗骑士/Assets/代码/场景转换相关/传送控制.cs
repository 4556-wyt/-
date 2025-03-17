using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 传送控制 : MonoBehaviour,可互动接口
{
    public Vector3 传送目的坐标;
    public void 接触后启用()
    {
        Debug.Log("传送启动");
    }

   
}
