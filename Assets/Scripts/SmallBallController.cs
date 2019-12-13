using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallBallController : MonoBehaviour
{
    
    float lifeTime = 100.0f;

    //BallSpawner ballSpawner;

    //Vector2 savedVelocity;

    //Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        /*
        rb = GetComponent<Rigidbody2D>();
        GameObject gameController = GameObject.Find("Canvas");
        ballSpawner = gameController.GetComponent<BallSpawner>();
        //savedVelocity = rb.velocity;
        */
    }

    // Update is called once per frame
    void Update()
    {
        //if (ballSpawner.paused == false)
       //{
            //Time.timeScale = 1;
            //rb.velocity = savedVelocity;
            lifeTime -= Time.deltaTime;
            if (lifeTime <= 0)
            {
                Debug.Log("Ball life time reached");
                Destroy(gameObject);

            }
            //savedVelocity = rb.velocity;
       // }
        //else Time.timeScale = 0;//rb.velocity = rb.velocity * 0;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        TriangleController player = other.gameObject.GetComponent<TriangleController>();
        //Debug.Log("Ive entered a ball");

        if (player != null)
        {
            Debug.Log("Ive hit a player");
            player.ChangeHealth(-1);
        }
        //Debug.Log("Ball destroyed");
        Destroy(gameObject);
    }
}
