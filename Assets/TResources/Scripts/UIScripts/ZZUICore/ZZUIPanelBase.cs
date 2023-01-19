using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZZUIPanelBase : ZZUIPanelPort
{
    private void Start() {Ini();}
    private void Update() {OnUpdateUI();}

    //Scene初始化流程
    public override void Ini()
    {
        IniDeploy();
        Iniparameter();
        SetModles();
        OnAddEvent();
        OnShowed();
    }

    //初始化panel配置
    public override void IniDeploy()
    {
        skinTr = transform;
        mainMask = transform.parent.Find("mainMask").GetComponent<Image>();
        mainMask.color = maskColor;
        mainMask.enabled = maskIsOn;
        if(clickClose){
            UIEventListener uel = mainMask.gameObject.GetOrAddComponent<UIEventListener>();
            uel.OnClick += ()=>{OnClose();};
            uel.uiAniType = UIANITYPE.NONE;
        }
    }

    public override void Iniparameter()
    {
        
    }

    //panelmanager中管理
    public override void OnHideUI()
    {

    }
    
    //panelmanager中管理
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

    public override void OnClose()
    {
        Destroy(transform.parent.gameObject);
        ZZPanelManager.Instance.removePanelDicOne(transform.name);
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
