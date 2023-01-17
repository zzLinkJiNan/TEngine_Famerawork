using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ZZUIScenePort : MonoBehaviour
{
    //当前Scene的主Transform
    public Transform skinTr;

    //初始化传递参数
    public object[] objs = new object[]{};

    //初始化
    public abstract void Ini();

    //初始化scene传递参数
    public abstract void SetObjs(object[] objs);

    //传递初始化参数
    public abstract void Iniparameter();

    //初始化配置
    public abstract void IniDeploy();

    //设置组件
    public abstract void SetModles();

    //update
    public abstract void OnUpdateUI();

    //切换Scene
    public abstract void OnChangeScene();

    //隐藏Scene
    public abstract void OnHideUI();

    //显示Scene
    public abstract void OnShowUI();
    
    //添加事件
    public abstract void OnAddEvent();
}
