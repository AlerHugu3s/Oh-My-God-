using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    bool isFollow = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isFollow == true)
        FollowMouseRotate();
    }

    public void FollowMouseRotate()
    {
        //获取鼠标的坐标，鼠标是屏幕坐标，Z轴为0，这里不做转换  
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);//Input.mousePosition
        this.gameObject.transform.position = mouse + new Vector3(-0.1f,0.4f,-1f);
    }

    public void StartClean()
    {
        StartCoroutine(clean());
    }

    IEnumerator clean()
    {
        if(this.CompareTag("ball"))
        {
            this.GetComponent<BoxCollider2D>().enabled = true;
            isFollow = false;
            this.gameObject.transform.position += new Vector3(0,0,20);
            yield return new WaitForSeconds(2f);
            this.gameObject.transform.position -= new Vector3(0,0,20);
            isFollow = true;
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
        else 
        {
            this.GetComponent<BoxCollider2D>().enabled = true;
            isFollow = false;
            this.gameObject.transform.position += new Vector3(0,0,20);
            yield return new WaitForSeconds(1f);
            this.gameObject.transform.position -= new Vector3(0,0,20);
            isFollow = true;
            this.GetComponent<BoxCollider2D>().enabled = false;
        }

    }

}
