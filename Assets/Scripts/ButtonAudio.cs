using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAudio : MonoBehaviour
{
    AudioSource audioSource;

    public AudioClip ball;

    public AudioClip button ;

    public AudioClip door;

    public AudioClip[] girl_scream;

    public AudioClip[] meow;

    public AudioClip girl_fainted;



    // Start is called before the first frame update
    void Awake()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ThrowBall()
    {
        audioSource.PlayOneShot(ball);
    }

    public void DoorOpened()
    {
        audioSource.PlayOneShot(door);
    }

    public void ButtonPressed()
    {
        audioSource.PlayOneShot(button);
    }

    public void GirlScream()
    {
        int i = Random.Range(0, girl_scream.Length);
        audioSource.PlayOneShot(girl_scream[i]);
    }

    public void Meow()
    {
        int i = Random.Range(0, meow.Length);
        audioSource.PlayOneShot(meow[i]);
    }
    public void GirlFainted()
    {
        audioSource.PlayOneShot(girl_fainted);
    }

}
