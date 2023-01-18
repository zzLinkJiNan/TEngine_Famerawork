using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TEngine.Runtime;
using System;
using DG.Tweening;
using System.Reflection;
public class ZZSceneManager : UnitySingleton<ZZSceneManager>
{
    
    //当前SceneTr
    public Transform currentScene;

    //Scene栈
    private List<ZZSceneName> sceneWareHouse = new List<ZZSceneName>();

    //选择SceneUI
    public void ChooseScene(ZZSceneName sceneName,Action<string> action = null,params object[] objs){
        //选择一个 scene 要干掉之前的 scene 加载新的 scene
        if(currentScene == null && sceneWareHouse.Count == 0)
            createScene(sceneName,action,objs);
        else if(currentScene != null && sceneWareHouse.Count > 0)
        {
            Destroy(currentScene.gameObject);
            createScene(sceneName,action,objs);
        }
    }
    public void ChooseScene(ZZSceneName sceneName,params object[] objs){
        ChooseScene(sceneName,null,objs);
    }

    //切回到上个SceneUI
    public void cutUpScene(Action<string> action = null,params object[] objs){ 
        if(sceneWareHouse.Count>1)
        {
            ChooseScene(sceneWareHouse[sceneWareHouse.Count-2],action,objs);
            sceneWareHouse.RemoveAt(sceneWareHouse.Count-1);
            sceneWareHouse.RemoveAt(sceneWareHouse.Count-2);
        }
        else
            TLogger.LogInfo("不足两个SceneUI");
    }

    //创建一个scene
    private void createScene(ZZSceneName sceneName,Action<string> action = null,params object[] objs){

        Transform zScene = ZZCanvasManager.Instance.ZScene;

        string sName = sceneName.ToString();

        TResources.LoadAsync<GameObject>("Prefabs/UIMainPrefabs/Scenes/"+sName+".prefab",sceneGo=>{
            //实例化scene
            Transform scene = Instantiate(sceneGo,zScene).transform;
            sceneWareHouse.Add(sceneName);
            currentScene = scene;
            //添加脚本
            var sceneScript = Type.GetType(sName);
            ZZUISceneBase aa = scene.SearchGet<Transform>(sName).gameObject.AddComponent(sceneScript) as ZZUISceneBase;
            aa.enabled = false;
            //脚本赋值
            aa.objs = objs;
            aa.ac = action;
            aa.enabled = true;
        });
    }
    
    //显示当前Scene
    public void ShowScene(){
        if(currentScene!=null){
            currentScene.gameObject.SetActive(true);
            currentScene.SearchGet<Transform>(sceneWareHouse[sceneWareHouse.Count-1].ToString()).GetComponent<ZZUISceneBase>().OnShowUI();
        }
        else
            TLogger.LogInfo("未找到当前Scene 无法显示");
    }
    //隐藏当前Scene
    public void HideScene(){
        if(currentScene!=null){
            currentScene.gameObject.SetActive(false);
            currentScene.SearchGet<Transform>(sceneWareHouse[sceneWareHouse.Count-1].ToString()).GetComponent<ZZUISceneBase>().OnHideUI();
        }
        else
            TLogger.LogInfo("未找到当前Scene 无法隐藏");
    }
}
