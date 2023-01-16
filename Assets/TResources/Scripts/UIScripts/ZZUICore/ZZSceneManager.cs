using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TEngine.Runtime;
using System;

public class ZZSceneManager : UnitySingleton<ZZSceneManager>
{
    
    //当前SceneTr
    public Transform currentScene;

    //Scene栈
    private List<ZZSceneName> sceneWareHouse = new List<ZZSceneName>();

    

    //选择SceneUI
    public void ChooseScene(ZZSceneName sceneName,Action<string> action = null,bool isCut = false){
                 
    }

    //切回到上个SceneUI
    public void cutUpScene(){
        if(sceneWareHouse.Count>1)
        {
            ChooseScene(sceneWareHouse[sceneWareHouse.Count-2],null,true);
        }
        else
            TLogger.LogInfo("不足两个SceneUI");
    }
    
    //显示当前Scene
    public void ShowScene(){
        if(currentScene!=null)
            currentScene.gameObject.SetActive(true);
        else
            TLogger.LogInfo("未找到当前Scene 无法显示");
    }
    //隐藏当前Scene
    public void HideScene(){
        if(currentScene!=null)
            currentScene.gameObject.SetActive(false);
        else
            TLogger.LogInfo("未找到当前Scene 无法隐藏");
    }
}
