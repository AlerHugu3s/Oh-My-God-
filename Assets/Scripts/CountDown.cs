using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public int totalTime = 300;
    private int yourScore = 0;
    public int mp = 0;

    public GameObject time;
    public GameObject score;
    public GameObject win;
    public GameObject mpUI;

    public bool isClear = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountTime());
        StartCoroutine(ScoreGet());
    }

    void Update()
    {
        if(totalTime == 0)
        {
            win.GetComponentInChildren<Text>().text = "恭喜您!\n你击败了'一无所有'!\n你的分数是:" + yourScore.ToString();
            win.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        mpUI.GetComponent<Text>().text = "您的MP:"+ mp.ToString() +"/100";
    }

    IEnumerator CountTime()
    {
        while (totalTime >=0)
        {
            time.GetComponent<Text>().text = "剩余时间: " + totalTime.ToString();
            yield return new WaitForSeconds(1f);
            totalTime--;
        }
    }
    IEnumerator ScoreGet()
    {
        
        while(yourScore!=-1)
        {
            score.GetComponent<Text>().text = "当前分数: " + yourScore.ToString();
            yield return new WaitForSeconds(1f);
            if(isClear == true)
            {
                yourScore += 100;
            }
        }
    }

    public void NotClear()
    {
        isClear = false;
    }
    public void Clear()
    {
        isClear = true;
    }

    public void mpCost()
    {
        if(mp>=5) mp -=5;
        else mp = 0;
    }

    public void mpGet()
    {
        if(mp<=90) mp += 10;
        else mp = 100;
    }

    public void setYourScore(int yourScore)
    {
        this.yourScore = yourScore;
    }
    public int getYourScore()
    {
        return yourScore;
    }

}
