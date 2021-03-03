using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCount : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject gameManager;
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        //StartCoroutine(FindHuman());
        InvokeRepeating("FindObject",0f,0.5f);
    }

    void FindObject()
	{
		if(GameObject.FindGameObjectWithTag("Human")||GameObject.FindGameObjectWithTag("FootPrint")||GameObject.FindGameObjectWithTag("Animal")||GameObject.FindGameObjectWithTag("Ghost")) gameManager.GetComponent<CountDown>().NotClear();
        else if(!GameObject.FindGameObjectWithTag("Human")||!GameObject.FindGameObjectWithTag("FootPrint")||GameObject.FindGameObjectWithTag("Animal")||GameObject.FindGameObjectWithTag("Ghost")) gameManager.GetComponent<CountDown>().Clear();
	}


    // Update is called once per frame
    void Update()
    {
        
    }

    //每2S 产生一次MP收益
    /*IEnumerator FindHuman()
    {
        while(gameManager)
        {
            if(GameObject.FindGameObjectWithTag("Human"))
            {
                gameManager.GetComponent<CountDown>().mpGet();
            }
            yield return new WaitForSeconds(2f);
        }

    }*/
}
