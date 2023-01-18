using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZZUISceneBase : ZZUIScenePort
{
    private void Start() {Ini();}
    private void Update() {OnUpdateUI();}
    private void OnDestroy() {OnChangeScene();}

    //Scene初始化流程
    public override void Ini()
    {
        IniDeploy();
        Iniparameter();
        SetModles();
        OnAddEvent();
        OnShowed();
    }

    public override void IniDeploy()
    {
        skinTr = transform;
        mainMask = transform.parent.Find("mainMask").GetComponent<Image>();
        mainMask.color = maskColor;
        mainMask.enabled = maskIsOn;
    }

    public override void Iniparameter()
    {
        
    }

    public override void OnChangeScene()
    {

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

    public override void OnShowed()
    {
        
    }

    public override void OnClicks(Transform btnClick)
    {
        switch (btnClick.name)
        {
            case "":

            break;
        }
    }
}
