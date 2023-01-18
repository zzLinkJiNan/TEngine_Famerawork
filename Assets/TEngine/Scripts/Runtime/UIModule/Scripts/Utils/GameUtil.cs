using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GameUtil : MonoBehaviour
{

    /// <summary>
    /// 生成obj
    /// </summary>
    public static void CreateObj(GameObject obj,Transform parent) {
        GameObject go = Instantiate(obj, parent);
        go.name = go.name.Replace("(Clone)","");
    }

    /// <summary>
    /// 使用Go的MeshRenderer给Go添加碰撞盒 与 静态Rigidbody
    /// </summary>
    /// <param name="go"></param>
    public static void AddColliderUseMeshRendererSize(GameObject go,bool isTrigger)
    {
        BoxCollider bc = go.GetOrAddComponent<BoxCollider>();
        bc.size = go.GetComponent<Renderer>().bounds.size;
        bc.isTrigger = isTrigger;

        Rigidbody rd = go.GetOrAddComponent<Rigidbody>();
        rd.useGravity = false;
        rd.isKinematic = true;
    }

    /// <summary>
    /// 通过内容修改在该Dropdown的value
    /// </summary>
    public static void StringByDropDownIndex(Dropdown dd,string ex)
    {
        for (int i = 0; i < dd.options.Count; i++)
        {
            if (dd.options[i].text.Equals(ex))
                dd.value = i;
        }
    }

    /// <summary>
    /// string 转 enum
    /// </summary>
    public static T StringToEnum<T>(string str)
    {
        return (T)Enum.Parse(typeof(T), str);
    }

    /// <summary>
    /// Texture 转 Sprite
    /// </summary>
    public static Sprite TextureToSprite(Texture texture) {
        return Sprite.Create(texture as Texture2D, 
            new Rect(0, 0, texture.width, texture.height), 
            new Vector2(0.5f, 0.5f));
    }

    /// <summary>
    /// 按照物体大小添加box碰撞 和刚体  
    /// </summary>
    public static BoxCollider addColliderUseMeshRendererSize(GameObject go,MeshRenderer mr,bool isTrigger)
    {
        BoxCollider bc = go.GetOrAddComponent<BoxCollider>();
        bc.transform.rotation = go.transform.rotation;
        bc.size = mr.bounds.size;
        bc.isTrigger = isTrigger;
        Rigidbody rd = go.GetOrAddComponent<Rigidbody>();
        rd.useGravity = false;
        rd.isKinematic = true;
        return bc;
    }

    /// <summary>
    /// 在StreamingAssets下读取txt
    /// </summary>
    public static IEnumerator IEReadTxtByStreamingAssets(string mName, Action<string> acc)
    {
        UnityWebRequest request = UnityWebRequest.Get(Application.streamingAssetsPath+"/"+mName+".txt");
        yield return request.SendWebRequest();
        string str = request.downloadHandler.text;

        acc?.Invoke(str);
    }


    /// <summary>
    /// 创建txt 参数一:内容 参数二:名称
    /// </summary>
    public static void AddTxtTextByFileStream(string title,string txtText)
    {
        string path = Application.dataPath + "/TXT";
        string target = "/" + title + ".txt";

        //不存在则创建文件路径
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        // 文件流创建一个文本文件
        FileStream file = new FileStream(path + target, FileMode.Create);
        //得到字符串的UTF8 数据流
        byte[] bts = System.Text.Encoding.UTF8.GetBytes(txtText);
        // 文件写入数据流
        file.Write(bts, 0, bts.Length);
        if (file != null)
        {
            //清空缓存
            file.Flush();
            // 关闭流
            file.Close();
            //销毁资源
            file.Dispose();
        }
    }

    /// <summary>
    /// 返回对应泛型带有startPrefix开头的集合
    /// </summary>
    public static List<T> GetComponentsInPrefixChildren<T>(Transform father,string startPrefix) {
        T[] childrens = father.GetComponentsInChildren<T>();
        List<T> items = new List<T>();
        foreach (var item in childrens)
        {
            if (item.ToString().StartsWith(startPrefix))
                items.Add(item);
        }
        return items;
    }

    /// <summary>
    /// mp3 网络请求
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public IEnumerator SendGet(string url)

    {
        UnityWebRequest uwr = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.MPEG);

        yield return uwr.SendWebRequest();

        if (uwr.isDone)
        {
            yield return DownloadHandlerAudioClip.GetContent(uwr);
            yield break;
        }
    }

    /// <summary>
    /// 创建预制体
    /// </summary>
    /// <param name="go"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static void CreatePrefab(GameObject go, string name)
    {
#if UNITY_EDITOR
        string localPath = "Assets/Resources/Prefab/" + name + ".prefab";
        bool success = false;
        GameObject tempPrefab = PrefabUtility.SaveAsPrefabAssetAndConnect(go, localPath, InteractionMode.UserAction, out success);
        if (success) { Debug.Log("创建" + name + "成功"); }
#endif
    }

    /// <summary>
    /// 刷新UI (主要用于ContentSizeFitter)
    /// </summary>
    /// <param name="rect"></param>
    /// <returns></returns>
    public static IEnumerator UpdateLayout(RectTransform rect)
    {
        int count = 0;
        while (true)
        {
            count++;
            LayoutRebuilder.ForceRebuildLayoutImmediate(rect);
            yield return new WaitForSeconds(0.002f);
            if (count >= 10)
            {
                yield break;
            }
        }
    }

    /// <summary>
    /// 更换材质球
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="mName"></param>
    public static void UpdateMaterial(Transform obj, string mName)
    {
        MeshRenderer mr = obj.GetComponent<MeshRenderer>();
        mr.material = Resources.Load<Material>("Material/" + mName);
    }

    /// <summary>
    /// 清子
    /// </summary>
    /// <param name="tr"></param>
    public static void ClearChild(Transform tr,Action<bool> bl = null)
    {
        if (tr.childCount > 0)
        {
            for (int i = 0; i < tr.childCount; i++)
            {
                Destroy(tr.GetChild(i).gameObject);
            }
        }
        bl?.Invoke(true);
    }
    /// <summary>
    /// 清子 只删除叫str的对象
    /// </summary>
    /// <param name="tr"></param>
    public static void ClearChild(Transform tr, string str)
    {
        if (tr.childCount > 0)
        {
            for (int i = 0; i < tr.childCount; i++)
            {
                //如果名字是str的物体
                if (tr.GetChild(i).name == str)
                    Destroy(tr.GetChild(i).gameObject);
            }
        }
    }
    

    /// <summary>
    /// 按Y轴一直旋转 记得关闭此携程
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="speed"></param>
    /// <returns></returns>
    public static IEnumerator RoY(GameObject obj, float speed)
    {
        while (true)
        {
            obj.transform.Rotate(Vector3.up * Time.deltaTime * speed);
            yield return 0;
        }
    }

    /// <summary>
    /// 检测是否点击UI
    /// </summary>
    /// <param name="mousePosition"></param>
    /// <returns></returns>
    public static bool IsPointerOverGameObject(Vector2 mousePosition)
    {
        //创建一个点击事件
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = mousePosition;
        List<RaycastResult> raycastResults = new List<RaycastResult>();
        //向点击位置发射一条射线，检测是否点击UI
        EventSystem.current.RaycastAll(eventData, raycastResults);
        if (raycastResults.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// 鼠标位置射线检测点击根据Tag返回首个点击到的物体
    /// </summary>
    /// <returns>GameObject 无为 null</returns>
    public static Transform rayMouseCallTransform(List<string> Tag)
    {
        //屏幕坐标转为射线，检测物体碰撞，判断鼠标点击到哪个物体上
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit[] hits = Physics.RaycastAll(ray, 10);

        SortHits(ref hits);

        for (int i = 0; i < hits.Length; i++)
        {
            foreach (var item in Tag)
            {
                if (hits[i].transform.tag == item)
                    return hits[i].transform;
            }
        }

        return null;
    }

    /// <summary>
    /// 鼠标位置射线检测点击到哪个物体上
    /// </summary>
    /// <returns>GameObject 无为 null</returns>
    public static void rayMouseCallGameObj()
    {
        //屏幕坐标转为射线，检测物体碰撞，判断鼠标点击到哪个物体上
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        RaycastHit [] hits = Physics.RaycastAll(ray,10);

        SortHits(ref hits);

        for (int i = 0; i < hits.Length; i++)
        {
            Debug.Log(hits[i].transform.name);
        }
    }
    public static void SortHits(ref RaycastHit[] hits)
    {
        Array.Sort<RaycastHit>(hits, HitComparison); // 将结果按照远近排序
    }

    private static int HitComparison(RaycastHit a, RaycastHit b)
    {
        if (a.distance <= b.distance)
        {
            return -1;
        }
        return 1;
    }

    /// <summary>
    /// 替换Dictionary key
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="dic"></param>
    /// <param name="key"></param>
    /// <param name="reKey"></param>
    public static void replaceKey<T>(ref Dictionary<string, T> dic,string key,string reKey)
    {
        dic = dic.ToDictionary(k => k.Key == key ? reKey : k.Key, k => k.Value);
    }

    

}