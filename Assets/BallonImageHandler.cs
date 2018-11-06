using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BallonImageHandler : MonoBehaviour {

    public Transform sagira;
    public GameObject scoreboard;
    public GameObject level1;
    public Text console;
    public TextMeshPro front;
    public TextMeshPro back;
    public List<GameObject> ballons;

    private const int level1BallonsTotal = 10;

    private float resetCooldownValue = 0;
    private bool gameStarted = false;
    private float gameTime = 0.0F;
    private int level1Ballons = 0;

    // Use this for initialization
    void Start () {
        ballons = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        resetCooldownValue -= Time.deltaTime;

        Vector3 myPos = transform.position;
        Vector3 sagiraPos = sagira.transform.position;

        float diff = Vector3.Distance(myPos, sagiraPos);

        //sconsole.text = diff + "";

        if (gameStarted)
            gameTime += Time.deltaTime;


        if (diff <= 0.15 && resetCooldownValue <= 0)
        {
            //Reset Game
            ResetGame();

            resetCooldownValue = 5;
        }
    }

    public void PopBallon(int level, GameObject ballon)
    {
        level1Ballons++;
        ballons.Add(ballon);

        if(level == 1 && level1Ballons == 1)
        {
            gameStarted = true;
        }

        if(level == 1 && level1Ballons == level1BallonsTotal)
        {
            //GAMEOVER
            gameStarted = false;
            scoreboard.SetActive(true);
            level1.SetActive(false);

            string gameover = "GAMEOVER\n\nTime: " + gameTime;

            back.text = gameover;
            front.text = gameover;
        }
    }

    void ResetGame()
    {
        scoreboard.SetActive(false);
        level1.SetActive(true);

        foreach(Transform child in level1.GetComponent<Transform>())
        {
            child.gameObject.SetActive(true);
        }

        ballons = new List<GameObject>();
        gameStarted = false;
        gameTime = 0.0F;
        level1Ballons = 0;

    }

    public void Undo()
    {
        if(gameStarted)
        {
            int index = ballons.Count;

            if(index > 0)
            {
                ballons[index - 1].SetActive(true);
                ballons.Remove(ballons[index - 1]);
                level1Ballons--;
            }
        }
    }

}
