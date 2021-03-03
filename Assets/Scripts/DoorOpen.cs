using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public GameObject openedDoor;
    public GameObject closedDoor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator OpenDoor()
    {
        closedDoor.SetActive(false);   
        openedDoor.SetActive(true);
        yield return new WaitForSeconds(.5f);
        openedDoor.SetActive(false);
        closedDoor.SetActive(true);
    }
    public void Open_Door()
    {
        StartCoroutine(OpenDoor());
    }
}
