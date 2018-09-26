using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BackUI : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //监听按下
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("背后UI OnPointerDown");
    }

    //监听抬起
    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("背后UI OnPointerUp");
    }

    //监听点击
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("背后UI OnPointerClick");
    }

}
