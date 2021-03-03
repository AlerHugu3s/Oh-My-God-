using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMove : MonoBehaviour
{

    public bool isActive = true;
    public GameObject[] targetPos;
    CountDown countDown;
    ButtonAudio buttonAudio;
    Vector2 velocity = Vector2.zero;//速度
    Vector2 target;
    Rigidbody2D rig;
    public float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        rig = this.GetComponent<Rigidbody2D>();
        rig.AddForce(new Vector2(0,-2f));
        countDown = GameObject.Find("GameManager").GetComponent<CountDown>();
        buttonAudio = GameObject.Find("GameManager").GetComponent<ButtonAudio>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isActive == true)    RandomAction();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Room")&&(this.CompareTag("Human")||this.CompareTag("Ghost")||this.CompareTag("Animal")||this.CompareTag("Skull")))
        {
            rig.velocity = Vector2.zero;
            target = new Vector2(0,0);
            Vector2 direct = target - rig.position;
            velocity = direct.normalized*speed;
            //速度过大时减速
            if (velocity.sqrMagnitude > speed * speed) 
            velocity = velocity.normalized * speed;
            rig.AddForce(velocity);
        }
        if(other.CompareTag("Ghost")&&this.CompareTag("Human"))
        {
            countDown.mpGet();
            buttonAudio.GirlScream();
            this.gameObject.GetComponent<AnimationController>().frightened();
        }
        if(other.CompareTag("Skull")&&this.CompareTag("Human"))
        {
            buttonAudio.GirlFainted();
            this.gameObject.GetComponent<AnimationController>().Fainted();
        }
        if(other.CompareTag("VacuumCleaner")&&(this.CompareTag("Ghost")||this.CompareTag("Skull")))
        {
            if(countDown.mp >= 5)
            {
                countDown.mpCost();
                this.GetComponentInChildren<AnimationController>().Die();
            }
        }
        if(other.CompareTag("Broom1")&&this.CompareTag("FootPrint"))
        {
            countDown.setYourScore(countDown.getYourScore() + 10);
            Destroy(this.gameObject,0.5f);
        }
        if(other.CompareTag("Ball")&&this.CompareTag("Animal"))
        {
            countDown.setYourScore(countDown.getYourScore() + 20);
            buttonAudio.Meow();
            Destroy(this.gameObject,0.5f);
        }
    }

    private void RandomAction()
    {
        if (Random.value < 0.01f) target = transform.position + Quaternion.Euler(0, 0, Random.value * 360) * Vector3.right * 10;//随机指定目标
        Vector2 direct = target - rig.position;
        if (direct.sqrMagnitude > 1)
        {
            velocity=direct.normalized * speed / 2;
        }
        

        velocity -= rig.velocity;

        //速度过大时减速
        if (velocity.sqrMagnitude > speed * speed) velocity = velocity.normalized * speed;

        if(direct.x < 0) transform.eulerAngles = new Vector3(0,180,0);
        else transform.transform.eulerAngles = new Vector3(0,0,0);

        rig.AddForce(velocity);
        velocity = Vector2.zero;

        
    }
}
