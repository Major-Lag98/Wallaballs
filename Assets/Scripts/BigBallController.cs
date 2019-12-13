using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBallController : MonoBehaviour
{
    float timer;

    public int explosionCount;
    public float speed;

    public GameObject ball;

    Vector2 trianglePosition;

    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(2.5f, 7.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //after n seconds explode
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Explode();
        }
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
        Debug.Log("Hit wall/player");
        Explode();
    }

    void Explode()
    {
        Vector2 spawnLoc = transform.position;
        Debug.Log("Exploded into " + explosionCount + " parts");
        float angleIncrement = (2 * Mathf.PI) / explosionCount; //divide 2pi by how many balls I want to spawn
        for(int i = 0; i < explosionCount; i++)
        {
            Vector2 direction = new Vector2(Mathf.Cos(angleIncrement * i), Mathf.Sin(angleIncrement*i));
            GameObject smallBall = Instantiate(ball, spawnLoc, Quaternion.identity);
            smallBall.GetComponent<Rigidbody2D>().velocity = direction*speed;
        }
        Destroy(gameObject);
    }
}
