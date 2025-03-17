using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 攻击 : MonoBehaviour
{
    public int 伤害;

    public float 攻击距离;

    public float 攻击频率;

    private void OnTriggerStay2D(Collider2D other)
    {
        other.GetComponent<属性>()?.接受伤害(this);
    }
}
