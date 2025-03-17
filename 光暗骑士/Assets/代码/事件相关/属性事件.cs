using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName ="事件/属性传递事件")]
public class 属性事件 : ScriptableObject
{
    public UnityAction<属性> 当事件被调用时;

    public void 启动事件(属性 x属性)
    {
        当事件被调用时?.Invoke(x属性);
    }
}
