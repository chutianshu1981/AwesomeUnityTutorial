using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    private void Reset()
    {
        Debug.Log("Reset 生命周期方法.............");
        Debug.Log("用来设置初始化配置");
    }
    private void Awake()
    {
        Debug.Log("Awake 生命周期方法.............");
        Debug.Log("实例将被加载时，执行 Awake");
    }
    private void OnEnable()
    {
        Debug.Log("OnEnable 生命周期方法.............");
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start 生命周期方法.............");
        Debug.Log("脚本实例被加载后，开始脚本...");
    }
    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate 生命周期方法.............");
        Debug.Log("据说这个update 跟帧数无关");
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update 生命周期方法.............");
        Debug.Log("和帧数相关的 update ，每次刷新就执行");
    }
    private void LateUpdate()
    {
        Debug.Log("LateUpdate 生命周期方法.............");
    }
    void OnGUI(){
        GUI.skin.label.fontSize = 100;
        GUI.Label(new Rect(10, 10, Screen.width, Screen.height), "Hello World!");
    }

    private void OnDisable()
    {
        Debug.Log("OnDisable 生命周期方法.............");
    }

    private void OnDestroy()
    {
        Debug.Log("OnDestroy 生命周期方法.............");
    }
}
