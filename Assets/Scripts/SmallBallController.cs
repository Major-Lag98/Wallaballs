using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallBallController : MonoBehaviour
{
    
    float lifeTime = 100.0f;

    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
            lifeTime -= Time.deltaTime;
            if (lifeTime <= 0)
            {
                Debug.Log("Ball life time reached");
                Destroy(transform.parent.gameObject);

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
}
