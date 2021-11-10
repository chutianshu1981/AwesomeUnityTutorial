using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    // 每次伤血量
    public int damageNum=-1;

    //刚体在触发器内的每一帧都会调用此函数，而不是在刚体刚进入时仅调用一次。
    private void OnTriggerStay2D(Collider2D other)
    {
        RubyController rubyController = other.GetComponent<RubyController>();

        if (rubyController != null) {
            rubyController.ChangeHealth(damageNum);

        }
        
    }
}
