using UnityEngine;

namespace TEngine.Runtime
{
    /// <summary>
    /// 实用静态工具
    /// </summary>
    public static class Utilitys
    {

        public static T SearchGet<T>(this Transform target,string name) where T : UnityEngine.Object{
            T [] results = target.GetComponentsInChildren<T>();
            foreach (var item in results)
            {
                if(item.name.Equals(name))
                    return item;
            }
            TLogger.LogInfo("未在该类型下找到子名:"+name);
            return default;
        }


        public static T GetOrAddComponent<T>(this Transform transform) where T : UnityEngine.Component{
            T comp = transform.GetComponent<T>();
            if(comp==null)
                return transform.gameObject.AddComponent<T>();
            else
                return comp;
        }

        
        public static T GetOrAddComponent<T>(this RectTransform transform) where T : UnityEngine.Component{
            T comp = transform.GetComponent<T>();
            if(comp==null)
                return transform.gameObject.AddComponent<T>();
            else
                return comp;
        }
    }
}