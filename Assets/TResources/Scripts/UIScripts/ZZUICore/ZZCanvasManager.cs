using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TEngine.Runtime;
using System;
using DG.Tweening;
public class ZZCanvasManager : UnitySingleton<ZZCanvasManager>
{
    public RectTransform MainCanvas;

    public Transform ZScene;
    public Transform ZPanel;
    public Transform ZMask;
    public Transform ZTip;

    //是否创建出全局唯一Canvas
    public bool isCreateCanvas = false;

    protected override void OnLoad() 
    {
        if(!isCreateCanvas){
            createCanvas(go=>{
                MainCanvas = go.GetComponent<RectTransform>();
                DontDestroyOnLoad(MainCanvas);
                ZScene = go.transform.SearchGet<Transform>("ZScene");
                ZPanel = go.transform.SearchGet<Transform>("ZPanel");
                ZMask = go.transform.SearchGet<Transform>("ZMask");
                ZTip = go.transform.SearchGet<Transform>("ZTip");
                isCreateCanvas = true;
            });
        }
    }

    private void createCanvas(Action<GameObject> canvas){
        TResources.LoadAsync<GameObject>("Prefabs/UIMainPrefabs/MainCanvas/MainCanvas.prefab",mainCanvas => {
            canvas?.Invoke(Instantiate(mainCanvas));
        });
    }
    
}
