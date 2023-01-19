using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TEngine.Runtime;
using DG.Tweening;
using UnityEngine.UI;

public class Scene_Ttest : ZZUISceneBase
{
    //----------成员组件 | 变量-----------
    UIEventListener Btn_close;UIEventListener Btn_close1;UIEventListener Btn_close2;UIEventListener Btn_close3;
    //----------↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑-----------

    //初始化配置
    public override void IniDeploy()
    {
        maskIsOn = false; //遮罩是否打开
        maskColor = new Color(0,0,0,0); //遮罩颜色 RGBA : 0~1
        base.IniDeploy();
    }
	
    //初始化参数
    public override void Iniparameter(){
        if(objs.Length>0){
            
        }
    }

    //组件赋值
    public override void SetModles()
    {
        Btn_close = skinTr.SearchGet<UIEventListener>("Btn_close");
        Btn_close1 = skinTr.SearchGet<UIEventListener>("Btn_close1");
        Btn_close2 = skinTr.SearchGet<UIEventListener>("Btn_close2");
        Btn_close3 = skinTr.SearchGet<UIEventListener>("Btn_close3");

    }

    //添加事件
    public override void OnAddEvent()
    {
        Btn_close.OnUpdateDown += ()=>{

            TLogger.LogInfo("Btn_close 正在拖动");
        };

        Btn_close1.OnClick += ()=>{
            Debug.Log("点击");    

        };
    }

    //update
    public override void OnUpdateUI()
    {
        base.OnUpdateUI();
        
    }

    //点击事件装载
    public override void OnClicks(Transform btnClick)
    {
        switch (btnClick.name)
        {
            
        }
    }

    //Scene被切换后
    public override void OnChangeScene()
    {
        base.OnChangeScene();

    }

    //Scene完成显示后
    public override void OnShowed()
    {
        base.OnShowed();

    }
}
