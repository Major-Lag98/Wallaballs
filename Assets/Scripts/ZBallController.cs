using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZBallController : MonoBehaviour
{
    public float speed = 1.0f;
    public float maxDistance = 1;

    int count = 0;

    public GameObject target;

    Vector2 targetPos;
    Vector2 currPos;
    Vector2 lastPos;

    Vector2 toPlayer;



    float lifeTime = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = GameObject.Find("Triangle").GetComponent<Rigidbody2D>().position;
        currPos = gameObject.transform.position;

        toPlayer = (targetPos - currPos).normalized;

        lastPos = currPos;
        gameObject.GetComponent<Rigidbody2D>().velocity = toPlayer * speed;//start launched to player
    }

    // Update is called once per frame
    void Update()
    {
        currPos = gameObject.transform.position;
        //targetPos = target.transform.position;
        if (Vector2.Distance(currPos, lastPos) >= maxDistance) //stop the ball, wait, then launch the ball at triangle again
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            lastPos = currPos;
            count += 1;
            StartCoroutine("WaitAsec");
        }




        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Debug.Log("Ball life time reached");
            Destroy(transform.parent.gameObject);//fix

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        TriangleController player = other.gameObject.GetComponent<TriangleController>();

        if (player != null)//check if we hit player
        {
            Debug.Log("Ive hit a player");
            player.ChangeHealth(-1);
        }

        if (transform.parent != null) //if ball has a parent, destroy parent
        {
            Destroy(transform.parent.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    IEnumerator WaitAsec()
    {
        yield return new WaitForSeconds(1);
        if (count >= 5)
        {
            Destroy(gameObject);
        }
        targetPos = GameObject.Find("Triangle").GetComponent<Rigidbody2D>().position;
        gameObject.GetComponent<Rigidbody2D>().velocity = (targetPos - currPos).normalized * speed;
    }
}
