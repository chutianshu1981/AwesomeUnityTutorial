using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    //设置玩家无敌的时间间隔
    public float timeInvincible = 2.0f;
    // 设置是否无敌的变量
    bool isInvincible;
    // 定义变量，进行无敌时间的计时，无敌时间计时器
    float invincibleTimer;

    // 设置最大生命值（生命上限）
    public int maxHealth = 5;
    // 设置当前生命值的属性 health

    // C# 中支持面向对象程序设计中的封装概念，对数据成员的保护
    // 数据成员变量，默认一般都应该设置为私有，只能通过当前类的方法或属性进行访问
    // 属性是公有的，可以通过取值器 get 、赋值器 set 设定对应字段的访问规则，满足规则才能够访问
    public int health { 
        get { return currentHealth; } 
        //set {currentHealth=value;}
    }
    int currentHealth; 

    //声明刚体对象
    Rigidbody2D rigidbody2d;
    //获取用户输入
    float horizontal;
    float vertical;

    // 将速度暴露出来，使其可调
    public float speed = 0.1f;

    //声明一个 动画管理者组件对象
    Animator animator;
    //创建一个二维矢量，用来存储 Ruby 静止不移动时 看的方向（即面向的方向）
    //与机器人相比，Ruby 可以站立不动。她站立不动时，Move X 和 Y 均为 0，这时状态机就没法获取 Ruby 静止时的朝向
    //所以需要手动设置一个
    Vector2 lookDirection = new Vector2(1, 0);
    Vector2 move;
    private void Start()
    {
        //获取当前游戏对象的刚体组件
        rigidbody2d = GetComponent<Rigidbody2D>();
        //游戏刚开始，玩家满血
        //初始化当前生命值
        currentHealth = maxHealth;

        animator = GetComponent<Animator>();
    }

    // 每帧调用一次 Update
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        //判断是否处于无敌状态，来进行计时器的倒计时
        if (isInvincible) {
            //如果无敌，进入倒计时
            //invincibleTimer = invincibleTimer - Time.deltaTime;
            //每次update减去一帧所消耗的时间
            invincibleTimer -= Time.deltaTime;
            //直到计时器中时间用完
            if (invincibleTimer < 0) {
                //取消无敌状态
                isInvincible = false;
            }
        }
        
        //创建一个二维矢量对象来表示 Ruby移动的数据信息
        move = new Vector2(horizontal, vertical);
        //如果move中的 x/y 不为零，表示正在运动
        //将 ruby 面向方向设置为移动方向
        //停止移动，保持以前方向，所以这个 If 结构用于转向时重新赋值面朝方向
        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f)) {
            lookDirection.Set(move.x, move.y);

            //使向量长度为1，可以将此方法称为 向量的“归一化”方法
            //通常用在表示方向，而非位置的向量上
            //因为blend tree 中表示方向的参数值取值范围是 -1.0 到 1.0，
            //所以一般用 向量作为 Animator.SetFloat 方法的参数时，一般要对向量先进行 “归一化”处理 
            lookDirection.Normalize();
        }
        
        //传递 Ruby 面朝方向 给 blend tree
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        //传递 Ruby 速度给 blend tree
        //矢量的 magnitue 属性，用来返回矢量的长度
        animator.SetFloat("Speed", move.magnitude);

    }

    //固定时间间隔执行的更新方法
    private void FixedUpdate()
    {
        Vector2 position = transform.position;
        position= position + speed * move * Time.deltaTime;
        
        rigidbody2d.MovePosition(position);
    }

    //更改生命值的方法
    public void ChangeHealth(int amount) {
        //假设玩家受伤害的时间间隔，必须是2秒
        if (amount < 0) {
            //判断当前玩家是否处于无敌状态
            if (isInvincible) {
                //无敌状态不伤血，跳出当前函数
                return;
            }
            //当不是无敌状态时，会执行下面的代码
            //重置无敌状态为真
            isInvincible = true;
            //重置无敌时间
            invincibleTimer = timeInvincible;

            //播放受伤动画
            animator.SetTrigger("Hit");

        }


        //限制方法，限制当前生命值的赋值范围：0-最大生命值
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        //在控制台输出生命信息
        Debug.Log("当前生命值： " + currentHealth + "/" + maxHealth);
    }

}
