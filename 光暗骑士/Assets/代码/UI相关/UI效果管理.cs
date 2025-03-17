using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI效果管理 : MonoBehaviour
{
    public 人物属性UI控制 人物属性UI;
    [Header("事件监听")]
    public 属性事件 血条事件;

    private void OnEnable()
    {
        血条事件.当事件被调用时 += 启动血条事件;
    }

    private void OnDisable()
    {
        血条事件.当事件被调用时 -= 启动血条事件;
    }

    private void 启动血条事件(属性 x属性)
    {
        var 百分比 = x属性.当前生命 / x属性.最大生命;
        人物属性UI.血条变更(百分比);
    }
}
