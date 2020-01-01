using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broadcaster : MonoBehaviour
{
    float timer = 1.0f;
    
    SpriteRenderer spriteRenderer;

    Vector2 position;
    Vector2 trianglePosition;

    public GameObject ballPrefab;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        trianglePosition = GameObject.Find("Triangle").GetComponent<Rigidbody2D>().position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        position = gameObject.transform.position;
        //StartCoroutine("Fade");
    }

    // Update is called once per frame
    void Update()
    {
        trianglePosition = GameObject.Find("Triangle").GetComponent<Rigidbody2D>().position;
        Vector2 vectorToTarget = trianglePosition - position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, 1);

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Vector2 towardPlayer = (trianglePosition - position).normalized;
            Destroy(gameObject);
            GameObject normBall = Instantiate(ballPrefab, position, Quaternion.identity);
            normBall.GetComponent<Rigidbody2D>().velocity = towardPlayer * speed;
        }
    }
    /*
    IEnumerator Fade() //Coroutines!!!
    {

        
        for (float i = 0.0f; i <= 1; i += 0.1f)
        {
            Color c = spriteRenderer.material.color;
            c.a = i;
            spriteRenderer.material.color = c;
            yield return new WaitForSeconds(0.1f);

        }

        
    }
    */
}
