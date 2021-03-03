using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnBtnEnter : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public GameObject hintUI;
    // Start is called before the first frame update
    //鼠标进入按钮触发音效和动画

    public void OnPointerEnter(PointerEventData eventData)
    {
        hintUI.SetActive(true);

    }
//鼠标离开时关闭动画
    public void OnPointerExit(PointerEventData eventData)
    {
        hintUI.SetActive(false);
    }
}
