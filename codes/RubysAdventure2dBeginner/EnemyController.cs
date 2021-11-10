using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //设定移动速度变量
    public float speed = 0.1f; 
    //声明一个2d刚体对象
    Rigidbody2D rigidbody2d;
    // 声明 Vector2 对象来存放敌人当前位置
    Vector2 position;
    //声明一个初始 y 坐标变量
    float initY;
    //声明一个移动方向的变量
    float direction;
    //存放移动距离的变量，设置为共有，开放在 unity 中的访问
    public float distance=4;

    // Start is called before the first frame update
    void Start()
    {
        // 获取这些对象或变量在游戏开始时的值
        rigidbody2d = GetComponent<Rigidbody2D>();
        //获取起始位置
        position = transform.position;
        //获取起始y坐标
        initY = position.y;
        //设定初始移动方向
        direction = 1.0f;
    }

    private void FixedUpdate()
    {
        //通过刚体移动的方法调用，放入 fixupdate方法中，0.02秒执行一次
        MovePosition();
    }

    // 自定义的在 Y 轴折返移动的算法
    private void MovePosition() {
        if (position.y-initY< distance && direction>0)
        {
            position.y += speed;
        }
        if (position.y - initY >= distance && direction > 0)
        {
            direction = -1.0f;
        }
        if (position.y - initY > 0&&direction<0)
        {
            position.y -= speed;
        }
        if (position.y - initY <= 0 && direction < 0)
        {
            direction = 1.0f;
        }
        //通过刚体系统移动游戏对象
        rigidbody2d.position = position;
    }
}
