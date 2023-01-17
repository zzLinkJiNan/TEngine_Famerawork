using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZZUISceneBase : ZZUIScenePort
{
    private void Start() {Ini();}
    private void Update() {OnUpdateUI();}
    private void OnDestroy() {OnChangeScene();}

    //Scene初始化栈
    public override void Ini()
    {
        IniDeploy();
        Iniparameter();
        SetModles();
        OnAddEvent();
    }

    public override void IniDeploy()
    {
        
    }

    public override void Iniparameter()
    {
        if(objs.Length<=0)
            return;
    }

    public override void OnChangeScene()
    {

    }

    public override void SetObjs(object[] objs){
        this.objs = objs;
    }

    //scenemanager中管理
    public override void OnHideUI()
    {

    }
    
    //scenemanager中管理
    public override void OnShowUI()
    {

    }

    public override void OnUpdateUI()
    {

    }

    public override void SetModles()
    {

    }

    public override void OnAddEvent()
    {
        
    }
}
