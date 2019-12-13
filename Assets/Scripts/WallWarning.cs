using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallWarning : MonoBehaviour
{
    public GameObject wallBallPrefab;

    public float speed = 1;

    float timer = 3f;

    SpriteRenderer spriteRenderer;
    
    Vector2 velocity;
    

    // Start is called before the first frame update
    void Start()
    {

       
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (Time.fixedTime % 1 < .2)
        {
            spriteRenderer.enabled = false;
        }
        else
        {
            spriteRenderer.enabled = true;
        }
        if (timer <= 0)
        {
            Destroy(gameObject);
            spawn();
        }
    }

    void spawn()
    {
        for (int i = -2; i <= 2 ; i += 1) //spawn five balls in a row
        {
            
            GameObject wallBall = Instantiate(wallBallPrefab, (transform.position - transform.right * 1) - transform.up * (.6f  * i), Quaternion.identity);
            wallBall.GetComponent<Rigidbody2D>().velocity = transform.right * speed;

        }
    }

    
}
