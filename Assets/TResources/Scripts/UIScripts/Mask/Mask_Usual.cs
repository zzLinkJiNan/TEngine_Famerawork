﻿using System.Collections;

using System.Collections.Generic;
using UnityEngine;
using TEngine.Runtime;
using DG.Tweening;
using UnityEngine.UI;

public class Mask_Usual : ZZUIMaskBase
{
    //----------成员组件 | 变量-----------
    Text tex_tx;
    string txt;
    //----------↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑-----------

    //初始化配置
    public override void IniDeploy()
    {
        CGAlpha = 0; //初始mask透明度
        base.IniDeploy();
    }
	
    //初始化参数
    public override void Iniparameter(){
        if(objs.Length>0){
            txt = objs[0].ToString();
        }
    }

    //组件赋值
    public override void SetModles()
    {
        tex_tx = skinTr.SearchGet<Text>("tex_tx");

        tex_tx.text = "";
    }

    //添加事件
    public override void OnAddEvent()
    {
        tex_tx.DOText(txt,1);

        DOTween.To(() => CG.alpha, p => CG.alpha = p, 1, 1f).OnComplete (()=>{
            Invoke("realClose",2f);
        });
    }

    public void realClose(){
        DOTween.To(() => CG.alpha, p => CG.alpha = p, 0, 1f).OnComplete (()=>{
            OnClose();
        });
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

    //Mask完成显示后
    public override void OnShowed()
    {
        base.OnShowed();

    }
}
