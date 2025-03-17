using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 人物属性UI控制 : MonoBehaviour
{
    public Image 血条;

    public Image 血条背景;

    public Image 精力条;

    public float 跟随速度;

    private void Update()
    {
        if (血条背景.fillAmount > 血条.fillAmount)
        {
            血条背景.fillAmount-=Time.deltaTime*跟随速度;
        }
    }

    public void 血条变更(float 百分比)
    {
        血条.fillAmount = 百分比;
    }
}
