using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ReadHolders : MonoBehaviour {
    readonly string assetName = "booknames";
    // Use this for initialization
    void Start () {
        BookHolder asset = Resources.Load<BookHolder>(assetName);
        foreach (Menu gd in asset.menus)
        {
            Debug.Log(gd.m_Id);
            Debug.Log(gd.m_level);
            Debug.Log(gd.m_parentId);
            Debug.Log(gd.m_name);
        }

        
    }
}
