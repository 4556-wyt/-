using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class 场景互动 : MonoBehaviour
{
    private 玩家输入控制 玩家输入;
    private Animator 动画;
    public GameObject 提示按钮;
    public bool 可以按吗;
    private 可互动接口 接触物体;

    private void Awake()
    {
        
        动画= 提示按钮.GetComponent<Animator>();
        玩家输入=new 玩家输入控制();
        玩家输入.Enable();
    }

    private void OnEnable()
    {
        InputSystem.onActionChange += 控制器变化;
        玩家输入.玩家控制.互动.started += 启动互动;
    }

    private void 启动互动(InputAction.CallbackContext obj)
    {
        if (可以按吗)
        {
            接触物体.接触后启用();
        }
    }

    private void 控制器变化(object obj, InputActionChange 输入变化)
    {
        if(输入变化==InputActionChange.ActionStarted)
        {
            var d = ((InputAction)obj).activeControl.device;//获得当前输入设备 固定写法

            switch(d.device)
            {
                case Keyboard:
                    动画.Play("键盘动画");
                    break;
                case Gamepad:
                    动画.Play("手柄动画");
                    break;
            }
        }
    }

    private void Update()
    {
        提示按钮.GetComponent<SpriteRenderer>().enabled = 可以按吗;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("可互动"))
        {
            可以按吗 = true;
            接触物体 = other.GetComponent<可互动接口>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        可以按吗 = false;
    }
}
