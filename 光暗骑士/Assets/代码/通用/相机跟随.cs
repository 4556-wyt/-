using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 相机跟随 : MonoBehaviour
{
    // 玩家角色（需要跟随的目标）
    public Transform 跟随目标;

    
    [Header("跟随速度")]
    public float 跟随速度 = 5.0f;

    // 相机与目标的垂直偏移量（用于调整相机高度）
    [Header("垂直偏量")]
    public float 垂直偏量 = 5.0f;

    // 相机与目标的水平限制（可选，用于防止相机超出屏幕边界）
    [Header("边框限制")]
    public float minX = -10.0f;
    public float maxX = 10.0f;

    void Update()
    {
        // 获取目标的位置
        Vector3 目标位置 = 跟随目标.position;

        // 添加垂直偏移量
        目标位置.y += 垂直偏量;

        // 限制相机的水平位置（可选）
        float 相机水平位置 = Mathf.Clamp(目标位置.x, minX, maxX);

        // 计算相机的新位置
        Vector3 相机位置 = new Vector3(相机水平位置, 目标位置.y, -14); 

        // 平滑地移动相机到目标位置
        transform.position = Vector3.Lerp(transform.position, 相机位置, 跟随速度 * Time.deltaTime);

        
    }
}
