using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 宝箱 : MonoBehaviour,可互动接口
{
    private SpriteRenderer 图片组件;
    public Sprite 打开图;
    public Sprite 关闭图;
    public bool 互动过;

    private void Awake()
    {
        图片组件 = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        图片组件.sprite = 互动过 ? 打开图 : 关闭图;
    }

    public void 接触后启用()
    {
        Debug.Log("打开宝箱");
        if (!互动过)
        {
            打开宝箱();
        }
    }

    private void 打开宝箱()
    {
        图片组件.sprite = 打开图;
        互动过 = true;
        this.gameObject.tag = "Untagged";
    }
    
}
