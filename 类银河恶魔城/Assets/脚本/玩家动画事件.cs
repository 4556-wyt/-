using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 玩家动画事件 : MonoBehaviour
{
    private 玩家 player;
    void Start()
    {
        player=GetComponentInParent<玩家>();
    }
    private void AnimationTigger()
    {
        player.AttackOver();
    }
   
    void Update()
    {
        
    }
}
