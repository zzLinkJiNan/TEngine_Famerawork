using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TEngine.Runtime;
using System;
using DG.Tweening;
using System.Reflection;
public class ZZPanelManager : UnitySingleton<ZZPanelManager>
{
    
    //Panel字典
    private Dictionary<ZZPanelName,Transform> panelWareHouse = new Dictionary<ZZPanelName,Transform>();

    //创建一个panel
    public void CreatePanel(ZZPanelName panelName,Action<string> action = null,params object[] objs){
        //判重
        Transform choosePanel = null;
        panelWareHouse.TryGetValue(panelName,out choosePanel);
        if(choosePanel){TLogger.LogInfo("已存在该panel 请不要反复生成");return;}
            
        Transform zPanel = ZZCanvasManager.Instance.ZPanel;

        string pName = panelName.ToString();

        TResources.LoadAsync<GameObject>("Prefabs/UIMainPrefabs/MainCanvas/Panel_Base.prefab",panelBase=>{
            //实例化panelBase
            Transform panelB = Instantiate(panelBase,zPanel).transform;
            panelB.name = pName;
            TResources.LoadAsync<GameObject>("Prefabs/UIMainPrefabs/Panels/"+pName+".prefab",panelGo=>{
                //实例化该panel
                Transform panel = Instantiate(panelGo,panelB).transform;
                panel.name = pName;
                panelWareHouse.Add(panelName,panelB);
                //添加脚本
                var panelScript = Type.GetType(pName);
                ZZUIPanelBase zusb = panel.gameObject.AddComponent(panelScript) as ZZUIPanelBase;
                zusb.enabled = false;
                //绑定事件
                BindingEvent(panel);
                //脚本赋值
                zusb.objs = objs;
                zusb.ac = action;
                zusb.enabled = true;
            });
        });
    }
    public void CreatePanel(ZZPanelName panelName,params object[] objs){
        CreatePanel(panelName,null,objs);
    }

    //关闭某个panel
    public void ClosePanel(ZZPanelName panelName){
        Transform choosePanel = null;
        panelWareHouse.TryGetValue(panelName,out choosePanel);
        if(choosePanel!=null){
            choosePanel.SearchGet<ZZUIPanelBase>(panelName.ToString()).OnClose();
        }
        else
            TLogger.LogInfo("没有找到这个panel被打开");
    }

    public void BindingEvent(Transform parent){
        Transform[] children = parent.GetComponentsInChildren<Transform>();
        foreach (var item in children)
        {
            if(item.name.StartsWith("Btn_")){
                UIEventListener ul = item.GetOrAddComponent<UIEventListener>();
                ul.OnClick += ()=>{parent.GetComponent<ZZUIPanelBase>().OnClicks(item);};
                //通过预添加脚本来加载更多的效果
                UIAniUtil uau = item.GetComponent<UIAniUtil>();
                if(uau){
                    ul.uiAniType = uau.IANITYPE;
                    ul.enterReplaceImg = uau.replaceImg;
                    ul.textColor = uau.textColor;
                    ul.imageColor = uau.imageColor;
                }
            }
        }     
    }

    //移除一个panel
    public void removePanelDicOne(string panelName){
        foreach (var item in panelWareHouse)
        {
            if(panelName.Equals(item.Key.ToString())){
                panelWareHouse.Remove(item.Key);
                return;    
            }
        } 
        TLogger.LogInfo("panel字典中未被移除?! 请检查panel字典的问题!!!");
    }
    
    //显示Panel
    public void ShowPanel(ZZPanelName panelName){
        Transform choosePanel = null;
        panelWareHouse.TryGetValue(panelName,out choosePanel);
        if(choosePanel!=null){
            choosePanel.gameObject.SetActive(true);
            choosePanel.SearchGet<ZZUIPanelBase>(panelName.ToString()).OnShowUI();
        }
        else
            TLogger.LogInfo("没有找到这个panel被打开");
    }
    //隐藏当前Panel
    public void HidePanel(ZZPanelName panelName){
        Transform choosePanel = null;
        panelWareHouse.TryGetValue(panelName,out choosePanel);
        if(choosePanel!=null){
            choosePanel.gameObject.SetActive(false);
            choosePanel.SearchGet<ZZUIPanelBase>(panelName.ToString()).OnHideUI();
        }
        else
            TLogger.LogInfo("没有找到这个panel被打开");
    }
}
