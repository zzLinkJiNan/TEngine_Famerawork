using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ABCTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z)){
            ZZSceneManager.Instance.ChooseScene(ZZSceneName.Scene_MyMainScene);
        }
        if(Input.GetKeyDown(KeyCode.X)){
            ZZSceneManager.Instance.ChooseScene(ZZSceneName.Scene_Ttest);
        }
        if(Input.GetKeyDown(KeyCode.C)){
            ZZSceneManager.Instance.cutUpScene();
        }
        if(Input.GetKeyDown(KeyCode.V)){
            ZZPanelManager.Instance.CreatePanel(ZZPanelName.Panel_lalala);
        }
        if(Input.GetKeyDown(KeyCode.B)){
            ZZPanelManager.Instance.ClosePanel(ZZPanelName.Panel_lalala);
        }
    }
}

