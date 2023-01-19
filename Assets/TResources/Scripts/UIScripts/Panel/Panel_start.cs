using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TEngine.Runtime;
using DG.Tweening;
using UnityEngine.UI;

public class Panel_start : ZZUIPanelBase
{
    //----------成员组件 | 变量-----------

    //----------↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑-----------

    //初始化配置
    public override void IniDeploy()
    {
        maskIsOn = false; //遮罩是否打开
        maskColor = new Color(0,0,0,0); //遮罩颜色 RGBA : 0~1
        clickClose = false; //点击其他地方关闭当前panel
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

    }

    //添加事件
    public override void OnAddEvent()
    {
        
    }

    //update
    public override void OnUpdateUI()
    {
        base.OnUpdateUI();
        
    }

    //点击事件装载
    public override void OnClicks(Transform btnClick)
    {
        OnClose();
        switch (btnClick.name)
        {
                        
        }
    }


    //Scene完成显示后
    public override void OnShowed()
    {
        base.OnShowed();

    }
}
