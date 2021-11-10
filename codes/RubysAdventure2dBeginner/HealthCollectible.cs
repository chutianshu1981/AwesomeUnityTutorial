using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    //草莓加的血量
    public int amount=1;
    //用来记录碰撞次数
    int collideCount;
    //添加触发器碰撞事件，每次碰撞触发器时，执行其中的代码
    private void OnTriggerEnter2D(Collider2D other)
    {
        collideCount = collideCount + 1;
        Debug.Log($"和当前物体发生碰撞的对象是：{other}，当前是第{collideCount}次碰撞！");

        //获取 Ruby 游戏对象的脚本组件对象
        RubyController rubyController = other.GetComponent<RubyController>();

        if (rubyController != null)
        {
            if (rubyController.health < rubyController.maxHealth)
            {
                //更改生命值
                rubyController.ChangeHealth(amount);
                //销毁当前游戏对象
                //可以让草莓被吃掉，消失
                Destroy(gameObject);
            }
            else {
                Debug.Log("当前玩家角色生命是满的，不需要加血！");
            }
        }
        else {
            Debug.LogError("rubyController 游戏组件并未获取到。。。。。");
        }

    }
}
