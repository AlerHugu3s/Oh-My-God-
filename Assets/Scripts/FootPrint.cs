using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootPrint : MonoBehaviour
{
    public GameObject footPrint;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("LeaveFootPrint",4f,4f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LeaveFootPrint()
    {
        if(this.gameObject.GetComponent<Rigidbody2D>().velocity.x >= 0)
        Instantiate(footPrint,this.gameObject.transform.position + new Vector3(-0.1f,-0.3f,0),Quaternion.Euler(0,0,0));
        if(this.gameObject.GetComponent<Rigidbody2D>().velocity.x < 0)
        Instantiate(footPrint,this.gameObject.transform.position + new Vector3(0.1f,-0.3f,0),Quaternion.Euler(0,180,0));
    }
}
