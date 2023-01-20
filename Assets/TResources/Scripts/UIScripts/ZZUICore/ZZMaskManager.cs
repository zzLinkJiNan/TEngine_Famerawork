using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TEngine.Runtime;
using System;
using DG.Tweening;
using System.Reflection;
//Mask Manager 只负责创建出选择的Mask 不负责管理
public class ZZMaskManager : UnitySingleton<ZZMaskManager>
{

    //创建一个Mask (Mask自己控制自己的生命周期就好)
    public void CreateMask(ZZMaskName maskName,Action<string> action = null,params object[] objs){
        
        Transform zMask = ZZCanvasManager.Instance.ZMask;

        string mName = maskName.ToString();

        TResources.LoadAsync<GameObject>("Prefabs/UIMainPrefabs/Masks/"+mName+".prefab",panelGo=>{
            //实例化该mask
            Transform mask = Instantiate(panelGo,zMask).transform;
            mask.name = mName;
            //添加脚本
            var maskScript = Type.GetType(mName);
            ZZUIMaskBase zumb = mask.gameObject.AddComponent(maskScript) as ZZUIMaskBase;
            zumb.enabled = false;
            //绑定事件
            BindingEvent(mask);
            //脚本赋值
            zumb.objs = objs;
            zumb.ac = action;
            zumb.enabled = true;
        });
    }

    public void CreateMask(ZZMaskName maskName,params object[] objs){
        CreateMask(maskName,null,objs);
    }

    public void BindingEvent(Transform parent){
        Transform[] children = parent.GetComponentsInChildren<Transform>();
        foreach (var item in children)
        {
            if(item.name.StartsWith("Btn_")){
                UIEventListener ul = item.GetOrAddComponent<UIEventListener>();
                ul.OnClick += ()=>{parent.GetComponent<ZZUIMaskBase>().OnClicks(item);};
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

}
