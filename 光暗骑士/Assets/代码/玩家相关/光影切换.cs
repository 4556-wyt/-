using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class 光影切换 : MonoBehaviour
{
    public LayerMask 光界面;
    public LayerMask 影界面;
    public Camera 相机;
    public bool 状态;
    public string 光玩家;
    public string 影玩家;
    public GameObject 玩家;
    public int 玩家光界面;
    public int 玩家影界面;
    void Start()
    {
        玩家光界面 = LayerMask.NameToLayer(光玩家);
        玩家影界面 = LayerMask.NameToLayer(影玩家);
        玩家.gameObject.layer = 玩家光界面;
        状态 = true;
    }

   void Update()
    {
      
    }

    public void 光影切换执行()
    {
        
            if (状态 == true)
            {
                相机.cullingMask = 影界面;
                玩家.gameObject.layer = 玩家影界面;
                状态 = false;
            }
            else if (状态 == false)
            {
                相机.cullingMask = 光界面;
                玩家.gameObject.layer = 玩家光界面;
                状态 = true;
            }

        
        
    }
    
       
}

