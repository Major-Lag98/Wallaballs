using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    public float speed;
    public float turnSpeed;
    public float trackTime; //how long should the missile track?

    Rigidbody2D rb;
    Transform triangleTrans;

    Vector2 trianglePos;
    Vector2 myPos;

    Vector2 toTriangle;

    float angle;
    

    void Start() //start pointed at the player
    {
        Track(1);
    }

    void Update() //keep track of and try to hit player
    {
        if (trackTime >= 0) //check if missile is bored
        {
            Track(Time.deltaTime * turnSpeed);
            rb.velocity = (transform.right) * speed;
        }
        trackTime -= Time.deltaTime;
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

    void Track(float turnSpeed) //track the triangle and try to hit
    {
        trianglePos = GameObject.Find("Triangle").GetComponent<Rigidbody2D>().position;
        rb = GetComponent<Rigidbody2D>();
        myPos = rb.position;
        Vector2 vectorToTarget = trianglePos - myPos;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, turnSpeed);
    }
}
