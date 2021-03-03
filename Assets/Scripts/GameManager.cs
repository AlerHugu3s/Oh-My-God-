using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject spawnPos;
    public GameObject human;
    public GameObject animal;
    public GameObject ghost;
    public GameObject skull;
    public GameObject gameManager;
    private IEnumerator coroutine;
    public GameObject[] GhostSpawnPos;


    // Start is called before the first frame update
    void Start()
    {
        coroutine = SkullArmy(1f);
        StartCoroutine(HumanSpawn());
        StartCoroutine(AnimalSpawn());
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.GetComponent<CountDown>().totalTime == 44f
        ||this.gameObject.GetComponent<CountDown>().totalTime == 46f
        ||this.gameObject.GetComponent<CountDown>().totalTime == 48f
        ||this.gameObject.GetComponent<CountDown>().totalTime == 50f
        ||this.gameObject.GetComponent<CountDown>().totalTime == 86f
        ||this.gameObject.GetComponent<CountDown>().totalTime == 88f
        ||this.gameObject.GetComponent<CountDown>().totalTime == 90f
        ||this.gameObject.GetComponent<CountDown>().totalTime == 118f
        ||this.gameObject.GetComponent<CountDown>().totalTime == 120f)
        {
            StartCoroutine(coroutine);
        }
        else
        {
            StopCoroutine(coroutine);
            coroutine = SkullArmy(1f);
        }
    }

    IEnumerator HumanSpawn()
    {
        while (gameManager.GetComponent<CountDown>().totalTime >=0)
        {
            yield return new WaitForSeconds(13f);
            this.GetComponent<ButtonAudio>().DoorOpened();
            GameObject.Find("Door").GetComponent<DoorOpen>().Open_Door();
            Instantiate(human,spawnPos.transform.position,spawnPos.transform.rotation);
        }
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene (0);
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene (1);
        Time.timeScale = 1;
    }

    IEnumerator AnimalSpawn()
    {
        while (gameManager.GetComponent<CountDown>().totalTime >=0)
        {
            yield return new WaitForSeconds(10f);
            this.GetComponent<ButtonAudio>().DoorOpened();
            GameObject.Find("Door").GetComponent<DoorOpen>().Open_Door();
            Instantiate(animal,spawnPos.transform.position,spawnPos.transform.rotation);
        }
    }

    public void GhostSpawn()
    {
        Instantiate(ghost,GhostSpawnPos[Random.Range(0,5)].transform.position,Quaternion.Euler(0,0,0));
    }

    public void SkullSpawn()
    {
        Instantiate(skull,GhostSpawnPos[Random.Range(0,5)].transform.position,Quaternion.Euler(0,0,0));
    }

    IEnumerator SkullArmy(float waitTime)
    {
        SkullSpawn();
        yield return new WaitForSeconds(waitTime);
    }
}
