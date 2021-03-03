using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MpScan : MonoBehaviour
{
    public GameObject gm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gm.GetComponent<CountDown>().mp <5) this.GetComponent<Button>().enabled = false;
        else if(gm.GetComponent<CountDown>().mp >=5) this.GetComponent<Button>().enabled = true;
    }
}
