using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TEngine.Runtime;
using DG.Tweening;
public class Scene_Test : ZZUISceneBase
{

    public override void Iniparameter()
    {
        if(objs.Length>0){
            skinTr.SearchGet<Transform>("");
        }
    }

    //初始化配置
    public override void IniDeploy()
    {
        maskIsOn = false; //遮罩是否打开
        maskColor = new Color(0,0,0,0); //遮罩颜色 RGBA : 0~1
        base.IniDeploy();
    }

    //添加事件
    public override void OnAddEvent()
    {
         
    }

     

    //组件赋值
    public override void SetModles()
    {
        
    }

    //面板被切换后
    public override void OnChangeScene()
    {
        base.OnChangeScene();
    }

    //UI完成显示后
    public override void OnShowed()
    {
        base.OnShowed();
    }

    public override void OnUpdateUI()
    {
        base.OnUpdateUI();

    }
}
