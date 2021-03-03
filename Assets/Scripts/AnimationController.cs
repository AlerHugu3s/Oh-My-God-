using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AnimationController : MonoBehaviour
{
    public AIPath aIPath;
    private Rigidbody2D rig;
    public Animator ani;
    CountDown countDown;
    // Start is called before the first frame update
    void Start()
    {
        rig = this.gameObject.GetComponent<Rigidbody2D>();
        countDown = GameObject.Find("GameManager").GetComponent<CountDown>();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.CompareTag("Human")||this.CompareTag("Animal"))
        {
            if(rig.velocity.magnitude != 0)
            {
                ani.SetBool("isWalk",true);
                ani.SetBool("isIdle",false);
            }
            else
            {
                ani.SetBool("isWalk",false);
                ani.SetBool("isIdle",true);
            }
        }
        if(this.CompareTag("Ghost"))
        {
            if(aIPath.desiredVelocity.x >= 0.1f||aIPath.desiredVelocity.x <= -0.1f)
            {
                ani.SetBool("isWalk",true);
                ani.SetBool("isIdle",false);
            } 
            else
            {
                ani.SetBool("isWalk",false);
                ani.SetBool("isIdle",true);
            }
        }
    }

    public void frightened()
    {
        ani.Play("Girl_frightened");
        countDown.setYourScore(countDown.getYourScore() + 20);
        this.GetComponent<FootPrint>().CancelInvoke();
        this.GetComponent<RandomMove>().isActive = false;
        this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Destroy(this.gameObject,1.5f);
        
    }

    public void Fainted()
    {
        StartCoroutine(Faint());
    }

    public void Die()
    {
        if(this.CompareTag("Ghost")) 
        {
            ani.Play("Ghost_die");
            countDown.setYourScore(countDown.getYourScore() + 50);
            Destroy(this.transform.parent.gameObject,1.5f);
        }

        if(this.CompareTag("Skull")) 
        {
            ani.Play("Skull_die");
            countDown.setYourScore(countDown.getYourScore() + 100);
            Destroy(this.gameObject,1.5f);
        }
        
    }

    IEnumerator Faint()
    {
        ani.Play("Girl_fainted");
        this.GetComponent<FootPrint>().CancelInvoke();
        this.GetComponent<RandomMove>().isActive = false;
        this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        this.tag = "Untagged";
        yield return new WaitForSeconds(6f);
        this.tag = "Human";
        this.GetComponent<FootPrint>().InvokeRepeating("LeaveFootPrint",4f,4f);
        this.GetComponent<RandomMove>().isActive = true;
        ani.Play("Girl_idle");
    }
}
