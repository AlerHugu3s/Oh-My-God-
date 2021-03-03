using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursurControl : MonoBehaviour
{
    public Texture2D cursorNormal_1;
    public Texture2D cursorNormal_2;
    public Texture2D cursorA_1;
    public Texture2D cursorA_2;
    public Texture2D cursorB_1;
    public Texture2D cursorB_2;
    public Texture2D cursorC_1;
    public Texture2D cursorC_2;
    public Texture2D cursorD_1;
    public Texture2D cursorD_2;
    public Texture2D cursorE_1;
    public Texture2D cursorE_2;
    private bool isCursorA = false;
    private bool isCursorB = false;
    private bool isCursorC = false;
    private bool isCursorD = false;
    private bool isCursorE = false;
    private bool isNormal = true;
    public CursorMode cm = CursorMode.Auto;





    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursorNormal_1,Vector2.zero,cm);
    }

    // Update is called once per frame
    void Update()
    {
        Click();
    }
    
    public void IsNormal()
    {
        isNormal = true;
        isCursorA = false;
        isCursorB = false;
        isCursorC = false;
        isCursorD = false;
        isCursorE = false;
        Cursor.SetCursor(cursorNormal_1,Vector2.zero,cm);
    }

    public void IsClickA()
    {
        isNormal = false;
        isCursorA = true;
        isCursorB = false;
        isCursorC = false;
        isCursorD = false;
        isCursorE = false;
        Cursor.SetCursor(cursorA_1,Vector2.zero,cm);
    }
    public void IsClickB()
    {
        isNormal = false;
        isCursorA = false;
        isCursorB = true;
        isCursorC = false;
        isCursorD = false;
        isCursorE = false;
        Cursor.SetCursor(cursorB_1,Vector2.zero,cm);
    }
    public void IsClickC()
    {
        isNormal = false;
        isCursorA = false;
        isCursorB = false;
        isCursorC = true;
        isCursorD = false;
        isCursorE = false;
        Cursor.SetCursor(cursorC_1,Vector2.zero,cm);
    }
    public void IsClickD()
    {
        isNormal = false;
        isCursorA = false;
        isCursorB = false;
        isCursorC = false;
        isCursorD = true;
        isCursorE = false;
        Cursor.SetCursor(cursorD_1,Vector2.zero,cm);
    }
    public void IsClickE()
    {
        isNormal = false;
        isCursorA = false;
        isCursorB = false;
        isCursorC = false;
        isCursorD = false;
        isCursorE = true;
        Cursor.SetCursor(cursorE_1,Vector2.zero,cm);
    }

    void Click()
    {
        if(Input.touchCount==1 && Input.touches[0].phase == TouchPhase.Began)//Input.GetMouseButtonDown(0)
        {
            if(isNormal == true) Cursor.SetCursor(cursorNormal_2,Vector2.zero,cm);
            if(isCursorA == true) 
            {
                GameObject.Find("Broom1").GetComponent<FollowMouse>().FollowMouseRotate();
                GameObject.Find("Broom1").GetComponent<FollowMouse>().StartClean();
            }
            if(isCursorB == true) 
            {
                GameObject.Find("VacuumCleaner").GetComponent<FollowMouse>().FollowMouseRotate();
                GameObject.Find("VacuumCleaner").GetComponent<FollowMouse>().StartClean();
            }
            if(isCursorC == true) 
            {
                GameObject.Find("Ball").GetComponent<FollowMouse>().FollowMouseRotate();
                GameObject.Find("Ball").GetComponent<FollowMouse>().StartClean();
                this.GetComponent<ButtonAudio>().ThrowBall();
            }
            if(isCursorD == true) Cursor.SetCursor(cursorD_2,Vector2.zero,cm);
            if(isCursorE == true) Cursor.SetCursor(cursorE_2,Vector2.zero,cm);
        }
        if(Input.touches[0].phase != TouchPhase.Canceled && Input.touches[0].phase == TouchPhase.Ended)//Input.GetMouseButtonUp(0)
        {
            if(isNormal == true) Cursor.SetCursor(cursorNormal_1,Vector2.zero,cm);
            if(isCursorA == true) Cursor.SetCursor(cursorA_1,Vector2.zero,cm);
            if(isCursorB == true) Cursor.SetCursor(cursorB_1,Vector2.zero,cm);
            if(isCursorC == true) Cursor.SetCursor(cursorC_1,Vector2.zero,cm);
            if(isCursorD == true) Cursor.SetCursor(cursorD_1,Vector2.zero,cm);
            if(isCursorE == true) Cursor.SetCursor(cursorE_1,Vector2.zero,cm);
        }
        /*if(Input.GetMouseButtonDown(1))
        {
            if(isNormal ==true) IsNormal();
            if(isCursorA == true) IsNormal();
            if(isCursorB == true) IsNormal();
            if(isCursorC == true) IsNormal();
            if(isCursorD == true) IsNormal();
            if(isCursorE == true) IsNormal();
        }*/
    }



}
