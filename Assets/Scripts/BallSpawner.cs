using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallSpawner : MonoBehaviour //Spawn balls based on the timer //i also call this game controller
{
    public bool alive = true;
    public bool paused = false;

    
    float x_max = 8.36f;
    float x_min = -8.36f;
    float y_max = 4.49f;
    float y_min = -4.4f;


    //time stuff
    float ballSpawnPeriod = 1.0f;
    float ballSpawnPeriodMax = 1.0f;

    float bigBallSpawnPeriod = 0.1f;
    float bigBallSpawnPeriodMax = 10.0f;

    float missileSpawnPeriod = 0.1f;
    float missileSpawnPeriodMax = 2.0f;

    float wallSpawnPeriod = 0.1f;
    float wallSpawnPeriodMax = 10.0f;

    float weirdBallSpawnPeriod = 0.1f;
    float weirdBallSpawnPeriodMax = 12.0f;

    float ZBallSpawnPeriod = 0.01f;
    float ZBallSpawnPeriodMax = 2.0f;

    float ballDecPeriod = 15.0f;
    float bigBallDecPeriod = 20.0f;
    float missileDecPreiod = 25.0f;
    float wallDecPeriod = 30.0f;
    float weirdBallDecPeriod = 30.0f;
    float ZBallDecPeriod = 30.0f;

    
    float timer = 0f;

    
    //

    public GameObject NormBallWarning;
    public GameObject bigBallBroadcasterPrefab;
    public GameObject missileWarning;
    public GameObject wallWarning;
    public GameObject WeirdBallWarning;
    public GameObject ZBallWarning;
    public GameObject deathUI;


    public GameObject timerTMP;
    TextMeshProUGUI myText;

    // Start is called before the first frame update
    void Start()
    {
        //pauseMenue = GameObject.Find("PauseMenue");
        myText = timerTMP.GetComponentInChildren<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {


        
        if (alive)
        {

            //ballSpawnPeriod -= Time.deltaTime;
            
            //introduce new balls after a certain amount of time
            if (timer >= 10)
            {
                //bigBallSpawnPeriod -= Time.deltaTime;
            }
            if (timer >= 20)
            {
                //missileSpawnPeriod -= Time.deltaTime;
            }
            if (timer >= 30)
            {
                //wallSpawnPeriod -= Time.deltaTime;
            }
            if (timer >= 40)
            {
                //weirdBallSpawnPeriod -= Time.deltaTime;
            }
            if (timer >= 0)
            {
                ZBallSpawnPeriod -= Time.deltaTime;
            }

            timer += Time.deltaTime;
        }
        else deathUI.SetActive(true);
        

        if (ballSpawnPeriod <= 0 || bigBallSpawnPeriod <= 0 || missileSpawnPeriod <=0 || wallSpawnPeriod <= 0 || weirdBallSpawnPeriod <= 0 || ZBallSpawnPeriod <= 0)
        {
            switch (Random.Range(0, 8))
            {
                case (0)://top of screen left
                    //Debug.Log("Enter case 0");
                    if (wallSpawnPeriod <= 0)
                    {
                        spawnWall(Random.Range(0,12));
                    }
                    else spawnBall(Random.Range(x_min, 0.0f), y_max);
                    break;

                case (1)://top of screen right
                    //Debug.Log("Enter case 1");
                    if (wallSpawnPeriod <= 0)
                    {
                        spawnWall(Random.Range(0, 12));
                    }
                    else spawnBall(Random.Range(0.0f, x_max), y_max);
                    break;

                case (2)://right of screen top
                    //Debug.Log("Enter case 2");
                    if (wallSpawnPeriod <= 0)
                    {
                        spawnWall(Random.Range(0, 12));
                    }
                    else spawnBall(x_max, Random.Range(0.0f, y_max));
                    break;

                case (3)://right of screen bot
                    //Debug.Log("Enter case 3");
                    if (wallSpawnPeriod <= 0)
                    {
                        spawnWall(Random.Range(0, 12));
                    }
                    else spawnBall(x_max, Random.Range(y_min, 0.0f));
                    break;

                case (4)://bot of screen right
                    //Debug.Log("Enter case 4");
                    if (wallSpawnPeriod <= 0)
                    {
                        spawnWall(Random.Range(0, 12));
                    }
                    else spawnBall(Random.Range(0.0f, x_max), y_min);
                    break;

                case (5)://bot of screen left
                    //Debug.Log("Enter case 5");
                    if (wallSpawnPeriod <= 0)
                    {
                        spawnWall(Random.Range(0, 12));
                    }
                    else spawnBall(Random.Range(x_min, 0.0f), y_min);
                    break;

                case (6)://left of screen bot 
                    //Debug.Log("Enter case 6");
                    if (wallSpawnPeriod <= 0)
                    {
                        spawnWall(Random.Range(0, 12));
                    }
                    else spawnBall(x_min, Random.Range(y_min, 0.0f));
                    break;

                case (7)://left of screen top
                    //Debug.Log("Enter case 7");
                    if (wallSpawnPeriod <= 0)
                    {
                        spawnWall(Random.Range(0, 12));
                    }
                    else spawnBall(x_min, Random.Range(0.0f, y_max));
                    break;
            }
            //ballSpawnPeriod = ballSpawnPeriodMax;//reset cooldown
            
        }


        //timer
        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        myText.text = string.Format("{0:00}:{1:00}", minutes, seconds);


        //make balls spawn more often
        if (timer > ballDecPeriod) //normal balls
        {
            ballSpawnPeriodMax = Mathf.Round(Mathf.Clamp(ballSpawnPeriodMax - 0.05f, 0.25f, ballSpawnPeriodMax) * 100)/100f; 
            ballDecPeriod += 15;
            Debug.Log("Time decremented, new time = " + ballSpawnPeriodMax);
        }
        if (timer > bigBallDecPeriod) //big balls
        {
            bigBallSpawnPeriodMax = Mathf.Round(Mathf.Clamp(bigBallSpawnPeriodMax - 0.05f, 0.25f, bigBallSpawnPeriodMax) * 100) / 100f;
            bigBallDecPeriod += 15;
            Debug.Log("BB Time decremented, new time = " + bigBallSpawnPeriodMax);
        }
        if (timer > missileDecPreiod) //missiles
        {
            missileSpawnPeriodMax = Mathf.Round(Mathf.Clamp(missileSpawnPeriodMax - 0.05f, 0.25f, missileSpawnPeriodMax) * 100) / 100f;
            missileDecPreiod += 15;
            Debug.Log("Missile time decremented, new time = " + missileSpawnPeriodMax);
        }
        if (timer > wallDecPeriod) //walls
        {
            wallSpawnPeriodMax = Mathf.Round(Mathf.Clamp(wallSpawnPeriodMax - 0.05f, 0.25f, wallSpawnPeriodMax) * 100) / 100f;
            wallDecPeriod += 15;
            Debug.Log("Wall time decremented, new time = " + wallSpawnPeriodMax);
        }
        if (timer > weirdBallDecPeriod)//weird balls
        {
            weirdBallSpawnPeriodMax = Mathf.Round(Mathf.Clamp(weirdBallSpawnPeriodMax - 0.05f, 0.25f, weirdBallSpawnPeriodMax) * 100) / 100f;
            weirdBallDecPeriod += 15;
            Debug.Log("Weird time decremented, new time = " + weirdBallSpawnPeriodMax);
        }
        if (timer > ZBallDecPeriod)//weird balls
        {
            ZBallSpawnPeriodMax = Mathf.Round(Mathf.Clamp(ZBallSpawnPeriodMax - 0.05f, 0.25f, ZBallSpawnPeriodMax) * 100) / 100f;
            ZBallDecPeriod += 15;
            Debug.Log("Weird time decremented, new time = " + weirdBallSpawnPeriodMax);
        }
    }
    void spawnBall(float locationX, float locationY) //spawn a ball at where you want it
    {
        Vector2 spawnLoc = new Vector2(locationX, locationY);
        if (ballSpawnPeriod <= 0)
        {
            GameObject preBall = Instantiate(NormBallWarning, spawnLoc, Quaternion.identity);
            ballSpawnPeriod = ballSpawnPeriodMax;
        }
        if (bigBallSpawnPeriod <= 0)//spawn big ball
        {
            GameObject preBB = Instantiate(bigBallBroadcasterPrefab, spawnLoc, Quaternion.identity);
            bigBallSpawnPeriod = bigBallSpawnPeriodMax;
        }
        if (missileSpawnPeriod <= 0) //spawn missile
        {
            GameObject preMissle = Instantiate(missileWarning, spawnLoc, Quaternion.identity);
            missileSpawnPeriod = missileSpawnPeriodMax;
        }
        if (weirdBallSpawnPeriod <= 0)
        {
            GameObject preWeird = Instantiate(WeirdBallWarning, spawnLoc, Quaternion.identity);
            weirdBallSpawnPeriod = weirdBallSpawnPeriodMax;
        }
        if (ZBallSpawnPeriod <= 0)
        {
            GameObject preZ = Instantiate(ZBallWarning, spawnLoc, Quaternion.identity);
            ZBallSpawnPeriod = ZBallSpawnPeriodMax;
        }
    }

    void spawnWall(int loc)
    {
        Vector2 spawnLoc;
        GameObject preWall;
        switch (loc)
        {
            case (0):
                spawnLoc = new Vector2(-6.0f, 3.8f); //top left
                preWall = Instantiate(wallWarning, spawnLoc, Quaternion.Euler(0,0,270));
                break;

            case (1):
                spawnLoc = new Vector2(0.0f, 3.8f); //top middle
                preWall = Instantiate(wallWarning, spawnLoc, Quaternion.Euler(0, 0, 270));
                break;

            case (2):
                spawnLoc = new Vector2(6.0f, 3.8f); //top right
                preWall = Instantiate(wallWarning, spawnLoc, Quaternion.Euler(0, 0, 270));
                break;

            case (3):
                spawnLoc = new Vector2(7.7f, 3.0f); //right top
                preWall = Instantiate(wallWarning, spawnLoc, Quaternion.Euler(0, 0, 180));
                break;

            case (4):
                spawnLoc = new Vector2(7.7f, 0f); //right middle
                preWall = Instantiate(wallWarning, spawnLoc, Quaternion.Euler(0, 0, 180));
                break;

            case (5):
                spawnLoc = new Vector2(7.7f, -3.0f); //right bot
                preWall = Instantiate(wallWarning, spawnLoc, Quaternion.Euler(0, 0, 180));
                break;

            case (6):
                spawnLoc = new Vector2(6.0f, -3.8f); //bot right
                preWall = Instantiate(wallWarning, spawnLoc, Quaternion.Euler(0, 0, 90));
                break;

            case (7):
                spawnLoc = new Vector2(0.0f, -3.8f); //bot middle
                preWall = Instantiate(wallWarning, spawnLoc, Quaternion.Euler(0, 0, 90));
                break;

            case (8):
                spawnLoc = new Vector2(-6.0f, -3.8f); //bot left
                preWall = Instantiate(wallWarning, spawnLoc, Quaternion.Euler(0, 0, 90));
                break;

            case (9):
                spawnLoc = new Vector2(-7.7f, -3.0f); //left bot
                preWall = Instantiate(wallWarning, spawnLoc, Quaternion.Euler(0, 0, 0));
                break;

            case (10):
                spawnLoc = new Vector2(-7.7f, 0f); //left middle
                preWall = Instantiate(wallWarning, spawnLoc, Quaternion.Euler(0, 0, 0));
                break;

            case (11):
                spawnLoc = new Vector2(-7.7f, 3.0f); //left top
                preWall = Instantiate(wallWarning, spawnLoc, Quaternion.Euler(0, 0, 0));
                break;

        }
        wallSpawnPeriod = wallSpawnPeriodMax;
    }
}
