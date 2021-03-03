using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuChange : MonoBehaviour
{
    public GameObject menu;
    public Sprite unpressedButton;
    public Sprite pressedButton;

    int isPressed = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PressButton()
    {
        if(isPressed == 0) 
        {
            isPressed = 1;
            menu.GetComponent<Image>().sprite = pressedButton;
        }
        else 
        {
            isPressed = 0;
            menu.GetComponent<Image>().sprite = unpressedButton;
        }
    }
}
