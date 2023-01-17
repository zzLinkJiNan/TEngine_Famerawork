using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TEngine.Runtime;
public class Scene_Test : ZZUISceneBase
{
    public override void Ini()
    {
        base.Ini();
    }

    public override void Iniparameter()
    {
        base.Iniparameter();
        foreach (var item in objs)
        {
            TLogger.LogInfo(item.ToString());
        }     
    }
}
