using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleController : MonoBehaviour
{

    public bool animationDone = false;
    bool iFramesPlaying = false;

    public float speed = 1;

    float invincibleTimer = 3.0f;
    float timeInvincible = 3.0f;

    bool isInvincible = false;

    Rigidbody2D rigidbody2d;
    SpriteRenderer spriteRenderer;

    BallSpawner ballSpawner;

    public PolygonCollider2D pc3hp;
    public PolygonCollider2D pc2hp;
    public PolygonCollider2D pc1hp;

    public Sprite twohp;
    public Sprite onehp;

    int maxHealth = 3;
    int currentHealth;




    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        GameObject gameController = GameObject.Find("GameController");
        ballSpawner = gameController.GetComponent<BallSpawner>();
        currentHealth = maxHealth;

        StartCoroutine("WaitForStart");
        
    }


    void Update()
    {

        //movement
        if (animationDone)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            Vector2 move = new Vector2(horizontal, vertical); //vector2 for new movement
            Vector2 position = rigidbody2d.position;
            position = position + move * speed;
            rigidbody2d.MovePosition(position);

            //rotation
            float rotation = Input.GetAxis("Rotation");
            rigidbody2d.AddTorque(-rotation); //Possibly better if i use transform, idk what i like yet
        }
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (iFramesPlaying == false)
            {
                StartCoroutine("IFrames");
                Debug.Log("Starting IFrames");
                iFramesPlaying = true;
            }
            
            
            
            if (invincibleTimer <= 0)
            {
                isInvincible = false;
                StopCoroutine("IFrames");
                Debug.Log("Stoping IFrames");
                iFramesPlaying = false;
                spriteRenderer.enabled = true;
                
            }
        }

    }
    
    public void ChangeHealth(int amount)
    {
        if (isInvincible)
        {
            return;
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);

        if (amount < 0) //Take Damage
        {
            
            if (currentHealth > 0) //havent died yet
            {
                isInvincible = true;
                invincibleTimer = timeInvincible;
            }

        }
        else if (amount > 0)//heal
        {
            //Debug.Log("Pretend this is a heal animation");
        }

        
        //change sprite based on health
        if (currentHealth == 2)
        {
            spriteRenderer.sprite = twohp;
            pc3hp.enabled = false;
            pc2hp.enabled = true;
        }
        if (currentHealth == 1)
        {
            spriteRenderer.sprite = onehp;
            pc2hp.enabled = false;
            pc1hp.enabled = true;
        }
        if (currentHealth <= 0)
        {
            spriteRenderer.enabled = false;
            pc1hp.enabled = false;
            ballSpawner.alive = false;
        }
        
        Debug.Log(currentHealth + "/" + maxHealth);

    }


    IEnumerator WaitForStart()
    {
        yield return new WaitForSeconds(1);
        spriteRenderer.enabled = true;
        animationDone = true;
    }
    IEnumerator IFrames()
    {
        while (true) 
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(.1f);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(.1f);
        }
           
    }
    
}
