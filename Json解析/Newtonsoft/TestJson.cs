using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Newtonsoft.Json;

public class TestJson : MonoBehaviour
{
    //Unity自己的json序列化是不支持字典格式的。无意间发现了一个全新的json .net库，功能很强大，还支持序列化字典推荐给大家。
    //http://www.newtonsoft.com/json
    //点击下载，zip.解压后，把bin/net20/Newtonsoft.Json.dll 拖入unity工程。
    //写下一段简单的序列化 反序列化json的代码
    void Start()
    {

        Product product = new Product();
        product.dic["字典key"] = "字典Value";
        product.name = "我是雨松MOMO";
        string json = JsonConvert.SerializeObject(product);

        Product m = JsonConvert.DeserializeObject<Product>(json);

        Debug.Log(json);
        Debug.Log(m.name);
        Debug.Log(m.dic["字典key"]);
    }


    public class Product
    {
        public string name;
        public Dictionary<string, string> dic = new Dictionary<string, string>();
    }

}