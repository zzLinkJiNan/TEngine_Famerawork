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
        if(Input.GetKeyDown(KeyCode.N)){
            ZZPanelManager.Instance.CreatePanel(ZZPanelName.Panel_la2);
        }
        if(Input.GetKeyDown(KeyCode.M)){
            ZZPanelManager.Instance.ClosePanel(ZZPanelName.Panel_la2);
        }
        if(Input.GetKeyDown(KeyCode.L)){
            ZZMaskManager.Instance.CreateMask(ZZMaskName.Mask_Usual,"话说那一日...");
        }
        if(Input.GetKeyDown(KeyCode.J)){
            ZZTipManager.Instance.CreateTip(ZZTipName.Tip_Usual,"请耐心等待下...",TipShowLocation.在上方往下叠加,TipShowType.变大变小);
        }
        if(Input.GetKeyDown(KeyCode.K)){
            ZZTipManager.Instance.CreateTip(ZZTipName.Tip_Usual,"请耐心等待下...",TipShowLocation.在上方,TipShowType.变大变小);
        }
        if(Input.GetKeyDown(KeyCode.H)){
            ZZTipManager.Instance.CreateTip(ZZTipName.Tip_Usual,"请耐心等待下...",TipShowLocation.居中,TipShowType.变大变小);
        }
        if(Input.GetKeyDown(KeyCode.G)){
            ZZTipManager.Instance.CreateTip(ZZTipName.Tip_Usual,"请耐心等待下...",TipShowLocation.在上方,TipShowType.渐出渐隐);
        }
        if(Input.GetKeyDown(KeyCode.F)){
            ZZTipManager.Instance.CreateTip(ZZTipName.Tip_Usual,"请耐心等待下...",TipShowLocation.在上方往下叠加,TipShowType.渐出渐隐);
        }
        if(Input.GetKeyDown(KeyCode.D)){
            ZZTipManager.Instance.CreateTip(ZZTipName.Tip_Usual,"请耐心等待下...",TipShowLocation.居中,TipShowType.渐出渐隐,bl =>{
                if(bl)
                    Debug.Log("已关闭");
            });
        }
    }
}

